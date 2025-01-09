<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TurnosDetalle
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TurnosDetalle))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroSesion")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorFluencia")
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmbarcacion")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoEmbarcacion")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmbarcacion")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipo")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Situacion")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dtpHoraHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHoraHasta = New Eniac.Controles.Label()
        Me.dtpHoraDesde = New Eniac.Controles.DateTimePicker()
        Me.lblHoraDesde = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblObservaciones = New Eniac.Controles.Label()
        Me.chbEfectivo = New Eniac.Controles.CheckBox()
        Me.lblTipoTurno = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.txtDescRecGralPorc = New Eniac.Controles.TextBox()
        Me.lblDescRecGralPorc = New Eniac.Controles.Label()
        Me.lblPrecio = New Eniac.Controles.Label()
        Me.txtPrecio = New Eniac.Controles.TextBox()
        Me.txtPrecioNeto = New Eniac.Controles.TextBox()
        Me.lblPrecioNeto = New Eniac.Controles.Label()
        Me.lblDescRecPorc2 = New Eniac.Controles.Label()
        Me.lblDescRecPorc1 = New Eniac.Controles.Label()
        Me.txtDescRecPorc1 = New Eniac.Controles.TextBox()
        Me.txtDescRecPorc2 = New Eniac.Controles.TextBox()
        Me.txtPrecioLista = New Eniac.Controles.TextBox()
        Me.txtSesion = New Eniac.Controles.TextBox()
        Me.lblSesion = New Eniac.Controles.Label()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.bscCodigoZona = New Eniac.Controles.Buscador2()
        Me.bscZonas = New Eniac.Controles.Buscador2()
        Me.Label1 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.ugProductoZonas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtNroSesion = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.pnlProductoZona = New System.Windows.Forms.Panel()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtFluencia = New Eniac.Controles.TextBox()
        Me.Label5 = New Eniac.Controles.Label()
        Me.ugEmbarcaciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEmbarcaciones = New System.Windows.Forms.Panel()
        Me.pnlEmbarcacionesBotado = New System.Windows.Forms.Panel()
        Me.txtCantidadPasajeros = New Eniac.Controles.TextBox()
        Me.lblCantidadPasajeros = New Eniac.Controles.Label()
        Me.cmbDestinos = New Eniac.Controles.ComboBox()
        Me.lblDestino = New Eniac.Controles.Label()
        Me.txtDestinoLibre = New Eniac.Controles.TextBox()
        Me.dtpFechaHoraLlegada = New Eniac.Controles.DateTimePicker()
        Me.lblFechaHoraLlegada = New Eniac.Controles.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlDatosTurno = New System.Windows.Forms.Panel()
        Me.cmbEstadosTurnos = New Eniac.Controles.ComboBox()
        Me.cmbTipoTurno = New Eniac.Controles.ComboBox()
        Me.pnlSolicitaVehiculo = New System.Windows.Forms.Panel()
        Me.LnkABMVehiculo = New Eniac.Controles.LinkLabel()
        Me.Label6 = New Eniac.Controles.Label()
        Me.txtModeloVehiculo = New Eniac.Controles.TextBox()
        Me.txtMarcaVehiculo = New Eniac.Controles.TextBox()
        Me.bscCodigoVehiculo = New Eniac.Controles.Buscador2()
        Me.flpTurnos = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlClienteTurno = New System.Windows.Forms.Panel()
        Me.lnkCliente = New Eniac.Controles.LinkLabel()
        CType(Me.ugProductoZonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProductoZona.SuspendLayout()
        CType(Me.ugEmbarcaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmbarcaciones.SuspendLayout()
        Me.pnlEmbarcacionesBotado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDatosTurno.SuspendLayout()
        Me.pnlSolicitaVehiculo.SuspendLayout()
        Me.flpTurnos.SuspendLayout()
        Me.pnlClienteTurno.SuspendLayout()
        Me.SuspendLayout()
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
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
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(63, 21)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(112, 20)
        Me.bscCodigoCliente.TabIndex = 1
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(60, 5)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 2
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(182, 20)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(320, 23)
        Me.bscCliente.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(179, 5)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 4
        Me.lblNombre.Text = "&Nombre"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(813, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 32
        Me.btnAceptar.Text = "&Aceptar"
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
        Me.btnCancelar.Location = New System.Drawing.Point(899, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 33
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dtpHoraHasta
        '
        Me.dtpHoraHasta.BindearPropiedadControl = ""
        Me.dtpHoraHasta.BindearPropiedadEntidad = ""
        Me.dtpHoraHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHoraHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHoraHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraHasta.IsPK = False
        Me.dtpHoraHasta.IsRequired = False
        Me.dtpHoraHasta.Key = ""
        Me.dtpHoraHasta.LabelAsoc = Me.lblHoraHasta
        Me.dtpHoraHasta.Location = New System.Drawing.Point(285, 3)
        Me.dtpHoraHasta.Name = "dtpHoraHasta"
        Me.dtpHoraHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHoraHasta.TabIndex = 3
        '
        'lblHoraHasta
        '
        Me.lblHoraHasta.AutoSize = True
        Me.lblHoraHasta.LabelAsoc = Nothing
        Me.lblHoraHasta.Location = New System.Drawing.Point(240, 7)
        Me.lblHoraHasta.Name = "lblHoraHasta"
        Me.lblHoraHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHoraHasta.TabIndex = 2
        Me.lblHoraHasta.Text = "Hasta"
        '
        'dtpHoraDesde
        '
        Me.dtpHoraDesde.BindearPropiedadControl = ""
        Me.dtpHoraDesde.BindearPropiedadEntidad = ""
        Me.dtpHoraDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHoraDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHoraDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraDesde.IsPK = False
        Me.dtpHoraDesde.IsRequired = False
        Me.dtpHoraDesde.Key = ""
        Me.dtpHoraDesde.LabelAsoc = Me.lblHoraDesde
        Me.dtpHoraDesde.Location = New System.Drawing.Point(85, 3)
        Me.dtpHoraDesde.Name = "dtpHoraDesde"
        Me.dtpHoraDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpHoraDesde.TabIndex = 1
        '
        'lblHoraDesde
        '
        Me.lblHoraDesde.AutoSize = True
        Me.lblHoraDesde.LabelAsoc = Nothing
        Me.lblHoraDesde.Location = New System.Drawing.Point(2, 7)
        Me.lblHoraDesde.Name = "lblHoraDesde"
        Me.lblHoraDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblHoraDesde.TabIndex = 0
        Me.lblHoraDesde.Text = "Desde"
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
        Me.txtObservacion.LabelAsoc = Me.lblObservaciones
        Me.txtObservacion.Location = New System.Drawing.Point(85, 56)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(414, 20)
        Me.txtObservacion.TabIndex = 10
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.LabelAsoc = Nothing
        Me.lblObservaciones.Location = New System.Drawing.Point(2, 59)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 9
        Me.lblObservaciones.Text = "Observaciones"
        '
        'chbEfectivo
        '
        Me.chbEfectivo.AutoSize = True
        Me.chbEfectivo.BindearPropiedadControl = ""
        Me.chbEfectivo.BindearPropiedadEntidad = ""
        Me.chbEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEfectivo.IsPK = False
        Me.chbEfectivo.IsRequired = False
        Me.chbEfectivo.Key = Nothing
        Me.chbEfectivo.LabelAsoc = Nothing
        Me.chbEfectivo.Location = New System.Drawing.Point(429, 31)
        Me.chbEfectivo.Name = "chbEfectivo"
        Me.chbEfectivo.Size = New System.Drawing.Size(65, 17)
        Me.chbEfectivo.TabIndex = 8
        Me.chbEfectivo.Text = "Efectivo"
        Me.chbEfectivo.UseVisualStyleBackColor = True
        Me.chbEfectivo.Visible = False
        '
        'lblTipoTurno
        '
        Me.lblTipoTurno.AutoSize = True
        Me.lblTipoTurno.LabelAsoc = Nothing
        Me.lblTipoTurno.Location = New System.Drawing.Point(2, 33)
        Me.lblTipoTurno.Name = "lblTipoTurno"
        Me.lblTipoTurno.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoTurno.TabIndex = 4
        Me.lblTipoTurno.Text = "Tipo"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(211, 82)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(288, 20)
        Me.bscProducto2.TabIndex = 13
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = ""
        Me.bscCodigoProducto2.BindearPropiedadEntidad = ""
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(85, 82)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(123, 20)
        Me.bscCodigoProducto2.TabIndex = 12
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(2, 84)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 11
        Me.chbProducto.Text = "Producto"
        '
        'txtDescRecGralPorc
        '
        Me.txtDescRecGralPorc.BindearPropiedadControl = ""
        Me.txtDescRecGralPorc.BindearPropiedadEntidad = ""
        Me.txtDescRecGralPorc.Enabled = False
        Me.txtDescRecGralPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescRecGralPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescRecGralPorc.Formato = "N2"
        Me.txtDescRecGralPorc.IsDecimal = True
        Me.txtDescRecGralPorc.IsNumber = True
        Me.txtDescRecGralPorc.IsPK = False
        Me.txtDescRecGralPorc.IsRequired = False
        Me.txtDescRecGralPorc.Key = ""
        Me.txtDescRecGralPorc.LabelAsoc = Me.lblDescRecGralPorc
        Me.txtDescRecGralPorc.Location = New System.Drawing.Point(85, 134)
        Me.txtDescRecGralPorc.MaxLength = 6
        Me.txtDescRecGralPorc.Name = "txtDescRecGralPorc"
        Me.txtDescRecGralPorc.Size = New System.Drawing.Size(59, 20)
        Me.txtDescRecGralPorc.TabIndex = 18
        Me.txtDescRecGralPorc.Text = "0.00"
        Me.txtDescRecGralPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescRecGralPorc
        '
        Me.lblDescRecGralPorc.AutoSize = True
        Me.lblDescRecGralPorc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDescRecGralPorc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescRecGralPorc.LabelAsoc = Nothing
        Me.lblDescRecGralPorc.Location = New System.Drawing.Point(2, 137)
        Me.lblDescRecGralPorc.Name = "lblDescRecGralPorc"
        Me.lblDescRecGralPorc.Size = New System.Drawing.Size(61, 13)
        Me.lblDescRecGralPorc.TabIndex = 17
        Me.lblDescRecGralPorc.Text = "% D/R Gral"
        Me.lblDescRecGralPorc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecio.LabelAsoc = Nothing
        Me.lblPrecio.Location = New System.Drawing.Point(2, 111)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 14
        Me.lblPrecio.Text = "Precio"
        '
        'txtPrecio
        '
        Me.txtPrecio.BindearPropiedadControl = ""
        Me.txtPrecio.BindearPropiedadEntidad = ""
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecio.Formato = "##0.00"
        Me.txtPrecio.IsDecimal = True
        Me.txtPrecio.IsNumber = True
        Me.txtPrecio.IsPK = False
        Me.txtPrecio.IsRequired = False
        Me.txtPrecio.Key = ""
        Me.txtPrecio.LabelAsoc = Me.lblPrecio
        Me.txtPrecio.Location = New System.Drawing.Point(85, 108)
        Me.txtPrecio.MaxLength = 15
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(80, 20)
        Me.txtPrecio.TabIndex = 15
        Me.txtPrecio.Text = "0.00"
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioNeto
        '
        Me.txtPrecioNeto.BindearPropiedadControl = ""
        Me.txtPrecioNeto.BindearPropiedadEntidad = ""
        Me.txtPrecioNeto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioNeto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioNeto.Formato = "##0.00"
        Me.txtPrecioNeto.IsDecimal = True
        Me.txtPrecioNeto.IsNumber = True
        Me.txtPrecioNeto.IsPK = False
        Me.txtPrecioNeto.IsRequired = False
        Me.txtPrecioNeto.Key = ""
        Me.txtPrecioNeto.LabelAsoc = Me.lblPrecioNeto
        Me.txtPrecioNeto.Location = New System.Drawing.Point(85, 160)
        Me.txtPrecioNeto.MaxLength = 15
        Me.txtPrecioNeto.Name = "txtPrecioNeto"
        Me.txtPrecioNeto.ReadOnly = True
        Me.txtPrecioNeto.Size = New System.Drawing.Size(80, 20)
        Me.txtPrecioNeto.TabIndex = 24
        Me.txtPrecioNeto.Text = "0.00"
        Me.txtPrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioNeto
        '
        Me.lblPrecioNeto.AutoSize = True
        Me.lblPrecioNeto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioNeto.LabelAsoc = Nothing
        Me.lblPrecioNeto.Location = New System.Drawing.Point(2, 163)
        Me.lblPrecioNeto.Name = "lblPrecioNeto"
        Me.lblPrecioNeto.Size = New System.Drawing.Size(63, 13)
        Me.lblPrecioNeto.TabIndex = 23
        Me.lblPrecioNeto.Text = "Precio Neto"
        '
        'lblDescRecPorc2
        '
        Me.lblDescRecPorc2.AutoSize = True
        Me.lblDescRecPorc2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescRecPorc2.LabelAsoc = Nothing
        Me.lblDescRecPorc2.Location = New System.Drawing.Point(269, 137)
        Me.lblDescRecPorc2.Name = "lblDescRecPorc2"
        Me.lblDescRecPorc2.Size = New System.Drawing.Size(48, 13)
        Me.lblDescRecPorc2.TabIndex = 21
        Me.lblDescRecPorc2.Text = "% D/R 2"
        '
        'lblDescRecPorc1
        '
        Me.lblDescRecPorc1.AutoSize = True
        Me.lblDescRecPorc1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescRecPorc1.LabelAsoc = Nothing
        Me.lblDescRecPorc1.Location = New System.Drawing.Point(150, 137)
        Me.lblDescRecPorc1.Name = "lblDescRecPorc1"
        Me.lblDescRecPorc1.Size = New System.Drawing.Size(48, 13)
        Me.lblDescRecPorc1.TabIndex = 19
        Me.lblDescRecPorc1.Text = "% D/R 1"
        '
        'txtDescRecPorc1
        '
        Me.txtDescRecPorc1.BindearPropiedadControl = ""
        Me.txtDescRecPorc1.BindearPropiedadEntidad = ""
        Me.txtDescRecPorc1.Enabled = False
        Me.txtDescRecPorc1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescRecPorc1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescRecPorc1.Formato = "N2"
        Me.txtDescRecPorc1.IsDecimal = True
        Me.txtDescRecPorc1.IsNumber = True
        Me.txtDescRecPorc1.IsPK = False
        Me.txtDescRecPorc1.IsRequired = False
        Me.txtDescRecPorc1.Key = ""
        Me.txtDescRecPorc1.LabelAsoc = Me.lblDescRecPorc1
        Me.txtDescRecPorc1.Location = New System.Drawing.Point(204, 134)
        Me.txtDescRecPorc1.MaxLength = 10
        Me.txtDescRecPorc1.Name = "txtDescRecPorc1"
        Me.txtDescRecPorc1.Size = New System.Drawing.Size(59, 20)
        Me.txtDescRecPorc1.TabIndex = 20
        Me.txtDescRecPorc1.Text = "0.00"
        Me.txtDescRecPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescRecPorc2
        '
        Me.txtDescRecPorc2.BindearPropiedadControl = ""
        Me.txtDescRecPorc2.BindearPropiedadEntidad = ""
        Me.txtDescRecPorc2.Enabled = False
        Me.txtDescRecPorc2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescRecPorc2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescRecPorc2.Formato = "N2"
        Me.txtDescRecPorc2.IsDecimal = True
        Me.txtDescRecPorc2.IsNumber = True
        Me.txtDescRecPorc2.IsPK = False
        Me.txtDescRecPorc2.IsRequired = False
        Me.txtDescRecPorc2.Key = ""
        Me.txtDescRecPorc2.LabelAsoc = Me.lblDescRecPorc2
        Me.txtDescRecPorc2.Location = New System.Drawing.Point(323, 134)
        Me.txtDescRecPorc2.MaxLength = 10
        Me.txtDescRecPorc2.Name = "txtDescRecPorc2"
        Me.txtDescRecPorc2.Size = New System.Drawing.Size(59, 20)
        Me.txtDescRecPorc2.TabIndex = 22
        Me.txtDescRecPorc2.Text = "0.00"
        Me.txtDescRecPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioLista
        '
        Me.txtPrecioLista.BindearPropiedadControl = ""
        Me.txtPrecioLista.BindearPropiedadEntidad = ""
        Me.txtPrecioLista.Enabled = False
        Me.txtPrecioLista.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioLista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioLista.Formato = "##0.00"
        Me.txtPrecioLista.IsDecimal = True
        Me.txtPrecioLista.IsNumber = True
        Me.txtPrecioLista.IsPK = False
        Me.txtPrecioLista.IsRequired = False
        Me.txtPrecioLista.Key = ""
        Me.txtPrecioLista.LabelAsoc = Nothing
        Me.txtPrecioLista.Location = New System.Drawing.Point(204, 108)
        Me.txtPrecioLista.MaxLength = 15
        Me.txtPrecioLista.Name = "txtPrecioLista"
        Me.txtPrecioLista.Size = New System.Drawing.Size(80, 20)
        Me.txtPrecioLista.TabIndex = 16
        Me.txtPrecioLista.Text = "0.00"
        Me.txtPrecioLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPrecioLista.Visible = False
        '
        'txtSesion
        '
        Me.txtSesion.BindearPropiedadControl = ""
        Me.txtSesion.BindearPropiedadEntidad = ""
        Me.txtSesion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSesion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSesion.Formato = ""
        Me.txtSesion.IsDecimal = False
        Me.txtSesion.IsNumber = True
        Me.txtSesion.IsPK = False
        Me.txtSesion.IsRequired = False
        Me.txtSesion.Key = ""
        Me.txtSesion.LabelAsoc = Me.lblSesion
        Me.txtSesion.Location = New System.Drawing.Point(277, 160)
        Me.txtSesion.MaxLength = 15
        Me.txtSesion.Name = "txtSesion"
        Me.txtSesion.Size = New System.Drawing.Size(76, 20)
        Me.txtSesion.TabIndex = 26
        Me.txtSesion.Text = "0"
        Me.txtSesion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSesion
        '
        Me.lblSesion.AutoSize = True
        Me.lblSesion.LabelAsoc = Nothing
        Me.lblSesion.Location = New System.Drawing.Point(184, 163)
        Me.lblSesion.Name = "lblSesion"
        Me.lblSesion.Size = New System.Drawing.Size(79, 13)
        Me.lblSesion.TabIndex = 25
        Me.lblSesion.Text = "Número Sesión"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminar.Location = New System.Drawing.Point(462, 87)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'bscCodigoZona
        '
        Me.bscCodigoZona.ActivarFiltroEnGrilla = True
        Me.bscCodigoZona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoZona.BindearPropiedadControl = ""
        Me.bscCodigoZona.BindearPropiedadEntidad = ""
        Me.bscCodigoZona.ConfigBuscador = Nothing
        Me.bscCodigoZona.Datos = Nothing
        Me.bscCodigoZona.FilaDevuelta = Nothing
        Me.bscCodigoZona.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoZona.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoZona.IsDecimal = False
        Me.bscCodigoZona.IsNumber = False
        Me.bscCodigoZona.IsPK = False
        Me.bscCodigoZona.IsRequired = False
        Me.bscCodigoZona.Key = ""
        Me.bscCodigoZona.LabelAsoc = Nothing
        Me.bscCodigoZona.Location = New System.Drawing.Point(7, 18)
        Me.bscCodigoZona.MaxLengh = "32767"
        Me.bscCodigoZona.Name = "bscCodigoZona"
        Me.bscCodigoZona.Permitido = True
        Me.bscCodigoZona.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoZona.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoZona.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoZona.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoZona.Selecciono = False
        Me.bscCodigoZona.Size = New System.Drawing.Size(100, 20)
        Me.bscCodigoZona.TabIndex = 1
        '
        'bscZonas
        '
        Me.bscZonas.ActivarFiltroEnGrilla = True
        Me.bscZonas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscZonas.BindearPropiedadControl = Nothing
        Me.bscZonas.BindearPropiedadEntidad = Nothing
        Me.bscZonas.ConfigBuscador = Nothing
        Me.bscZonas.Datos = Nothing
        Me.bscZonas.FilaDevuelta = Nothing
        Me.bscZonas.ForeColorFocus = System.Drawing.Color.Red
        Me.bscZonas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscZonas.IsDecimal = False
        Me.bscZonas.IsNumber = False
        Me.bscZonas.IsPK = False
        Me.bscZonas.IsRequired = False
        Me.bscZonas.Key = ""
        Me.bscZonas.LabelAsoc = Nothing
        Me.bscZonas.Location = New System.Drawing.Point(117, 18)
        Me.bscZonas.MaxLengh = "32767"
        Me.bscZonas.Name = "bscZonas"
        Me.bscZonas.Permitido = True
        Me.bscZonas.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscZonas.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscZonas.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscZonas.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscZonas.Selecciono = False
        Me.bscZonas.Size = New System.Drawing.Size(254, 20)
        Me.bscZonas.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(4, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(114, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Zona"
        '
        'ugProductoZonas
        '
        Me.ugProductoZonas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductoZonas.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance2
        UltraGridColumn8.Header.Caption = "Codigo"
        UltraGridColumn8.Header.VisiblePosition = 0
        UltraGridColumn8.Width = 50
        UltraGridColumn9.Header.Caption = "Zona"
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn9.Width = 234
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance3
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn10.FilterCellAppearance = Appearance4
        UltraGridColumn10.Format = "N0"
        UltraGridColumn10.Header.Caption = "Sesion"
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.Width = 70
        UltraGridColumn4.Header.Caption = "Fluencia"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 70
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn4})
        Me.ugProductoZonas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugProductoZonas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductoZonas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductoZonas.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductoZonas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugProductoZonas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductoZonas.DisplayLayout.GroupByBox.Hidden = True
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductoZonas.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugProductoZonas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductoZonas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductoZonas.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductoZonas.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugProductoZonas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductoZonas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductoZonas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductoZonas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductoZonas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductoZonas.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductoZonas.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugProductoZonas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugProductoZonas.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductoZonas.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugProductoZonas.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugProductoZonas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductoZonas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugProductoZonas.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugProductoZonas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductoZonas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugProductoZonas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductoZonas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductoZonas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductoZonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugProductoZonas.Location = New System.Drawing.Point(7, 44)
        Me.ugProductoZonas.Name = "ugProductoZonas"
        Me.ugProductoZonas.Size = New System.Drawing.Size(449, 159)
        Me.ugProductoZonas.TabIndex = 10
        Me.ugProductoZonas.Text = "UltraGrid1"
        '
        'txtNroSesion
        '
        Me.txtNroSesion.BindearPropiedadControl = ""
        Me.txtNroSesion.BindearPropiedadEntidad = ""
        Me.txtNroSesion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroSesion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroSesion.Formato = ""
        Me.txtNroSesion.IsDecimal = False
        Me.txtNroSesion.IsNumber = True
        Me.txtNroSesion.IsPK = False
        Me.txtNroSesion.IsRequired = False
        Me.txtNroSesion.Key = ""
        Me.txtNroSesion.LabelAsoc = Me.Label3
        Me.txtNroSesion.Location = New System.Drawing.Point(390, 18)
        Me.txtNroSesion.MaxLength = 3
        Me.txtNroSesion.Name = "txtNroSesion"
        Me.txtNroSesion.Size = New System.Drawing.Size(50, 20)
        Me.txtNroSesion.TabIndex = 5
        Me.txtNroSesion.Text = "0"
        Me.txtNroSesion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(387, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "No Sesión"
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.Location = New System.Drawing.Point(460, 43)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertar.TabIndex = 8
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'pnlProductoZona
        '
        Me.pnlProductoZona.Controls.Add(Me.Label4)
        Me.pnlProductoZona.Controls.Add(Me.txtFluencia)
        Me.pnlProductoZona.Controls.Add(Me.bscZonas)
        Me.pnlProductoZona.Controls.Add(Me.btnInsertar)
        Me.pnlProductoZona.Controls.Add(Me.btnEliminar)
        Me.pnlProductoZona.Controls.Add(Me.Label3)
        Me.pnlProductoZona.Controls.Add(Me.bscCodigoZona)
        Me.pnlProductoZona.Controls.Add(Me.txtNroSesion)
        Me.pnlProductoZona.Controls.Add(Me.Label1)
        Me.pnlProductoZona.Controls.Add(Me.ugProductoZonas)
        Me.pnlProductoZona.Controls.Add(Me.Label2)
        Me.pnlProductoZona.Location = New System.Drawing.Point(3, 284)
        Me.pnlProductoZona.Name = "pnlProductoZona"
        Me.pnlProductoZona.Size = New System.Drawing.Size(502, 210)
        Me.pnlProductoZona.TabIndex = 3
        Me.pnlProductoZona.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(444, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fluencia"
        '
        'txtFluencia
        '
        Me.txtFluencia.BindearPropiedadControl = ""
        Me.txtFluencia.BindearPropiedadEntidad = ""
        Me.txtFluencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFluencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFluencia.Formato = ""
        Me.txtFluencia.IsDecimal = False
        Me.txtFluencia.IsNumber = True
        Me.txtFluencia.IsPK = False
        Me.txtFluencia.IsRequired = False
        Me.txtFluencia.Key = ""
        Me.txtFluencia.LabelAsoc = Me.Label4
        Me.txtFluencia.Location = New System.Drawing.Point(447, 18)
        Me.txtFluencia.MaxLength = 3
        Me.txtFluencia.Name = "txtFluencia"
        Me.txtFluencia.Size = New System.Drawing.Size(50, 20)
        Me.txtFluencia.TabIndex = 7
        Me.txtFluencia.Text = "0"
        Me.txtFluencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(240, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Estado"
        '
        'ugEmbarcaciones
        '
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugEmbarcaciones.DisplayLayout.Appearance = Appearance16
        Me.ugEmbarcaciones.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance17
        UltraGridColumn2.Header.Caption = "Código"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 70
        UltraGridColumn3.Header.Caption = "Embarcación"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 155
        UltraGridColumn6.Header.Caption = "Tipo"
        UltraGridColumn6.Header.VisiblePosition = 3
        UltraGridColumn6.Width = 85
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn7.Width = 66
        UltraGridColumn5.Header.Caption = "Situación"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 77
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn6, UltraGridColumn7, UltraGridColumn5})
        Me.ugEmbarcaciones.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugEmbarcaciones.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEmbarcaciones.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEmbarcaciones.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.ugEmbarcaciones.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEmbarcaciones.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.ugEmbarcaciones.DisplayLayout.MaxColScrollRegions = 1
        Me.ugEmbarcaciones.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugEmbarcaciones.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.SystemColors.Highlight
        Appearance22.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugEmbarcaciones.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.ugEmbarcaciones.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugEmbarcaciones.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugEmbarcaciones.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.ugEmbarcaciones.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugEmbarcaciones.DisplayLayout.Override.CellAppearance = Appearance24
        Me.ugEmbarcaciones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugEmbarcaciones.DisplayLayout.Override.CellPadding = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEmbarcaciones.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Appearance26.TextHAlignAsString = "Left"
        Me.ugEmbarcaciones.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.ugEmbarcaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugEmbarcaciones.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.ugEmbarcaciones.DisplayLayout.Override.RowAppearance = Appearance27
        Me.ugEmbarcaciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugEmbarcaciones.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.ugEmbarcaciones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugEmbarcaciones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugEmbarcaciones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugEmbarcaciones.Location = New System.Drawing.Point(0, 0)
        Me.ugEmbarcaciones.Name = "ugEmbarcaciones"
        Me.ugEmbarcaciones.Size = New System.Drawing.Size(455, 183)
        Me.ugEmbarcaciones.TabIndex = 0
        Me.ugEmbarcaciones.Text = "Embarcaciones"
        '
        'pnlEmbarcaciones
        '
        Me.pnlEmbarcaciones.Controls.Add(Me.pnlEmbarcacionesBotado)
        Me.pnlEmbarcaciones.Controls.Add(Me.ugEmbarcaciones)
        Me.pnlEmbarcaciones.Location = New System.Drawing.Point(521, 21)
        Me.pnlEmbarcaciones.Name = "pnlEmbarcaciones"
        Me.pnlEmbarcaciones.Size = New System.Drawing.Size(455, 269)
        Me.pnlEmbarcaciones.TabIndex = 31
        '
        'pnlEmbarcacionesBotado
        '
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.txtCantidadPasajeros)
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.cmbDestinos)
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.lblCantidadPasajeros)
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.txtDestinoLibre)
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.dtpFechaHoraLlegada)
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.lblDestino)
        Me.pnlEmbarcacionesBotado.Controls.Add(Me.lblFechaHoraLlegada)
        Me.pnlEmbarcacionesBotado.Location = New System.Drawing.Point(0, 184)
        Me.pnlEmbarcacionesBotado.Name = "pnlEmbarcacionesBotado"
        Me.pnlEmbarcacionesBotado.Size = New System.Drawing.Size(455, 82)
        Me.pnlEmbarcacionesBotado.TabIndex = 1
        '
        'txtCantidadPasajeros
        '
        Me.txtCantidadPasajeros.BindearPropiedadControl = Nothing
        Me.txtCantidadPasajeros.BindearPropiedadEntidad = Nothing
        Me.txtCantidadPasajeros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadPasajeros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadPasajeros.Formato = ""
        Me.txtCantidadPasajeros.IsDecimal = False
        Me.txtCantidadPasajeros.IsNumber = True
        Me.txtCantidadPasajeros.IsPK = False
        Me.txtCantidadPasajeros.IsRequired = False
        Me.txtCantidadPasajeros.Key = ""
        Me.txtCantidadPasajeros.LabelAsoc = Me.lblCantidadPasajeros
        Me.txtCantidadPasajeros.Location = New System.Drawing.Point(124, 3)
        Me.txtCantidadPasajeros.MaxLength = 4
        Me.txtCantidadPasajeros.Name = "txtCantidadPasajeros"
        Me.txtCantidadPasajeros.Size = New System.Drawing.Size(49, 20)
        Me.txtCantidadPasajeros.TabIndex = 1
        Me.txtCantidadPasajeros.Text = "1"
        Me.txtCantidadPasajeros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadPasajeros
        '
        Me.lblCantidadPasajeros.AutoSize = True
        Me.lblCantidadPasajeros.LabelAsoc = Nothing
        Me.lblCantidadPasajeros.Location = New System.Drawing.Point(6, 7)
        Me.lblCantidadPasajeros.Name = "lblCantidadPasajeros"
        Me.lblCantidadPasajeros.Size = New System.Drawing.Size(112, 13)
        Me.lblCantidadPasajeros.TabIndex = 0
        Me.lblCantidadPasajeros.Text = "Cantidad de pasajeros"
        '
        'cmbDestinos
        '
        Me.cmbDestinos.BindearPropiedadControl = Nothing
        Me.cmbDestinos.BindearPropiedadEntidad = Nothing
        Me.cmbDestinos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestinos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDestinos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDestinos.FormattingEnabled = True
        Me.cmbDestinos.IsPK = False
        Me.cmbDestinos.IsRequired = False
        Me.cmbDestinos.Key = Nothing
        Me.cmbDestinos.LabelAsoc = Me.lblDestino
        Me.cmbDestinos.Location = New System.Drawing.Point(124, 55)
        Me.cmbDestinos.Name = "cmbDestinos"
        Me.cmbDestinos.Size = New System.Drawing.Size(150, 21)
        Me.cmbDestinos.TabIndex = 5
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.LabelAsoc = Nothing
        Me.lblDestino.Location = New System.Drawing.Point(6, 59)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(43, 13)
        Me.lblDestino.TabIndex = 4
        Me.lblDestino.Text = "Destino"
        '
        'txtDestinoLibre
        '
        Me.txtDestinoLibre.BindearPropiedadControl = Nothing
        Me.txtDestinoLibre.BindearPropiedadEntidad = Nothing
        Me.txtDestinoLibre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDestinoLibre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDestinoLibre.Formato = ""
        Me.txtDestinoLibre.IsDecimal = False
        Me.txtDestinoLibre.IsNumber = False
        Me.txtDestinoLibre.IsPK = False
        Me.txtDestinoLibre.IsRequired = False
        Me.txtDestinoLibre.Key = ""
        Me.txtDestinoLibre.LabelAsoc = Me.lblDestino
        Me.txtDestinoLibre.Location = New System.Drawing.Point(280, 55)
        Me.txtDestinoLibre.MaxLength = 50
        Me.txtDestinoLibre.Name = "txtDestinoLibre"
        Me.txtDestinoLibre.Size = New System.Drawing.Size(170, 20)
        Me.txtDestinoLibre.TabIndex = 6
        '
        'dtpFechaHoraLlegada
        '
        Me.dtpFechaHoraLlegada.BindearPropiedadControl = Nothing
        Me.dtpFechaHoraLlegada.BindearPropiedadEntidad = Nothing
        Me.dtpFechaHoraLlegada.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaHoraLlegada.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaHoraLlegada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaHoraLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHoraLlegada.IsPK = False
        Me.dtpFechaHoraLlegada.IsRequired = False
        Me.dtpFechaHoraLlegada.Key = ""
        Me.dtpFechaHoraLlegada.LabelAsoc = Me.lblFechaHoraLlegada
        Me.dtpFechaHoraLlegada.Location = New System.Drawing.Point(124, 28)
        Me.dtpFechaHoraLlegada.Name = "dtpFechaHoraLlegada"
        Me.dtpFechaHoraLlegada.Size = New System.Drawing.Size(135, 20)
        Me.dtpFechaHoraLlegada.TabIndex = 3
        '
        'lblFechaHoraLlegada
        '
        Me.lblFechaHoraLlegada.AutoSize = True
        Me.lblFechaHoraLlegada.LabelAsoc = Nothing
        Me.lblFechaHoraLlegada.Location = New System.Drawing.Point(6, 32)
        Me.lblFechaHoraLlegada.Name = "lblFechaHoraLlegada"
        Me.lblFechaHoraLlegada.Size = New System.Drawing.Size(106, 13)
        Me.lblFechaHoraLlegada.TabIndex = 2
        Me.lblFechaHoraLlegada.Text = "Fecha y hora llegada"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 512)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(983, 35)
        Me.Panel1.TabIndex = 0
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(727, 2)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 30)
        Me.btnImprimir.TabIndex = 34
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        Me.btnImprimir.Visible = False
        '
        'pnlDatosTurno
        '
        Me.pnlDatosTurno.Controls.Add(Me.dtpHoraDesde)
        Me.pnlDatosTurno.Controls.Add(Me.lblHoraHasta)
        Me.pnlDatosTurno.Controls.Add(Me.lblHoraDesde)
        Me.pnlDatosTurno.Controls.Add(Me.cmbEstadosTurnos)
        Me.pnlDatosTurno.Controls.Add(Me.lblObservaciones)
        Me.pnlDatosTurno.Controls.Add(Me.Label5)
        Me.pnlDatosTurno.Controls.Add(Me.dtpHoraHasta)
        Me.pnlDatosTurno.Controls.Add(Me.txtObservacion)
        Me.pnlDatosTurno.Controls.Add(Me.lblSesion)
        Me.pnlDatosTurno.Controls.Add(Me.lblTipoTurno)
        Me.pnlDatosTurno.Controls.Add(Me.txtSesion)
        Me.pnlDatosTurno.Controls.Add(Me.cmbTipoTurno)
        Me.pnlDatosTurno.Controls.Add(Me.lblDescRecPorc2)
        Me.pnlDatosTurno.Controls.Add(Me.chbEfectivo)
        Me.pnlDatosTurno.Controls.Add(Me.lblDescRecPorc1)
        Me.pnlDatosTurno.Controls.Add(Me.chbProducto)
        Me.pnlDatosTurno.Controls.Add(Me.txtDescRecPorc1)
        Me.pnlDatosTurno.Controls.Add(Me.bscCodigoProducto2)
        Me.pnlDatosTurno.Controls.Add(Me.txtDescRecPorc2)
        Me.pnlDatosTurno.Controls.Add(Me.bscProducto2)
        Me.pnlDatosTurno.Controls.Add(Me.lblPrecioNeto)
        Me.pnlDatosTurno.Controls.Add(Me.lblDescRecGralPorc)
        Me.pnlDatosTurno.Controls.Add(Me.lblPrecio)
        Me.pnlDatosTurno.Controls.Add(Me.txtDescRecGralPorc)
        Me.pnlDatosTurno.Controls.Add(Me.txtPrecioNeto)
        Me.pnlDatosTurno.Controls.Add(Me.txtPrecio)
        Me.pnlDatosTurno.Controls.Add(Me.txtPrecioLista)
        Me.pnlDatosTurno.Location = New System.Drawing.Point(3, 87)
        Me.pnlDatosTurno.Name = "pnlDatosTurno"
        Me.pnlDatosTurno.Size = New System.Drawing.Size(506, 191)
        Me.pnlDatosTurno.TabIndex = 2
        '
        'cmbEstadosTurnos
        '
        Me.cmbEstadosTurnos.BindearPropiedadControl = ""
        Me.cmbEstadosTurnos.BindearPropiedadEntidad = ""
        Me.cmbEstadosTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosTurnos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosTurnos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosTurnos.FormattingEnabled = True
        Me.cmbEstadosTurnos.IsPK = False
        Me.cmbEstadosTurnos.IsRequired = False
        Me.cmbEstadosTurnos.Key = Nothing
        Me.cmbEstadosTurnos.LabelAsoc = Me.Label5
        Me.cmbEstadosTurnos.Location = New System.Drawing.Point(285, 29)
        Me.cmbEstadosTurnos.Name = "cmbEstadosTurnos"
        Me.cmbEstadosTurnos.Size = New System.Drawing.Size(125, 21)
        Me.cmbEstadosTurnos.TabIndex = 7
        '
        'cmbTipoTurno
        '
        Me.cmbTipoTurno.BindearPropiedadControl = ""
        Me.cmbTipoTurno.BindearPropiedadEntidad = ""
        Me.cmbTipoTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTurno.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoTurno.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoTurno.FormattingEnabled = True
        Me.cmbTipoTurno.IsPK = False
        Me.cmbTipoTurno.IsRequired = False
        Me.cmbTipoTurno.Key = Nothing
        Me.cmbTipoTurno.LabelAsoc = Me.lblTipoTurno
        Me.cmbTipoTurno.Location = New System.Drawing.Point(85, 29)
        Me.cmbTipoTurno.Name = "cmbTipoTurno"
        Me.cmbTipoTurno.Size = New System.Drawing.Size(122, 21)
        Me.cmbTipoTurno.TabIndex = 5
        '
        'pnlSolicitaVehiculo
        '
        Me.pnlSolicitaVehiculo.Controls.Add(Me.LnkABMVehiculo)
        Me.pnlSolicitaVehiculo.Controls.Add(Me.Label6)
        Me.pnlSolicitaVehiculo.Controls.Add(Me.txtModeloVehiculo)
        Me.pnlSolicitaVehiculo.Controls.Add(Me.txtMarcaVehiculo)
        Me.pnlSolicitaVehiculo.Controls.Add(Me.bscCodigoVehiculo)
        Me.pnlSolicitaVehiculo.Location = New System.Drawing.Point(3, 53)
        Me.pnlSolicitaVehiculo.Name = "pnlSolicitaVehiculo"
        Me.pnlSolicitaVehiculo.Size = New System.Drawing.Size(506, 28)
        Me.pnlSolicitaVehiculo.TabIndex = 1
        '
        'LnkABMVehiculo
        '
        Me.LnkABMVehiculo.AutoSize = True
        Me.LnkABMVehiculo.LabelAsoc = Nothing
        Me.LnkABMVehiculo.Location = New System.Drawing.Point(7, 7)
        Me.LnkABMVehiculo.Name = "LnkABMVehiculo"
        Me.LnkABMVehiculo.Size = New System.Drawing.Size(48, 13)
        Me.LnkABMVehiculo.TabIndex = 0
        Me.LnkABMVehiculo.TabStop = True
        Me.LnkABMVehiculo.Text = "Vehiculo"
        Me.LnkABMVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Vehiculo"
        '
        'txtModeloVehiculo
        '
        Me.txtModeloVehiculo.BindearPropiedadControl = Nothing
        Me.txtModeloVehiculo.BindearPropiedadEntidad = Nothing
        Me.txtModeloVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtModeloVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtModeloVehiculo.Formato = ""
        Me.txtModeloVehiculo.IsDecimal = False
        Me.txtModeloVehiculo.IsNumber = False
        Me.txtModeloVehiculo.IsPK = False
        Me.txtModeloVehiculo.IsRequired = False
        Me.txtModeloVehiculo.Key = ""
        Me.txtModeloVehiculo.LabelAsoc = Me.lblObservaciones
        Me.txtModeloVehiculo.Location = New System.Drawing.Point(357, 4)
        Me.txtModeloVehiculo.MaxLength = 100
        Me.txtModeloVehiculo.Name = "txtModeloVehiculo"
        Me.txtModeloVehiculo.ReadOnly = True
        Me.txtModeloVehiculo.Size = New System.Drawing.Size(142, 20)
        Me.txtModeloVehiculo.TabIndex = 3
        '
        'txtMarcaVehiculo
        '
        Me.txtMarcaVehiculo.BindearPropiedadControl = Nothing
        Me.txtMarcaVehiculo.BindearPropiedadEntidad = Nothing
        Me.txtMarcaVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMarcaVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMarcaVehiculo.Formato = ""
        Me.txtMarcaVehiculo.IsDecimal = False
        Me.txtMarcaVehiculo.IsNumber = False
        Me.txtMarcaVehiculo.IsPK = False
        Me.txtMarcaVehiculo.IsRequired = False
        Me.txtMarcaVehiculo.Key = ""
        Me.txtMarcaVehiculo.LabelAsoc = Me.lblObservaciones
        Me.txtMarcaVehiculo.Location = New System.Drawing.Point(213, 4)
        Me.txtMarcaVehiculo.MaxLength = 100
        Me.txtMarcaVehiculo.Name = "txtMarcaVehiculo"
        Me.txtMarcaVehiculo.ReadOnly = True
        Me.txtMarcaVehiculo.Size = New System.Drawing.Size(140, 20)
        Me.txtMarcaVehiculo.TabIndex = 2
        '
        'bscCodigoVehiculo
        '
        Me.bscCodigoVehiculo.ActivarFiltroEnGrilla = True
        Me.bscCodigoVehiculo.BindearPropiedadControl = ""
        Me.bscCodigoVehiculo.BindearPropiedadEntidad = ""
        Me.bscCodigoVehiculo.ConfigBuscador = Nothing
        Me.bscCodigoVehiculo.Datos = Nothing
        Me.bscCodigoVehiculo.FilaDevuelta = Nothing
        Me.bscCodigoVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoVehiculo.IsDecimal = False
        Me.bscCodigoVehiculo.IsNumber = False
        Me.bscCodigoVehiculo.IsPK = False
        Me.bscCodigoVehiculo.IsRequired = False
        Me.bscCodigoVehiculo.Key = ""
        Me.bscCodigoVehiculo.LabelAsoc = Nothing
        Me.bscCodigoVehiculo.Location = New System.Drawing.Point(62, 4)
        Me.bscCodigoVehiculo.MaxLengh = "32767"
        Me.bscCodigoVehiculo.Name = "bscCodigoVehiculo"
        Me.bscCodigoVehiculo.Permitido = True
        Me.bscCodigoVehiculo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoVehiculo.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculo.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoVehiculo.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoVehiculo.Selecciono = False
        Me.bscCodigoVehiculo.Size = New System.Drawing.Size(145, 20)
        Me.bscCodigoVehiculo.TabIndex = 1
        '
        'flpTurnos
        '
        Me.flpTurnos.Controls.Add(Me.pnlClienteTurno)
        Me.flpTurnos.Controls.Add(Me.pnlSolicitaVehiculo)
        Me.flpTurnos.Controls.Add(Me.pnlDatosTurno)
        Me.flpTurnos.Controls.Add(Me.pnlProductoZona)
        Me.flpTurnos.Location = New System.Drawing.Point(2, 2)
        Me.flpTurnos.Name = "flpTurnos"
        Me.flpTurnos.Size = New System.Drawing.Size(511, 504)
        Me.flpTurnos.TabIndex = 0
        '
        'pnlClienteTurno
        '
        Me.pnlClienteTurno.Controls.Add(Me.lnkCliente)
        Me.pnlClienteTurno.Controls.Add(Me.bscCliente)
        Me.pnlClienteTurno.Controls.Add(Me.lblNombre)
        Me.pnlClienteTurno.Controls.Add(Me.lblCodigoCliente)
        Me.pnlClienteTurno.Controls.Add(Me.bscCodigoCliente)
        Me.pnlClienteTurno.Location = New System.Drawing.Point(3, 3)
        Me.pnlClienteTurno.Name = "pnlClienteTurno"
        Me.pnlClienteTurno.Size = New System.Drawing.Size(506, 44)
        Me.pnlClienteTurno.TabIndex = 0
        '
        'lnkCliente
        '
        Me.lnkCliente.AutoSize = True
        Me.lnkCliente.LabelAsoc = Nothing
        Me.lnkCliente.Location = New System.Drawing.Point(8, 26)
        Me.lnkCliente.Name = "lnkCliente"
        Me.lnkCliente.Size = New System.Drawing.Size(39, 13)
        Me.lnkCliente.TabIndex = 0
        Me.lnkCliente.TabStop = True
        Me.lnkCliente.Text = "Cliente"
        Me.lnkCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TurnosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(983, 547)
        Me.Controls.Add(Me.flpTurnos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEmbarcaciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TurnosDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Turno"
        CType(Me.ugProductoZonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProductoZona.ResumeLayout(False)
        Me.pnlProductoZona.PerformLayout()
        CType(Me.ugEmbarcaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmbarcaciones.ResumeLayout(False)
        Me.pnlEmbarcacionesBotado.ResumeLayout(False)
        Me.pnlEmbarcacionesBotado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlDatosTurno.ResumeLayout(False)
        Me.pnlDatosTurno.PerformLayout()
        Me.pnlSolicitaVehiculo.ResumeLayout(False)
        Me.pnlSolicitaVehiculo.PerformLayout()
        Me.flpTurnos.ResumeLayout(False)
        Me.pnlClienteTurno.ResumeLayout(False)
        Me.pnlClienteTurno.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
   Protected WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Protected WithEvents lblCodigoCliente As Eniac.Controles.Label
   Protected WithEvents bscCliente As Eniac.Controles.Buscador2
   Protected WithEvents lblNombre As Eniac.Controles.Label
    Protected WithEvents dtpHoraHasta As Eniac.Controles.DateTimePicker
    Protected WithEvents lblHoraHasta As Eniac.Controles.Label
    Protected WithEvents dtpHoraDesde As Eniac.Controles.DateTimePicker
    Protected WithEvents lblHoraDesde As Eniac.Controles.Label
    Protected WithEvents txtObservacion As Eniac.Controles.TextBox
    Protected WithEvents lblObservaciones As Eniac.Controles.Label
    Protected WithEvents chbEfectivo As Eniac.Controles.CheckBox
    Protected WithEvents cmbTipoTurno As Eniac.Controles.ComboBox
    Protected WithEvents lblTipoTurno As Eniac.Controles.Label
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents chbProducto As Eniac.Controles.CheckBox
    Friend WithEvents txtDescRecGralPorc As Eniac.Controles.TextBox
    Friend WithEvents lblDescRecGralPorc As Eniac.Controles.Label
    Friend WithEvents lblPrecio As Eniac.Controles.Label
    Friend WithEvents txtPrecio As Eniac.Controles.TextBox
    Friend WithEvents txtPrecioNeto As Eniac.Controles.TextBox
    Friend WithEvents lblPrecioNeto As Eniac.Controles.Label
    Friend WithEvents lblDescRecPorc2 As Eniac.Controles.Label
    Friend WithEvents lblDescRecPorc1 As Eniac.Controles.Label
    Friend WithEvents txtDescRecPorc1 As Eniac.Controles.TextBox
    Friend WithEvents txtDescRecPorc2 As Eniac.Controles.TextBox
    Friend WithEvents txtPrecioLista As Eniac.Controles.TextBox
    Friend WithEvents txtSesion As Eniac.Controles.TextBox
    Protected WithEvents lblSesion As Eniac.Controles.Label
    Friend WithEvents btnEliminar As Eniac.Controles.Button
    Friend WithEvents bscCodigoZona As Eniac.Controles.Buscador2
    Friend WithEvents bscZonas As Eniac.Controles.Buscador2
    Protected WithEvents Label1 As Eniac.Controles.Label
    Protected WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents ugProductoZonas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtNroSesion As Eniac.Controles.TextBox
    Protected WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents btnInsertar As Eniac.Controles.Button
    Friend WithEvents pnlProductoZona As System.Windows.Forms.Panel
    Protected WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents txtFluencia As Eniac.Controles.TextBox
    Protected WithEvents cmbEstadosTurnos As Eniac.Controles.ComboBox
    Protected WithEvents Label5 As Eniac.Controles.Label
    Friend WithEvents ugEmbarcaciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlEmbarcaciones As System.Windows.Forms.Panel
    Friend WithEvents cmbDestinos As Eniac.Controles.ComboBox
    Friend WithEvents lblDestino As Eniac.Controles.Label
    Friend WithEvents txtDestinoLibre As Eniac.Controles.TextBox
    Friend WithEvents lblFechaHoraLlegada As Eniac.Controles.Label
    Friend WithEvents dtpFechaHoraLlegada As Eniac.Controles.DateTimePicker
    Friend WithEvents txtCantidadPasajeros As Eniac.Controles.TextBox
    Friend WithEvents lblCantidadPasajeros As Eniac.Controles.Label
    Friend WithEvents pnlEmbarcacionesBotado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosTurno As Panel
    Friend WithEvents pnlSolicitaVehiculo As Panel
    Friend WithEvents bscCodigoVehiculo As Controles.Buscador2
    Friend WithEvents flpTurnos As FlowLayoutPanel
    Friend WithEvents pnlClienteTurno As Panel
    Protected WithEvents txtModeloVehiculo As Controles.TextBox
    Protected WithEvents txtMarcaVehiculo As Controles.TextBox
    Protected WithEvents Label6 As Controles.Label
    Friend WithEvents LnkABMVehiculo As Controles.LinkLabel
    Protected WithEvents btnImprimir As Button
    Friend WithEvents lnkCliente As Controles.LinkLabel
End Class
