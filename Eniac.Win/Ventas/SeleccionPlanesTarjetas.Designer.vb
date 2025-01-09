<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SeleccionPlanesTarjetas
	Inherits BaseForm

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionPlanesTarjetas))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SELEC")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenInterno")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanTarjeta")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePlanTarjeta")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Interes")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroCupon")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroLote")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicar")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadCuotas")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTarjeta", -1, 28689516)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTarjeta")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco", -1, 28711172)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotasDesde")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotasHasta")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TarjetaModificable")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BancoModificable")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AGREGAR", 0)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("Importe", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Importe", 4, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Importe", 4, True)
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("ImporteAplicar", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteAplicar", 8, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ImporteAplicar", 8, True)
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
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(28689516)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(28711172)
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblImporteAnticipoSinInteres = New Eniac.Controles.Label()
        Me.txtImporteAnticipoSinInteres = New Eniac.Controles.TextBox()
        Me.lblPendiente = New Eniac.Controles.Label()
        Me.lblEfectivo = New Eniac.Controles.Label()
        Me.lblImporteTotalSinInterses = New Eniac.Controles.Label()
        Me.txtPendiente = New Eniac.Controles.TextBox()
        Me.txtEfectivo = New Eniac.Controles.TextBox()
        Me.txtImporteTotalSinInterses = New Eniac.Controles.TextBox()
        Me.ugPlanesTarjetas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblTransferencia = New Eniac.Controles.Label()
        Me.txtTransferencia = New Eniac.Controles.TextBox()
        Me.lblCheque = New Eniac.Controles.Label()
        Me.txtCheque = New Eniac.Controles.TextBox()
        Me.lblTicket = New Eniac.Controles.Label()
        Me.txtTicket = New Eniac.Controles.TextBox()
        CType(Me.ugPlanesTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'lblImporteAnticipoSinInteres
        '
        Me.lblImporteAnticipoSinInteres.AutoSize = True
        Me.lblImporteAnticipoSinInteres.LabelAsoc = Nothing
        Me.lblImporteAnticipoSinInteres.Location = New System.Drawing.Point(9, 43)
        Me.lblImporteAnticipoSinInteres.Name = "lblImporteAnticipoSinInteres"
        Me.lblImporteAnticipoSinInteres.Size = New System.Drawing.Size(132, 13)
        Me.lblImporteAnticipoSinInteres.TabIndex = 8
        Me.lblImporteAnticipoSinInteres.Text = "Total Anticipo sin recargos"
        Me.lblImporteAnticipoSinInteres.Visible = False
        '
        'txtImporteAnticipoSinInteres
        '
        Me.txtImporteAnticipoSinInteres.BindearPropiedadControl = Nothing
        Me.txtImporteAnticipoSinInteres.BindearPropiedadEntidad = Nothing
        Me.txtImporteAnticipoSinInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteAnticipoSinInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteAnticipoSinInteres.Formato = "N2"
        Me.txtImporteAnticipoSinInteres.IsDecimal = True
        Me.txtImporteAnticipoSinInteres.IsNumber = True
        Me.txtImporteAnticipoSinInteres.IsPK = False
        Me.txtImporteAnticipoSinInteres.IsRequired = False
        Me.txtImporteAnticipoSinInteres.Key = ""
        Me.txtImporteAnticipoSinInteres.LabelAsoc = Me.lblImporteAnticipoSinInteres
        Me.txtImporteAnticipoSinInteres.Location = New System.Drawing.Point(142, 40)
        Me.txtImporteAnticipoSinInteres.Name = "txtImporteAnticipoSinInteres"
        Me.txtImporteAnticipoSinInteres.Size = New System.Drawing.Size(100, 20)
        Me.txtImporteAnticipoSinInteres.TabIndex = 7
        Me.txtImporteAnticipoSinInteres.TabStop = False
        Me.txtImporteAnticipoSinInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteAnticipoSinInteres.Visible = False
        '
        'lblPendiente
        '
        Me.lblPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPendiente.AutoSize = True
        Me.lblPendiente.LabelAsoc = Nothing
        Me.lblPendiente.Location = New System.Drawing.Point(106, 486)
        Me.lblPendiente.Name = "lblPendiente"
        Me.lblPendiente.Size = New System.Drawing.Size(104, 13)
        Me.lblPendiente.TabIndex = 6
        Me.lblPendiente.Text = "Pendiente de aplicar"
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.LabelAsoc = Nothing
        Me.lblEfectivo.Location = New System.Drawing.Point(248, 15)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(46, 13)
        Me.lblEfectivo.TabIndex = 5
        Me.lblEfectivo.Text = "Efectivo"
        '
        'lblImporteTotalSinInterses
        '
        Me.lblImporteTotalSinInterses.AutoSize = True
        Me.lblImporteTotalSinInterses.LabelAsoc = Nothing
        Me.lblImporteTotalSinInterses.Location = New System.Drawing.Point(9, 15)
        Me.lblImporteTotalSinInterses.Name = "lblImporteTotalSinInterses"
        Me.lblImporteTotalSinInterses.Size = New System.Drawing.Size(127, 13)
        Me.lblImporteTotalSinInterses.TabIndex = 5
        Me.lblImporteTotalSinInterses.Text = "Total factura sin recargos"
        '
        'txtPendiente
        '
        Me.txtPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPendiente.BindearPropiedadControl = Nothing
        Me.txtPendiente.BindearPropiedadEntidad = Nothing
        Me.txtPendiente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPendiente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPendiente.Formato = "N2"
        Me.txtPendiente.IsDecimal = True
        Me.txtPendiente.IsNumber = True
        Me.txtPendiente.IsPK = False
        Me.txtPendiente.IsRequired = False
        Me.txtPendiente.Key = ""
        Me.txtPendiente.LabelAsoc = Me.lblPendiente
        Me.txtPendiente.Location = New System.Drawing.Point(216, 483)
        Me.txtPendiente.Name = "txtPendiente"
        Me.txtPendiente.Size = New System.Drawing.Size(100, 20)
        Me.txtPendiente.TabIndex = 3
        Me.txtPendiente.TabStop = False
        Me.txtPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEfectivo
        '
        Me.txtEfectivo.BindearPropiedadControl = Nothing
        Me.txtEfectivo.BindearPropiedadEntidad = Nothing
        Me.txtEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEfectivo.Formato = "N2"
        Me.txtEfectivo.IsDecimal = True
        Me.txtEfectivo.IsNumber = True
        Me.txtEfectivo.IsPK = False
        Me.txtEfectivo.IsRequired = False
        Me.txtEfectivo.Key = ""
        Me.txtEfectivo.LabelAsoc = Me.lblEfectivo
        Me.txtEfectivo.Location = New System.Drawing.Point(300, 12)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(100, 20)
        Me.txtEfectivo.TabIndex = 4
        Me.txtEfectivo.TabStop = False
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteTotalSinInterses
        '
        Me.txtImporteTotalSinInterses.BindearPropiedadControl = Nothing
        Me.txtImporteTotalSinInterses.BindearPropiedadEntidad = Nothing
        Me.txtImporteTotalSinInterses.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteTotalSinInterses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteTotalSinInterses.Formato = "N2"
        Me.txtImporteTotalSinInterses.IsDecimal = True
        Me.txtImporteTotalSinInterses.IsNumber = True
        Me.txtImporteTotalSinInterses.IsPK = False
        Me.txtImporteTotalSinInterses.IsRequired = False
        Me.txtImporteTotalSinInterses.Key = ""
        Me.txtImporteTotalSinInterses.LabelAsoc = Me.lblImporteTotalSinInterses
        Me.txtImporteTotalSinInterses.Location = New System.Drawing.Point(142, 12)
        Me.txtImporteTotalSinInterses.Name = "txtImporteTotalSinInterses"
        Me.txtImporteTotalSinInterses.ReadOnly = True
        Me.txtImporteTotalSinInterses.Size = New System.Drawing.Size(100, 20)
        Me.txtImporteTotalSinInterses.TabIndex = 4
        Me.txtImporteTotalSinInterses.TabStop = False
        Me.txtImporteTotalSinInterses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ugPlanesTarjetas
        '
        Me.ugPlanesTarjetas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugPlanesTarjetas.DisplayLayout.Appearance = Appearance1
        Me.ugPlanesTarjetas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn9.Header.Caption = ""
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.MaxWidth = 35
        UltraGridColumn9.MinWidth = 35
        UltraGridColumn9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn9.Width = 35
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.Caption = "Orden Interno"
        UltraGridColumn7.Header.VisiblePosition = 1
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 66
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.Header.Appearance = Appearance2
        UltraGridColumn1.Header.Caption = "Id Tarjeta"
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance3
        UltraGridColumn2.Header.Caption = "Nombre"
        UltraGridColumn2.Header.VisiblePosition = 3
        UltraGridColumn2.Width = 136
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Format = "N2"
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn3.Header.Appearance = Appearance5
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.MaskInput = "{double:-9.2}"
        UltraGridColumn3.MaxWidth = 90
        UltraGridColumn3.MinWidth = 90
        UltraGridColumn3.Width = 90
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance6
        UltraGridColumn4.Format = "N2"
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance7
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.MaskInput = "{double:-9.2}"
        UltraGridColumn4.MaxWidth = 90
        UltraGridColumn4.MinWidth = 90
        UltraGridColumn4.Width = 90
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance8
        UltraGridColumn18.Format = ""
        UltraGridColumn18.Header.Caption = "Nro Cupon"
        UltraGridColumn18.Header.VisiblePosition = 8
        UltraGridColumn18.MaskInput = "nnnnnnnnn"
        UltraGridColumn18.Width = 73
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance9
        UltraGridColumn19.Format = ""
        UltraGridColumn19.Header.Caption = "Nro Lote"
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn19.MaskInput = "nnnnnnnnn"
        UltraGridColumn19.Width = 73
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance10
        UltraGridColumn5.Format = "N2"
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance11
        UltraGridColumn5.Header.Caption = "Total"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.MaskInput = "{double:-9.2}"
        UltraGridColumn5.MaxWidth = 90
        UltraGridColumn5.MinWidth = 90
        UltraGridColumn5.Width = 90
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.Caption = "Cantidad Cuotas"
        UltraGridColumn8.Header.VisiblePosition = 9
        UltraGridColumn8.Hidden = True
        UltraGridColumn8.MaxWidth = 90
        UltraGridColumn8.MinWidth = 90
        UltraGridColumn8.Width = 90
        UltraGridColumn6.Header.Caption = "Tarjeta"
        UltraGridColumn6.Header.VisiblePosition = 10
        UltraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn6.Width = 136
        UltraGridColumn10.Header.VisiblePosition = 11
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 53
        UltraGridColumn11.Header.Caption = "Banco"
        UltraGridColumn11.Header.VisiblePosition = 12
        UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn11.Width = 132
        UltraGridColumn12.Header.VisiblePosition = 13
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 52
        UltraGridColumn13.Header.VisiblePosition = 14
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 68
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 68
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 85
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 82
        UltraGridColumn17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn17.Header.Caption = ""
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.MaxWidth = 16
        UltraGridColumn17.MinWidth = 16
        UltraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton
        UltraGridColumn17.Width = 16
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn7, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn18, UltraGridColumn19, UltraGridColumn5, UltraGridColumn8, UltraGridColumn6, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
        Appearance12.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance12
        SummarySettings1.DisplayFormat = "{0:N2}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance13
        Appearance14.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance14
        SummarySettings2.DisplayFormat = "{0:N2}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance15
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugPlanesTarjetas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugPlanesTarjetas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugPlanesTarjetas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPlanesTarjetas.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPlanesTarjetas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.ugPlanesTarjetas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugPlanesTarjetas.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.ugPlanesTarjetas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugPlanesTarjetas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugPlanesTarjetas.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugPlanesTarjetas.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.ugPlanesTarjetas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugPlanesTarjetas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugPlanesTarjetas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.ugPlanesTarjetas.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugPlanesTarjetas.DisplayLayout.Override.CellAppearance = Appearance22
        Me.ugPlanesTarjetas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugPlanesTarjetas.DisplayLayout.Override.CellPadding = 0
        Me.ugPlanesTarjetas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugPlanesTarjetas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugPlanesTarjetas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugPlanesTarjetas.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.ugPlanesTarjetas.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugPlanesTarjetas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugPlanesTarjetas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugPlanesTarjetas.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugPlanesTarjetas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugPlanesTarjetas.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugPlanesTarjetas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.ugPlanesTarjetas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugPlanesTarjetas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        ValueList1.Key = "Tarjetas"
        ValueList2.Key = "Bancos"
        Me.ugPlanesTarjetas.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2})
        Me.ugPlanesTarjetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugPlanesTarjetas.Location = New System.Drawing.Point(12, 70)
        Me.ugPlanesTarjetas.Name = "ugPlanesTarjetas"
        Me.ugPlanesTarjetas.Size = New System.Drawing.Size(873, 407)
        Me.ugPlanesTarjetas.TabIndex = 0
        Me.ugPlanesTarjetas.Text = "UltraGrid1"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(700, 507)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 30)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar (F8)"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(795, 507)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblTransferencia
        '
        Me.lblTransferencia.AutoSize = True
        Me.lblTransferencia.LabelAsoc = Nothing
        Me.lblTransferencia.Location = New System.Drawing.Point(406, 15)
        Me.lblTransferencia.Name = "lblTransferencia"
        Me.lblTransferencia.Size = New System.Drawing.Size(72, 13)
        Me.lblTransferencia.TabIndex = 10
        Me.lblTransferencia.Text = "Transferencia"
        '
        'txtTransferencia
        '
        Me.txtTransferencia.BindearPropiedadControl = Nothing
        Me.txtTransferencia.BindearPropiedadEntidad = Nothing
        Me.txtTransferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTransferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTransferencia.Formato = "N2"
        Me.txtTransferencia.IsDecimal = True
        Me.txtTransferencia.IsNumber = True
        Me.txtTransferencia.IsPK = False
        Me.txtTransferencia.IsRequired = False
        Me.txtTransferencia.Key = ""
        Me.txtTransferencia.LabelAsoc = Me.lblTransferencia
        Me.txtTransferencia.Location = New System.Drawing.Point(484, 12)
        Me.txtTransferencia.Name = "txtTransferencia"
        Me.txtTransferencia.Size = New System.Drawing.Size(100, 20)
        Me.txtTransferencia.TabIndex = 9
        Me.txtTransferencia.TabStop = False
        Me.txtTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCheque
        '
        Me.lblCheque.AutoSize = True
        Me.lblCheque.LabelAsoc = Nothing
        Me.lblCheque.Location = New System.Drawing.Point(590, 15)
        Me.lblCheque.Name = "lblCheque"
        Me.lblCheque.Size = New System.Drawing.Size(44, 13)
        Me.lblCheque.TabIndex = 12
        Me.lblCheque.Text = "Cheque"
        '
        'txtCheque
        '
        Me.txtCheque.BindearPropiedadControl = Nothing
        Me.txtCheque.BindearPropiedadEntidad = Nothing
        Me.txtCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCheque.Formato = "N2"
        Me.txtCheque.IsDecimal = True
        Me.txtCheque.IsNumber = True
        Me.txtCheque.IsPK = False
        Me.txtCheque.IsRequired = False
        Me.txtCheque.Key = ""
        Me.txtCheque.LabelAsoc = Me.lblCheque
        Me.txtCheque.Location = New System.Drawing.Point(640, 12)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(100, 20)
        Me.txtCheque.TabIndex = 11
        Me.txtCheque.TabStop = False
        Me.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTicket
        '
        Me.lblTicket.AutoSize = True
        Me.lblTicket.LabelAsoc = Nothing
        Me.lblTicket.Location = New System.Drawing.Point(746, 15)
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Size = New System.Drawing.Size(37, 13)
        Me.lblTicket.TabIndex = 14
        Me.lblTicket.Text = "Ticket"
        '
        'txtTicket
        '
        Me.txtTicket.BindearPropiedadControl = Nothing
        Me.txtTicket.BindearPropiedadEntidad = Nothing
        Me.txtTicket.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTicket.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTicket.Formato = "N2"
        Me.txtTicket.IsDecimal = True
        Me.txtTicket.IsNumber = True
        Me.txtTicket.IsPK = False
        Me.txtTicket.IsRequired = False
        Me.txtTicket.Key = ""
        Me.txtTicket.LabelAsoc = Me.lblTicket
        Me.txtTicket.Location = New System.Drawing.Point(789, 12)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(100, 20)
        Me.txtTicket.TabIndex = 13
        Me.txtTicket.TabStop = False
        Me.txtTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SeleccionPlanesTarjetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 549)
        Me.Controls.Add(Me.lblTicket)
        Me.Controls.Add(Me.txtTicket)
        Me.Controls.Add(Me.lblCheque)
        Me.Controls.Add(Me.txtCheque)
        Me.Controls.Add(Me.lblTransferencia)
        Me.Controls.Add(Me.txtTransferencia)
        Me.Controls.Add(Me.lblImporteAnticipoSinInteres)
        Me.Controls.Add(Me.txtImporteAnticipoSinInteres)
        Me.Controls.Add(Me.lblPendiente)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.lblImporteTotalSinInterses)
        Me.Controls.Add(Me.txtPendiente)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.txtImporteTotalSinInterses)
        Me.Controls.Add(Me.ugPlanesTarjetas)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "SeleccionPlanesTarjetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planes de tarjetas"
        CType(Me.ugPlanesTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
	Protected WithEvents btnAceptar As System.Windows.Forms.Button
	Protected WithEvents btnCancelar As System.Windows.Forms.Button
	Friend WithEvents ugPlanesTarjetas As Infragistics.Win.UltraWinGrid.UltraGrid
	Friend WithEvents lblImporteTotalSinInterses As Eniac.Controles.Label
	Friend WithEvents txtPendiente As Eniac.Controles.TextBox
	Friend WithEvents lblPendiente As Eniac.Controles.Label
	Friend WithEvents txtEfectivo As Eniac.Controles.TextBox
	Friend WithEvents lblEfectivo As Eniac.Controles.Label
	Friend WithEvents txtImporteTotalSinInterses As Eniac.Controles.TextBox
	Friend WithEvents lblImporteAnticipoSinInteres As Eniac.Controles.Label
	Friend WithEvents txtImporteAnticipoSinInteres As Eniac.Controles.TextBox
	Friend WithEvents lblTransferencia As Controles.Label
	Friend WithEvents txtTransferencia As Controles.TextBox
	Friend WithEvents lblCheque As Controles.Label
	Friend WithEvents txtCheque As Controles.TextBox
	Friend WithEvents lblTicket As Controles.Label
	Friend WithEvents txtTicket As Controles.TextBox
End Class
