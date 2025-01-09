<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ingreso
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTurno")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCalendario")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaDesde")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaHasta")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observaciones")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoTurno")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoTurno", -1, "UltraDropDown1")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsEfectivo")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCalendario")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTurno")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoTurno", -1, "UltraDropDown1")
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
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoTurno")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoTurno")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("usuario")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("password")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idsucursal")
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
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTurno")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCalendario")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaDesde")
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaHasta")
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observaciones")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoTurno")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoTurno", -1, "UltraDropDown1")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsEfectivo")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCalendario")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoTurno")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoTurno", -1, "UltraDropDown1")
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ingreso))
      Me.grbSocio = New System.Windows.Forms.GroupBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCambiarTipoTurno = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.tlpEstado = New System.Windows.Forms.TableLayoutPanel()
      Me.picImagen = New System.Windows.Forms.PictureBox()
      Me.lblCertificado = New Eniac.Controles.Label()
      Me.ugTurnos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraDropDown1 = New Infragistics.Win.UltraWinGrid.UltraDropDown()
      Me.ugTurnosAnteriores = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbSocio.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.tlpEstado.SuspendLayout()
      CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugTurnos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UltraDropDown1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugTurnosAnteriores, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbSocio
      '
      Me.grbSocio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSocio.Controls.Add(Me.bscCodigoCliente)
      Me.grbSocio.Controls.Add(Me.bscCliente)
      Me.grbSocio.Controls.Add(Me.lblCodigoCliente)
      Me.grbSocio.Controls.Add(Me.lblNombre)
      Me.grbSocio.Controls.Add(Me.btnBuscar)
      Me.grbSocio.Location = New System.Drawing.Point(12, 32)
      Me.grbSocio.Name = "grbSocio"
      Me.grbSocio.Size = New System.Drawing.Size(826, 64)
      Me.grbSocio.TabIndex = 0
      Me.grbSocio.TabStop = False
      Me.grbSocio.Text = "Cliente"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.AutoSize = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblNombre
      Me.bscCodigoCliente.Location = New System.Drawing.Point(12, 32)
      Me.bscCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(118, 23)
      Me.bscCodigoCliente.TabIndex = 9
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(135, 18)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 7
      Me.lblNombre.Text = "&Nombre"
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
      Me.bscCliente.Location = New System.Drawing.Point(138, 32)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(464, 23)
      Me.bscCliente.TabIndex = 8
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(9, 18)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 5
      Me.lblCodigoCliente.Text = "Có&digo"
      '
      'btnBuscar
      '
      Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(718, 13)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(102, 45)
      Me.btnBuscar.TabIndex = 1
      Me.btnBuscar.Text = "Con&sultar"
      Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar.UseVisualStyleBackColor = True
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbCambiarTipoTurno, Me.ToolStripSeparator6, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(849, 29)
      Me.tstBarra.TabIndex = 5
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
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
      'tsbCambiarTipoTurno
      '
      Me.tsbCambiarTipoTurno.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
      Me.tsbCambiarTipoTurno.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCambiarTipoTurno.Name = "tsbCambiarTipoTurno"
      Me.tsbCambiarTipoTurno.Size = New System.Drawing.Size(122, 26)
      Me.tsbCambiarTipoTurno.Text = "&Confirmar Turno"
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      '
      'tlpEstado
      '
      Me.tlpEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tlpEstado.ColumnCount = 1
      Me.tlpEstado.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.tlpEstado.Controls.Add(Me.picImagen, 0, 0)
      Me.tlpEstado.Controls.Add(Me.lblCertificado, 0, 1)
      Me.tlpEstado.Location = New System.Drawing.Point(627, 102)
      Me.tlpEstado.Name = "tlpEstado"
      Me.tlpEstado.RowCount = 1
      Me.tlpEstado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.18343!))
      Me.tlpEstado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.81657!))
      Me.tlpEstado.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.tlpEstado.Size = New System.Drawing.Size(211, 371)
      Me.tlpEstado.TabIndex = 6
      '
      'picImagen
      '
      Me.picImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.picImagen.Dock = System.Windows.Forms.DockStyle.Fill
      Me.picImagen.InitialImage = Nothing
      Me.picImagen.Location = New System.Drawing.Point(3, 3)
      Me.picImagen.Name = "picImagen"
      Me.picImagen.Size = New System.Drawing.Size(205, 183)
      Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
      Me.picImagen.TabIndex = 1
      Me.picImagen.TabStop = False
      '
      'lblCertificado
      '
      Me.lblCertificado.AutoSize = True
      Me.lblCertificado.LabelAsoc = Nothing
      Me.lblCertificado.Location = New System.Drawing.Point(3, 189)
      Me.lblCertificado.Name = "lblCertificado"
      Me.lblCertificado.Size = New System.Drawing.Size(0, 13)
      Me.lblCertificado.TabIndex = 4
      '
      'ugTurnos
      '
      Me.ugTurnos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugTurnos.DisplayLayout.Appearance = Appearance1
      Me.ugTurnos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn19.Header.VisiblePosition = 0
      UltraGridColumn19.Hidden = True
      UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn20.Header.VisiblePosition = 1
      UltraGridColumn20.Hidden = True
      UltraGridColumn20.Width = 54
      UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn21.CellAppearance = Appearance2
      UltraGridColumn21.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn21.Header.Caption = "Desde"
      UltraGridColumn21.Header.VisiblePosition = 5
      UltraGridColumn21.MinWidth = 120
      UltraGridColumn21.Width = 147
      UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn22.CellAppearance = Appearance3
      UltraGridColumn22.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn22.Header.Caption = "Hasta"
      UltraGridColumn22.Header.VisiblePosition = 6
      UltraGridColumn22.MinWidth = 120
      UltraGridColumn22.Width = 155
      UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn23.CellAppearance = Appearance4
      UltraGridColumn23.Header.VisiblePosition = 7
      UltraGridColumn23.Hidden = True
      UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance5
      UltraGridColumn24.Header.Caption = "Código"
      UltraGridColumn24.Header.VisiblePosition = 8
      UltraGridColumn24.Hidden = True
      UltraGridColumn24.Width = 25
      UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn25.Header.Caption = "Cliente"
      UltraGridColumn25.Header.VisiblePosition = 9
      UltraGridColumn25.Hidden = True
      UltraGridColumn25.Width = 83
      UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn26.Header.VisiblePosition = 10
      UltraGridColumn26.Width = 116
      UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn27.Header.VisiblePosition = 11
      UltraGridColumn27.Hidden = True
      UltraGridColumn27.Width = 74
      UltraGridColumn28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
      UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn28.Header.Caption = "Tipo Turno"
      UltraGridColumn28.Header.VisiblePosition = 3
      UltraGridColumn28.Hidden = True
      UltraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
      UltraGridColumn28.Width = 29
      UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn29.Header.Caption = "Efectivo"
      UltraGridColumn29.Header.VisiblePosition = 12
      UltraGridColumn29.Hidden = True
      UltraGridColumn29.MinWidth = 55
      UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn29.Width = 67
      UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn30.Header.Caption = "Calendario"
      UltraGridColumn30.Header.VisiblePosition = 4
      UltraGridColumn30.Width = 107
      UltraGridColumn18.Header.VisiblePosition = 13
      UltraGridColumn18.Hidden = True
      UltraGridColumn18.Width = 72
      UltraGridColumn31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
      UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn31.Header.Caption = "Estado Turno"
      UltraGridColumn31.Header.VisiblePosition = 2
      UltraGridColumn31.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
      UltraGridColumn31.Width = 78
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn18, UltraGridColumn31})
      Me.ugTurnos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugTurnos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance6.BackColor = System.Drawing.Color.DarkSeaGreen
      Appearance6.BackColor2 = System.Drawing.Color.White
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Me.ugTurnos.DisplayLayout.CaptionAppearance = Appearance6
      Me.ugTurnos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
      Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance7.BorderColor = System.Drawing.SystemColors.Window
      Me.ugTurnos.DisplayLayout.GroupByBox.Appearance = Appearance7
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugTurnos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
      Me.ugTurnos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugTurnos.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
      Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance9.BackColor2 = System.Drawing.SystemColors.Control
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugTurnos.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
      Me.ugTurnos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugTurnos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance10.BackColor = System.Drawing.SystemColors.Window
      Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugTurnos.DisplayLayout.Override.ActiveCellAppearance = Appearance10
      Appearance11.BackColor = System.Drawing.SystemColors.Highlight
      Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugTurnos.DisplayLayout.Override.ActiveRowAppearance = Appearance11
      Me.ugTurnos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugTurnos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugTurnos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Me.ugTurnos.DisplayLayout.Override.CardAreaAppearance = Appearance12
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugTurnos.DisplayLayout.Override.CellAppearance = Appearance13
      Me.ugTurnos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugTurnos.DisplayLayout.Override.CellPadding = 0
      Appearance14.BackColor = System.Drawing.SystemColors.Control
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugTurnos.DisplayLayout.Override.GroupByRowAppearance = Appearance14
      Appearance15.TextHAlignAsString = "Left"
      Me.ugTurnos.DisplayLayout.Override.HeaderAppearance = Appearance15
      Me.ugTurnos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugTurnos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Me.ugTurnos.DisplayLayout.Override.RowAppearance = Appearance16
      Me.ugTurnos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugTurnos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugTurnos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugTurnos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugTurnos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugTurnos.Location = New System.Drawing.Point(15, 102)
      Me.ugTurnos.Name = "ugTurnos"
      Me.ugTurnos.Size = New System.Drawing.Size(605, 202)
      Me.ugTurnos.TabIndex = 14
      Me.ugTurnos.Text = "Turnos Pendientes"
      Me.ugTurnos.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
      '
      'UltraDropDown1
      '
      Appearance18.BackColor = System.Drawing.SystemColors.Window
      Appearance18.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.UltraDropDown1.DisplayLayout.Appearance = Appearance18
      UltraGridBand2.ColHeadersVisible = False
      UltraGridColumn13.Header.VisiblePosition = 0
      UltraGridColumn13.Hidden = True
      UltraGridColumn14.Header.Caption = ""
      UltraGridColumn14.Header.VisiblePosition = 1
      UltraGridColumn15.Header.VisiblePosition = 2
      UltraGridColumn15.Hidden = True
      UltraGridColumn16.Header.VisiblePosition = 3
      UltraGridColumn16.Hidden = True
      UltraGridColumn17.Header.VisiblePosition = 4
      UltraGridColumn17.Hidden = True
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
      Me.UltraDropDown1.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.UltraDropDown1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.UltraDropDown1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance19.BorderColor = System.Drawing.SystemColors.Window
      Me.UltraDropDown1.DisplayLayout.GroupByBox.Appearance = Appearance19
      Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
      Me.UltraDropDown1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
      Me.UltraDropDown1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance21.BackColor2 = System.Drawing.SystemColors.Control
      Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
      Me.UltraDropDown1.DisplayLayout.GroupByBox.PromptAppearance = Appearance21
      Me.UltraDropDown1.DisplayLayout.MaxColScrollRegions = 1
      Me.UltraDropDown1.DisplayLayout.MaxRowScrollRegions = 1
      Appearance22.BackColor = System.Drawing.SystemColors.Window
      Appearance22.ForeColor = System.Drawing.SystemColors.ControlText
      Me.UltraDropDown1.DisplayLayout.Override.ActiveCellAppearance = Appearance22
      Appearance23.BackColor = System.Drawing.SystemColors.Highlight
      Appearance23.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.UltraDropDown1.DisplayLayout.Override.ActiveRowAppearance = Appearance23
      Me.UltraDropDown1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.UltraDropDown1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance24.BackColor = System.Drawing.SystemColors.Window
      Me.UltraDropDown1.DisplayLayout.Override.CardAreaAppearance = Appearance24
      Appearance25.BorderColor = System.Drawing.Color.Silver
      Appearance25.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.UltraDropDown1.DisplayLayout.Override.CellAppearance = Appearance25
      Me.UltraDropDown1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.UltraDropDown1.DisplayLayout.Override.CellPadding = 0
      Appearance26.BackColor = System.Drawing.SystemColors.Control
      Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance26.BorderColor = System.Drawing.SystemColors.Window
      Me.UltraDropDown1.DisplayLayout.Override.GroupByRowAppearance = Appearance26
      Appearance27.TextHAlignAsString = "Left"
      Me.UltraDropDown1.DisplayLayout.Override.HeaderAppearance = Appearance27
      Me.UltraDropDown1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.UltraDropDown1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance28.BackColor = System.Drawing.SystemColors.Window
      Appearance28.BorderColor = System.Drawing.Color.Silver
      Me.UltraDropDown1.DisplayLayout.Override.RowAppearance = Appearance28
      Me.UltraDropDown1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
      Me.UltraDropDown1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
      Me.UltraDropDown1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.UltraDropDown1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.UltraDropDown1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.UltraDropDown1.Location = New System.Drawing.Point(18, 229)
      Me.UltraDropDown1.Name = "UltraDropDown1"
      Me.UltraDropDown1.Size = New System.Drawing.Size(93, 82)
      Me.UltraDropDown1.TabIndex = 15
      Me.UltraDropDown1.Text = "UltraDropDown1"
      Me.UltraDropDown1.Visible = False
      '
      'ugTurnosAnteriores
      '
      Me.ugTurnosAnteriores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance30.BackColor = System.Drawing.SystemColors.Window
      Appearance30.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugTurnosAnteriores.DisplayLayout.Appearance = Appearance30
      Me.ugTurnosAnteriores.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      UltraGridColumn2.Width = 14
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance31.TextHAlignAsString = "Center"
      UltraGridColumn3.CellAppearance = Appearance31
      UltraGridColumn3.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn3.Header.Caption = "Desde"
      UltraGridColumn3.Header.VisiblePosition = 5
      UltraGridColumn3.MinWidth = 120
      UltraGridColumn3.Width = 155
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance32.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance32
      UltraGridColumn4.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn4.Header.Caption = "Hasta"
      UltraGridColumn4.Header.VisiblePosition = 6
      UltraGridColumn4.MinWidth = 120
      UltraGridColumn4.Width = 153
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance33.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance33
      UltraGridColumn5.Header.VisiblePosition = 7
      UltraGridColumn5.Hidden = True
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance34.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance34
      UltraGridColumn6.Header.Caption = "Código"
      UltraGridColumn6.Header.VisiblePosition = 8
      UltraGridColumn6.Hidden = True
      UltraGridColumn6.Width = 25
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn7.Header.Caption = "Cliente"
      UltraGridColumn7.Header.VisiblePosition = 9
      UltraGridColumn7.Hidden = True
      UltraGridColumn7.Width = 83
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn8.Header.VisiblePosition = 10
      UltraGridColumn8.Width = 109
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn9.Header.VisiblePosition = 11
      UltraGridColumn9.Hidden = True
      UltraGridColumn9.Width = 74
      UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn10.Header.Caption = "Tipo Turno"
      UltraGridColumn10.Header.VisiblePosition = 2
      UltraGridColumn10.Hidden = True
      UltraGridColumn10.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
      UltraGridColumn10.Width = 26
      UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn11.Header.Caption = "Efectivo"
      UltraGridColumn11.Header.VisiblePosition = 12
      UltraGridColumn11.Hidden = True
      UltraGridColumn11.MinWidth = 55
      UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn11.Width = 67
      UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn12.Header.Caption = "Calendario"
      UltraGridColumn12.Header.VisiblePosition = 4
      UltraGridColumn12.Width = 107
      UltraGridColumn32.Header.VisiblePosition = 13
      UltraGridColumn32.Hidden = True
      UltraGridColumn32.Width = 84
      UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn33.Header.Caption = "Estado Turno"
      UltraGridColumn33.Header.VisiblePosition = 3
      UltraGridColumn33.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
      UltraGridColumn33.Width = 79
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn32, UltraGridColumn33})
      Me.ugTurnosAnteriores.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugTurnosAnteriores.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance35.BackColor = System.Drawing.Color.DarkSeaGreen
      Appearance35.BackColor2 = System.Drawing.Color.White
      Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Me.ugTurnosAnteriores.DisplayLayout.CaptionAppearance = Appearance35
      Appearance36.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance36.BorderColor = System.Drawing.SystemColors.Window
      Me.ugTurnosAnteriores.DisplayLayout.GroupByBox.Appearance = Appearance36
      Appearance37.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugTurnosAnteriores.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance37
      Me.ugTurnosAnteriores.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugTurnosAnteriores.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
      Appearance38.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance38.BackColor2 = System.Drawing.SystemColors.Control
      Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance38.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugTurnosAnteriores.DisplayLayout.GroupByBox.PromptAppearance = Appearance38
      Me.ugTurnosAnteriores.DisplayLayout.MaxColScrollRegions = 1
      Me.ugTurnosAnteriores.DisplayLayout.MaxRowScrollRegions = 1
      Appearance39.BackColor = System.Drawing.SystemColors.Window
      Appearance39.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugTurnosAnteriores.DisplayLayout.Override.ActiveCellAppearance = Appearance39
      Appearance40.BackColor = System.Drawing.SystemColors.Highlight
      Appearance40.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugTurnosAnteriores.DisplayLayout.Override.ActiveRowAppearance = Appearance40
      Me.ugTurnosAnteriores.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugTurnosAnteriores.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugTurnosAnteriores.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance41.BackColor = System.Drawing.SystemColors.Window
      Me.ugTurnosAnteriores.DisplayLayout.Override.CardAreaAppearance = Appearance41
      Appearance42.BorderColor = System.Drawing.Color.Silver
      Appearance42.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugTurnosAnteriores.DisplayLayout.Override.CellAppearance = Appearance42
      Me.ugTurnosAnteriores.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugTurnosAnteriores.DisplayLayout.Override.CellPadding = 0
      Appearance43.BackColor = System.Drawing.SystemColors.Control
      Appearance43.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance43.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance43.BorderColor = System.Drawing.SystemColors.Window
      Me.ugTurnosAnteriores.DisplayLayout.Override.GroupByRowAppearance = Appearance43
      Appearance44.TextHAlignAsString = "Left"
      Me.ugTurnosAnteriores.DisplayLayout.Override.HeaderAppearance = Appearance44
      Me.ugTurnosAnteriores.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugTurnosAnteriores.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance45.BackColor = System.Drawing.SystemColors.Window
      Appearance45.BorderColor = System.Drawing.Color.Silver
      Me.ugTurnosAnteriores.DisplayLayout.Override.RowAppearance = Appearance45
      Me.ugTurnosAnteriores.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance46.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugTurnosAnteriores.DisplayLayout.Override.TemplateAddRowAppearance = Appearance46
      Me.ugTurnosAnteriores.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugTurnosAnteriores.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugTurnosAnteriores.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugTurnosAnteriores.Location = New System.Drawing.Point(15, 312)
      Me.ugTurnosAnteriores.Name = "ugTurnosAnteriores"
      Me.ugTurnosAnteriores.Size = New System.Drawing.Size(605, 161)
      Me.ugTurnosAnteriores.TabIndex = 16
      Me.ugTurnosAnteriores.Text = "Turnos Historial"
      Me.ugTurnosAnteriores.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
      '
      'Ingreso
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(849, 485)
      Me.Controls.Add(Me.ugTurnosAnteriores)
      Me.Controls.Add(Me.UltraDropDown1)
      Me.Controls.Add(Me.ugTurnos)
      Me.Controls.Add(Me.tlpEstado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbSocio)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Ingreso"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Ingreso "
      Me.grbSocio.ResumeLayout(False)
      Me.grbSocio.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.tlpEstado.ResumeLayout(False)
      Me.tlpEstado.PerformLayout()
      CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugTurnos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UltraDropDown1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugTurnosAnteriores, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbSocio As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tlpEstado As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents picImagen As System.Windows.Forms.PictureBox
   Friend WithEvents lblCertificado As Eniac.Controles.Label
   Protected WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Protected WithEvents lblNombre As Eniac.Controles.Label
   Protected WithEvents bscCliente As Eniac.Controles.Buscador2
   Protected WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents ugTurnos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCambiarTipoTurno As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraDropDown1 As Infragistics.Win.UltraWinGrid.UltraDropDown
   Friend WithEvents ugTurnosAnteriores As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
