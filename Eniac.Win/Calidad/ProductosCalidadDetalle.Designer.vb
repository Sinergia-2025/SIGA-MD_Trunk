<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductosCalidadDetalle
    Inherits BaseDetalle

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaExcepcion")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Responsable")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dpto")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaControlTipo")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreExcepcionTipo")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Item")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AccionesCorrectivas")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario1")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario2")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario3")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUsuario1")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUsuario2")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaUsuario3")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdExcepcion")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaControlTipo")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdExcepcionTipo")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
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
      Me.lblNombreTipoAdjunto = New Eniac.Controles.Label()
      Me.txtIdProducto = New Eniac.Controles.TextBox()
      Me.lblIdProducto = New Eniac.Controles.Label()
      Me.txtNombreGrupoItem = New Eniac.Controles.TextBox()
      Me.grpCliente = New System.Windows.Forms.GroupBox()
      Me.txtClienteFantasia = New Eniac.Controles.TextBox()
      Me.Label5 = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.Label1 = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.Label2 = New Eniac.Controles.Label()
      Me.chbFechaLiberado = New Eniac.Controles.CheckBox()
      Me.chbFechaEntregado = New Eniac.Controles.CheckBox()
      Me.dtpLiberado = New Eniac.Controles.DateTimePicker()
      Me.dtpEntregado = New Eniac.Controles.DateTimePicker()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.dtpEgreso = New Eniac.Controles.DateTimePicker()
      Me.chbFechaEgreso = New Eniac.Controles.CheckBox()
      Me.dtpIngreso = New Eniac.Controles.DateTimePicker()
      Me.chbFechaIngreso = New Eniac.Controles.CheckBox()
      Me.dtpPreentrega = New Eniac.Controles.DateTimePicker()
      Me.chbFechaPreEntrega = New Eniac.Controles.CheckBox()
      Me.dtpEntProgramada = New Eniac.Controles.DateTimePicker()
      Me.chbFechaEntProgramada = New Eniac.Controles.CheckBox()
      Me.Label6 = New Eniac.Controles.Label()
      Me.txtNroCertificado = New Eniac.Controles.TextBox()
      Me.TBCFechas = New System.Windows.Forms.TabControl()
      Me.TbpFechas = New System.Windows.Forms.TabPage()
      Me.Label10 = New Eniac.Controles.Label()
      Me.cmbUsuarioLiberadoPDI = New Eniac.Controles.ComboBox()
      Me.dtpLiberadoPDI = New Eniac.Controles.DateTimePicker()
      Me.chbFechaLiberadoPDI = New Eniac.Controles.CheckBox()
      Me.dtpEntReProgramada = New Eniac.Controles.DateTimePicker()
      Me.chbFechaEntReProgramada = New Eniac.Controles.CheckBox()
      Me.cmbUsuarioEntregado = New Eniac.Controles.ComboBox()
      Me.cmbUsuarioLiberado = New Eniac.Controles.ComboBox()
      Me.tbpCertificados = New System.Windows.Forms.TabPage()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Label14 = New Eniac.Controles.Label()
      Me.txtNroRemito = New Eniac.Controles.TextBox()
      Me.Label13 = New Eniac.Controles.Label()
      Me.txtObsCertE = New Eniac.Controles.TextBox()
      Me.Label11 = New Eniac.Controles.Label()
      Me.txtNroCertEntregado = New Eniac.Controles.TextBox()
      Me.dtpCertEntregado = New Eniac.Controles.DateTimePicker()
      Me.chbFechaCertEntregado = New Eniac.Controles.CheckBox()
      Me.cmbUsuarioCertEntregado = New Eniac.Controles.ComboBox()
      Me.Label12 = New Eniac.Controles.Label()
      Me.grpCertificado = New System.Windows.Forms.GroupBox()
      Me.dtpCertificado = New Eniac.Controles.DateTimePicker()
      Me.chbFechaCertificado = New Eniac.Controles.CheckBox()
      Me.cmbUsuarioCertificado = New Eniac.Controles.ComboBox()
      Me.Label7 = New Eniac.Controles.Label()
      Me.tbpObservaciones = New System.Windows.Forms.TabPage()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.tbpDesvios = New System.Windows.Forms.TabPage()
      Me.ugDesviosProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.lblUbicacion = New Eniac.Controles.Label()
      Me.txtUbicacion = New Eniac.Controles.TextBox()
      Me.lblNumeroChasis = New Eniac.Controles.Label()
      Me.txtNroCarroceria = New Eniac.Controles.TextBox()
      Me.lblNroCarroceria = New Eniac.Controles.Label()
      Me.Label8 = New Eniac.Controles.Label()
      Me.Label9 = New Eniac.Controles.Label()
      Me.bscNroChasis = New Eniac.Controles.Buscador2()
      Me.txtNroMotor = New Eniac.Controles.TextBox()
      Me.btnActualizarNroMotor = New Eniac.Controles.Button()
      Me.bscModelo = New Eniac.Controles.Buscador2()
      Me.lblModelo = New Eniac.Controles.Label()
      Me.grpDetalle = New System.Windows.Forms.GroupBox()
      Me.cmbTipoServicio = New Eniac.Controles.ComboBox()
      Me.grpCliente.SuspendLayout()
      Me.TBCFechas.SuspendLayout()
      Me.TbpFechas.SuspendLayout()
      Me.tbpCertificados.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.grpCertificado.SuspendLayout()
      Me.tbpObservaciones.SuspendLayout()
      Me.tbpDesvios.SuspendLayout()
      CType(Me.ugDesviosProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpDetalle.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(358, 529)
      Me.btnAceptar.TabIndex = 12
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(444, 529)
      Me.btnCancelar.TabIndex = 13
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(257, 529)
      Me.btnCopiar.TabIndex = 14
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(196, 529)
      Me.btnAplicar.TabIndex = 15
      '
      'lblNombreTipoAdjunto
      '
      Me.lblNombreTipoAdjunto.AutoSize = True
      Me.lblNombreTipoAdjunto.LabelAsoc = Nothing
      Me.lblNombreTipoAdjunto.Location = New System.Drawing.Point(9, 15)
      Me.lblNombreTipoAdjunto.Name = "lblNombreTipoAdjunto"
      Me.lblNombreTipoAdjunto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreTipoAdjunto.TabIndex = 2
      Me.lblNombreTipoAdjunto.Text = "Nombre"
      '
      'txtIdProducto
      '
      Me.txtIdProducto.BindearPropiedadControl = "Text"
      Me.txtIdProducto.BindearPropiedadEntidad = "IdProducto"
      Me.txtIdProducto.Enabled = False
      Me.txtIdProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProducto.Formato = ""
      Me.txtIdProducto.IsDecimal = False
      Me.txtIdProducto.IsNumber = False
      Me.txtIdProducto.IsPK = True
      Me.txtIdProducto.IsRequired = True
      Me.txtIdProducto.Key = ""
      Me.txtIdProducto.LabelAsoc = Me.lblIdProducto
      Me.txtIdProducto.Location = New System.Drawing.Point(111, 9)
      Me.txtIdProducto.MaxLength = 15
      Me.txtIdProducto.Name = "txtIdProducto"
      Me.txtIdProducto.ReadOnly = True
      Me.txtIdProducto.Size = New System.Drawing.Size(119, 20)
      Me.txtIdProducto.TabIndex = 0
      Me.txtIdProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblIdProducto
      '
      Me.lblIdProducto.AutoSize = True
      Me.lblIdProducto.LabelAsoc = Nothing
      Me.lblIdProducto.Location = New System.Drawing.Point(13, 12)
      Me.lblIdProducto.Name = "lblIdProducto"
      Me.lblIdProducto.Size = New System.Drawing.Size(40, 13)
      Me.lblIdProducto.TabIndex = 0
      Me.lblIdProducto.Text = "Código"
      '
      'txtNombreGrupoItem
      '
      Me.txtNombreGrupoItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNombreGrupoItem.BindearPropiedadControl = "Text"
      Me.txtNombreGrupoItem.BindearPropiedadEntidad = "NombreProducto"
      Me.txtNombreGrupoItem.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreGrupoItem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreGrupoItem.Formato = ""
      Me.txtNombreGrupoItem.IsDecimal = False
      Me.txtNombreGrupoItem.IsNumber = False
      Me.txtNombreGrupoItem.IsPK = False
      Me.txtNombreGrupoItem.IsRequired = True
      Me.txtNombreGrupoItem.Key = ""
      Me.txtNombreGrupoItem.LabelAsoc = Me.lblNombreTipoAdjunto
      Me.txtNombreGrupoItem.Location = New System.Drawing.Point(101, 12)
      Me.txtNombreGrupoItem.MaxLength = 60
      Me.txtNombreGrupoItem.Name = "txtNombreGrupoItem"
      Me.txtNombreGrupoItem.Size = New System.Drawing.Size(355, 20)
      Me.txtNombreGrupoItem.TabIndex = 0
      '
      'grpCliente
      '
      Me.grpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpCliente.Controls.Add(Me.txtClienteFantasia)
      Me.grpCliente.Controls.Add(Me.Label5)
      Me.grpCliente.Controls.Add(Me.bscCodigoCliente)
      Me.grpCliente.Controls.Add(Me.bscCliente)
      Me.grpCliente.Controls.Add(Me.Label1)
      Me.grpCliente.Controls.Add(Me.Label2)
      Me.grpCliente.Location = New System.Drawing.Point(10, 199)
      Me.grpCliente.Name = "grpCliente"
      Me.grpCliente.Size = New System.Drawing.Size(514, 78)
      Me.grpCliente.TabIndex = 4
      Me.grpCliente.TabStop = False
      Me.grpCliente.Text = "Cliente"
      '
      'txtClienteFantasia
      '
      Me.txtClienteFantasia.BindearPropiedadControl = ""
      Me.txtClienteFantasia.BindearPropiedadEntidad = ""
      Me.txtClienteFantasia.ForeColorFocus = System.Drawing.Color.Red
      Me.txtClienteFantasia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtClienteFantasia.Formato = ""
      Me.txtClienteFantasia.IsDecimal = False
      Me.txtClienteFantasia.IsNumber = False
      Me.txtClienteFantasia.IsPK = False
      Me.txtClienteFantasia.IsRequired = False
      Me.txtClienteFantasia.Key = ""
      Me.txtClienteFantasia.LabelAsoc = Me.Label5
      Me.txtClienteFantasia.Location = New System.Drawing.Point(57, 45)
      Me.txtClienteFantasia.MaxLength = 50
      Me.txtClienteFantasia.Name = "txtClienteFantasia"
      Me.txtClienteFantasia.Size = New System.Drawing.Size(388, 20)
      Me.txtClienteFantasia.TabIndex = 3
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.LabelAsoc = Nothing
      Me.Label5.Location = New System.Drawing.Point(10, 48)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(49, 13)
      Me.Label5.TabIndex = 4
      Me.Label5.Text = "Fantasía"
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
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.Label1
      Me.bscCodigoCliente.Location = New System.Drawing.Point(57, 19)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(98, 23)
      Me.bscCodigoCliente.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(13, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Código"
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
      Me.bscCliente.LabelAsoc = Me.Label2
      Me.bscCliente.Location = New System.Drawing.Point(213, 19)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(232, 23)
      Me.bscCliente.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(156, 24)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(44, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Nombre"
      '
      'chbFechaLiberado
      '
      Me.chbFechaLiberado.AutoSize = True
      Me.chbFechaLiberado.BindearPropiedadControl = "Checked"
      Me.chbFechaLiberado.BindearPropiedadEntidad = "CalidadStatusLiberado"
      Me.chbFechaLiberado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaLiberado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaLiberado.IsPK = False
      Me.chbFechaLiberado.IsRequired = False
      Me.chbFechaLiberado.Key = Nothing
      Me.chbFechaLiberado.LabelAsoc = Nothing
      Me.chbFechaLiberado.Location = New System.Drawing.Point(11, 116)
      Me.chbFechaLiberado.Name = "chbFechaLiberado"
      Me.chbFechaLiberado.Size = New System.Drawing.Size(67, 17)
      Me.chbFechaLiberado.TabIndex = 8
      Me.chbFechaLiberado.Text = "Liberado"
      Me.chbFechaLiberado.UseVisualStyleBackColor = True
      '
      'chbFechaEntregado
      '
      Me.chbFechaEntregado.AutoSize = True
      Me.chbFechaEntregado.BindearPropiedadControl = "Checked"
      Me.chbFechaEntregado.BindearPropiedadEntidad = "CalidadStatusEntregado"
      Me.chbFechaEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEntregado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEntregado.IsPK = False
      Me.chbFechaEntregado.IsRequired = False
      Me.chbFechaEntregado.Key = Nothing
      Me.chbFechaEntregado.LabelAsoc = Nothing
      Me.chbFechaEntregado.Location = New System.Drawing.Point(11, 170)
      Me.chbFechaEntregado.Name = "chbFechaEntregado"
      Me.chbFechaEntregado.Size = New System.Drawing.Size(75, 17)
      Me.chbFechaEntregado.TabIndex = 12
      Me.chbFechaEntregado.Text = "Entregado"
      Me.chbFechaEntregado.UseVisualStyleBackColor = True
      '
      'dtpLiberado
      '
      Me.dtpLiberado.BindearPropiedadControl = "Value"
      Me.dtpLiberado.BindearPropiedadEntidad = "CalidadFechaLiberado"
      Me.dtpLiberado.CustomFormat = "dd/MM/yyyy"
      Me.dtpLiberado.Enabled = False
      Me.dtpLiberado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpLiberado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpLiberado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpLiberado.IsPK = False
      Me.dtpLiberado.IsRequired = False
      Me.dtpLiberado.Key = ""
      Me.dtpLiberado.LabelAsoc = Me.chbFechaLiberado
      Me.dtpLiberado.Location = New System.Drawing.Point(102, 113)
      Me.dtpLiberado.Name = "dtpLiberado"
      Me.dtpLiberado.Size = New System.Drawing.Size(95, 20)
      Me.dtpLiberado.TabIndex = 9
      '
      'dtpEntregado
      '
      Me.dtpEntregado.BindearPropiedadControl = "Value"
      Me.dtpEntregado.BindearPropiedadEntidad = "CalidadFechaEntregado"
      Me.dtpEntregado.CustomFormat = "dd/MM/yyyy"
      Me.dtpEntregado.Enabled = False
      Me.dtpEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpEntregado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEntregado.IsPK = False
      Me.dtpEntregado.IsRequired = False
      Me.dtpEntregado.Key = ""
      Me.dtpEntregado.LabelAsoc = Me.chbFechaEntregado
      Me.dtpEntregado.Location = New System.Drawing.Point(102, 167)
      Me.dtpEntregado.Name = "dtpEntregado"
      Me.dtpEntregado.Size = New System.Drawing.Size(95, 20)
      Me.dtpEntregado.TabIndex = 13
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(203, 117)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(87, 13)
      Me.Label3.TabIndex = 10
      Me.Label3.Text = "Usuario Liberado"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(203, 171)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(95, 13)
      Me.Label4.TabIndex = 14
      Me.Label4.Text = "Usuario Entregado"
      '
      'dtpEgreso
      '
      Me.dtpEgreso.BindearPropiedadControl = "Value"
      Me.dtpEgreso.BindearPropiedadEntidad = "CalidadFechaEgreso"
      Me.dtpEgreso.CustomFormat = "dd/MM/yyyy"
      Me.dtpEgreso.Enabled = False
      Me.dtpEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEgreso.IsPK = False
      Me.dtpEgreso.IsRequired = False
      Me.dtpEgreso.Key = ""
      Me.dtpEgreso.LabelAsoc = Me.chbFechaEgreso
      Me.dtpEgreso.Location = New System.Drawing.Point(129, 50)
      Me.dtpEgreso.Name = "dtpEgreso"
      Me.dtpEgreso.Size = New System.Drawing.Size(95, 20)
      Me.dtpEgreso.TabIndex = 3
      Me.dtpEgreso.Tag = "000"
      '
      'chbFechaEgreso
      '
      Me.chbFechaEgreso.AutoSize = True
      Me.chbFechaEgreso.BindearPropiedadControl = Nothing
      Me.chbFechaEgreso.BindearPropiedadEntidad = Nothing
      Me.chbFechaEgreso.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEgreso.IsPK = False
      Me.chbFechaEgreso.IsRequired = False
      Me.chbFechaEgreso.Key = Nothing
      Me.chbFechaEgreso.LabelAsoc = Nothing
      Me.chbFechaEgreso.Location = New System.Drawing.Point(9, 53)
      Me.chbFechaEgreso.Name = "chbFechaEgreso"
      Me.chbFechaEgreso.Size = New System.Drawing.Size(107, 17)
      Me.chbFechaEgreso.TabIndex = 2
      Me.chbFechaEgreso.Tag = "000"
      Me.chbFechaEgreso.Text = "Egreso de Planta"
      Me.chbFechaEgreso.UseVisualStyleBackColor = True
      '
      'dtpIngreso
      '
      Me.dtpIngreso.BindearPropiedadControl = "Value"
      Me.dtpIngreso.BindearPropiedadEntidad = "CalidadFechaIngreso"
      Me.dtpIngreso.CustomFormat = "dd/MM/yyyy"
      Me.dtpIngreso.Enabled = False
      Me.dtpIngreso.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpIngreso.IsPK = False
      Me.dtpIngreso.IsRequired = False
      Me.dtpIngreso.Key = ""
      Me.dtpIngreso.LabelAsoc = Me.chbFechaIngreso
      Me.dtpIngreso.Location = New System.Drawing.Point(129, 18)
      Me.dtpIngreso.Name = "dtpIngreso"
      Me.dtpIngreso.Size = New System.Drawing.Size(95, 20)
      Me.dtpIngreso.TabIndex = 1
      Me.dtpIngreso.Tag = "000"
      '
      'chbFechaIngreso
      '
      Me.chbFechaIngreso.AutoSize = True
      Me.chbFechaIngreso.BindearPropiedadControl = Nothing
      Me.chbFechaIngreso.BindearPropiedadEntidad = Nothing
      Me.chbFechaIngreso.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaIngreso.IsPK = False
      Me.chbFechaIngreso.IsRequired = False
      Me.chbFechaIngreso.Key = Nothing
      Me.chbFechaIngreso.LabelAsoc = Nothing
      Me.chbFechaIngreso.Location = New System.Drawing.Point(9, 18)
      Me.chbFechaIngreso.Name = "chbFechaIngreso"
      Me.chbFechaIngreso.Size = New System.Drawing.Size(103, 17)
      Me.chbFechaIngreso.TabIndex = 0
      Me.chbFechaIngreso.Tag = "000"
      Me.chbFechaIngreso.Text = "Ingreso a Planta"
      Me.chbFechaIngreso.UseVisualStyleBackColor = True
      '
      'dtpPreentrega
      '
      Me.dtpPreentrega.BindearPropiedadControl = "Value"
      Me.dtpPreentrega.BindearPropiedadEntidad = "CalidadFechaPreEnt"
      Me.dtpPreentrega.CustomFormat = "dd/MM/yyyy"
      Me.dtpPreentrega.Enabled = False
      Me.dtpPreentrega.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPreentrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPreentrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPreentrega.IsPK = False
      Me.dtpPreentrega.IsRequired = False
      Me.dtpPreentrega.Key = ""
      Me.dtpPreentrega.LabelAsoc = Me.chbFechaPreEntrega
      Me.dtpPreentrega.Location = New System.Drawing.Point(397, 18)
      Me.dtpPreentrega.Name = "dtpPreentrega"
      Me.dtpPreentrega.Size = New System.Drawing.Size(95, 20)
      Me.dtpPreentrega.TabIndex = 5
      '
      'chbFechaPreEntrega
      '
      Me.chbFechaPreEntrega.AutoSize = True
      Me.chbFechaPreEntrega.BindearPropiedadControl = Nothing
      Me.chbFechaPreEntrega.BindearPropiedadEntidad = Nothing
      Me.chbFechaPreEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaPreEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaPreEntrega.IsPK = False
      Me.chbFechaPreEntrega.IsRequired = False
      Me.chbFechaPreEntrega.Key = Nothing
      Me.chbFechaPreEntrega.LabelAsoc = Nothing
      Me.chbFechaPreEntrega.Location = New System.Drawing.Point(281, 18)
      Me.chbFechaPreEntrega.Name = "chbFechaPreEntrega"
      Me.chbFechaPreEntrega.Size = New System.Drawing.Size(82, 17)
      Me.chbFechaPreEntrega.TabIndex = 4
      Me.chbFechaPreEntrega.Text = "Pre Entrega"
      Me.chbFechaPreEntrega.UseVisualStyleBackColor = True
      '
      'dtpEntProgramada
      '
      Me.dtpEntProgramada.BindearPropiedadControl = "Value"
      Me.dtpEntProgramada.BindearPropiedadEntidad = "CalidadFechaEntProg"
      Me.dtpEntProgramada.CustomFormat = "dd/MM/yyyy"
      Me.dtpEntProgramada.Enabled = False
      Me.dtpEntProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpEntProgramada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpEntProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEntProgramada.IsPK = False
      Me.dtpEntProgramada.IsRequired = False
      Me.dtpEntProgramada.Key = ""
      Me.dtpEntProgramada.LabelAsoc = Me.chbFechaEntProgramada
      Me.dtpEntProgramada.Location = New System.Drawing.Point(397, 50)
      Me.dtpEntProgramada.Name = "dtpEntProgramada"
      Me.dtpEntProgramada.Size = New System.Drawing.Size(95, 20)
      Me.dtpEntProgramada.TabIndex = 7
      '
      'chbFechaEntProgramada
      '
      Me.chbFechaEntProgramada.AutoSize = True
      Me.chbFechaEntProgramada.BindearPropiedadControl = Nothing
      Me.chbFechaEntProgramada.BindearPropiedadEntidad = Nothing
      Me.chbFechaEntProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEntProgramada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEntProgramada.IsPK = False
      Me.chbFechaEntProgramada.IsRequired = False
      Me.chbFechaEntProgramada.Key = Nothing
      Me.chbFechaEntProgramada.LabelAsoc = Nothing
      Me.chbFechaEntProgramada.Location = New System.Drawing.Point(281, 52)
      Me.chbFechaEntProgramada.Name = "chbFechaEntProgramada"
      Me.chbFechaEntProgramada.Size = New System.Drawing.Size(105, 17)
      Me.chbFechaEntProgramada.TabIndex = 6
      Me.chbFechaEntProgramada.Text = "Ent. Programada"
      Me.chbFechaEntProgramada.UseVisualStyleBackColor = True
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.LabelAsoc = Nothing
      Me.Label6.Location = New System.Drawing.Point(10, 21)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(72, 13)
      Me.Label6.TabIndex = 5
      Me.Label6.Text = "Certificado Nº"
      '
      'txtNroCertificado
      '
      Me.txtNroCertificado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNroCertificado.BindearPropiedadControl = "Text"
      Me.txtNroCertificado.BindearPropiedadEntidad = "CalidadNroCertificado"
      Me.txtNroCertificado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroCertificado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroCertificado.Formato = ""
      Me.txtNroCertificado.IsDecimal = False
      Me.txtNroCertificado.IsNumber = True
      Me.txtNroCertificado.IsPK = False
      Me.txtNroCertificado.IsRequired = False
      Me.txtNroCertificado.Key = ""
      Me.txtNroCertificado.LabelAsoc = Me.Label6
      Me.txtNroCertificado.Location = New System.Drawing.Point(88, 18)
      Me.txtNroCertificado.MaxLength = 50
      Me.txtNroCertificado.Name = "txtNroCertificado"
      Me.txtNroCertificado.Size = New System.Drawing.Size(174, 20)
      Me.txtNroCertificado.TabIndex = 0
      Me.txtNroCertificado.Text = "0"
      '
      'TBCFechas
      '
      Me.TBCFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TBCFechas.Controls.Add(Me.TbpFechas)
      Me.TBCFechas.Controls.Add(Me.tbpCertificados)
      Me.TBCFechas.Controls.Add(Me.tbpObservaciones)
      Me.TBCFechas.Controls.Add(Me.tbpDesvios)
      Me.TBCFechas.Location = New System.Drawing.Point(10, 283)
      Me.TBCFechas.Name = "TBCFechas"
      Me.TBCFechas.SelectedIndex = 0
      Me.TBCFechas.Size = New System.Drawing.Size(514, 240)
      Me.TBCFechas.TabIndex = 6
      '
      'TbpFechas
      '
      Me.TbpFechas.Controls.Add(Me.Label10)
      Me.TbpFechas.Controls.Add(Me.cmbUsuarioLiberadoPDI)
      Me.TbpFechas.Controls.Add(Me.dtpLiberadoPDI)
      Me.TbpFechas.Controls.Add(Me.chbFechaLiberadoPDI)
      Me.TbpFechas.Controls.Add(Me.dtpEntReProgramada)
      Me.TbpFechas.Controls.Add(Me.chbFechaEntReProgramada)
      Me.TbpFechas.Controls.Add(Me.dtpPreentrega)
      Me.TbpFechas.Controls.Add(Me.chbFechaEgreso)
      Me.TbpFechas.Controls.Add(Me.dtpEgreso)
      Me.TbpFechas.Controls.Add(Me.chbFechaIngreso)
      Me.TbpFechas.Controls.Add(Me.dtpIngreso)
      Me.TbpFechas.Controls.Add(Me.Label4)
      Me.TbpFechas.Controls.Add(Me.dtpEntProgramada)
      Me.TbpFechas.Controls.Add(Me.Label3)
      Me.TbpFechas.Controls.Add(Me.chbFechaPreEntrega)
      Me.TbpFechas.Controls.Add(Me.cmbUsuarioEntregado)
      Me.TbpFechas.Controls.Add(Me.chbFechaEntProgramada)
      Me.TbpFechas.Controls.Add(Me.cmbUsuarioLiberado)
      Me.TbpFechas.Controls.Add(Me.dtpLiberado)
      Me.TbpFechas.Controls.Add(Me.dtpEntregado)
      Me.TbpFechas.Controls.Add(Me.chbFechaLiberado)
      Me.TbpFechas.Controls.Add(Me.chbFechaEntregado)
      Me.TbpFechas.Location = New System.Drawing.Point(4, 22)
      Me.TbpFechas.Name = "TbpFechas"
      Me.TbpFechas.Padding = New System.Windows.Forms.Padding(3)
      Me.TbpFechas.Size = New System.Drawing.Size(506, 214)
      Me.TbpFechas.TabIndex = 0
      Me.TbpFechas.Text = "Fechas"
      Me.TbpFechas.UseVisualStyleBackColor = True
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.LabelAsoc = Nothing
      Me.Label10.Location = New System.Drawing.Point(203, 144)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(108, 13)
      Me.Label10.TabIndex = 20
      Me.Label10.Text = "Usuario Liberado PDI"
      '
      'cmbUsuarioLiberadoPDI
      '
      Me.cmbUsuarioLiberadoPDI.BindearPropiedadControl = "SelectedValue"
      Me.cmbUsuarioLiberadoPDI.BindearPropiedadEntidad = "CalidadUserLiberadoPDI"
      Me.cmbUsuarioLiberadoPDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioLiberadoPDI.Enabled = False
      Me.cmbUsuarioLiberadoPDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioLiberadoPDI.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioLiberadoPDI.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioLiberadoPDI.FormattingEnabled = True
      Me.cmbUsuarioLiberadoPDI.IsPK = False
      Me.cmbUsuarioLiberadoPDI.IsRequired = False
      Me.cmbUsuarioLiberadoPDI.Key = Nothing
      Me.cmbUsuarioLiberadoPDI.LabelAsoc = Me.Label10
      Me.cmbUsuarioLiberadoPDI.Location = New System.Drawing.Point(314, 139)
      Me.cmbUsuarioLiberadoPDI.Name = "cmbUsuarioLiberadoPDI"
      Me.cmbUsuarioLiberadoPDI.Size = New System.Drawing.Size(119, 21)
      Me.cmbUsuarioLiberadoPDI.TabIndex = 21
      '
      'dtpLiberadoPDI
      '
      Me.dtpLiberadoPDI.BindearPropiedadControl = "Value"
      Me.dtpLiberadoPDI.BindearPropiedadEntidad = "CalidadFechaLiberadoPDI"
      Me.dtpLiberadoPDI.CustomFormat = "dd/MM/yyyy"
      Me.dtpLiberadoPDI.Enabled = False
      Me.dtpLiberadoPDI.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpLiberadoPDI.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpLiberadoPDI.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpLiberadoPDI.IsPK = False
      Me.dtpLiberadoPDI.IsRequired = False
      Me.dtpLiberadoPDI.Key = ""
      Me.dtpLiberadoPDI.LabelAsoc = Me.chbFechaLiberadoPDI
      Me.dtpLiberadoPDI.Location = New System.Drawing.Point(102, 140)
      Me.dtpLiberadoPDI.Name = "dtpLiberadoPDI"
      Me.dtpLiberadoPDI.Size = New System.Drawing.Size(95, 20)
      Me.dtpLiberadoPDI.TabIndex = 19
      '
      'chbFechaLiberadoPDI
      '
      Me.chbFechaLiberadoPDI.AutoSize = True
      Me.chbFechaLiberadoPDI.BindearPropiedadControl = "Checked"
      Me.chbFechaLiberadoPDI.BindearPropiedadEntidad = "CalidadStatusLiberadoPDI"
      Me.chbFechaLiberadoPDI.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaLiberadoPDI.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaLiberadoPDI.IsPK = False
      Me.chbFechaLiberadoPDI.IsRequired = False
      Me.chbFechaLiberadoPDI.Key = Nothing
      Me.chbFechaLiberadoPDI.LabelAsoc = Nothing
      Me.chbFechaLiberadoPDI.Location = New System.Drawing.Point(11, 143)
      Me.chbFechaLiberadoPDI.Name = "chbFechaLiberadoPDI"
      Me.chbFechaLiberadoPDI.Size = New System.Drawing.Size(88, 17)
      Me.chbFechaLiberadoPDI.TabIndex = 18
      Me.chbFechaLiberadoPDI.Text = "Liberado PDI"
      Me.chbFechaLiberadoPDI.UseVisualStyleBackColor = True
      '
      'dtpEntReProgramada
      '
      Me.dtpEntReProgramada.BindearPropiedadControl = "Value"
      Me.dtpEntReProgramada.BindearPropiedadEntidad = "CalidadFechaEntReProg"
      Me.dtpEntReProgramada.CustomFormat = "dd/MM/yyyy"
      Me.dtpEntReProgramada.Enabled = False
      Me.dtpEntReProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpEntReProgramada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpEntReProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpEntReProgramada.IsPK = False
      Me.dtpEntReProgramada.IsRequired = False
      Me.dtpEntReProgramada.Key = ""
      Me.dtpEntReProgramada.LabelAsoc = Me.chbFechaEntReProgramada
      Me.dtpEntReProgramada.Location = New System.Drawing.Point(397, 81)
      Me.dtpEntReProgramada.Name = "dtpEntReProgramada"
      Me.dtpEntReProgramada.Size = New System.Drawing.Size(95, 20)
      Me.dtpEntReProgramada.TabIndex = 17
      '
      'chbFechaEntReProgramada
      '
      Me.chbFechaEntReProgramada.AutoSize = True
      Me.chbFechaEntReProgramada.BindearPropiedadControl = Nothing
      Me.chbFechaEntReProgramada.BindearPropiedadEntidad = Nothing
      Me.chbFechaEntReProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaEntReProgramada.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaEntReProgramada.IsPK = False
      Me.chbFechaEntReProgramada.IsRequired = False
      Me.chbFechaEntReProgramada.Key = Nothing
      Me.chbFechaEntReProgramada.LabelAsoc = Nothing
      Me.chbFechaEntReProgramada.Location = New System.Drawing.Point(281, 83)
      Me.chbFechaEntReProgramada.Name = "chbFechaEntReProgramada"
      Me.chbFechaEntReProgramada.Size = New System.Drawing.Size(118, 17)
      Me.chbFechaEntReProgramada.TabIndex = 16
      Me.chbFechaEntReProgramada.Text = "Ent. Reprogramada"
      Me.chbFechaEntReProgramada.UseVisualStyleBackColor = True
      '
      'cmbUsuarioEntregado
      '
      Me.cmbUsuarioEntregado.BindearPropiedadControl = "SelectedValue"
      Me.cmbUsuarioEntregado.BindearPropiedadEntidad = "CalidadUserEntregado"
      Me.cmbUsuarioEntregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioEntregado.Enabled = False
      Me.cmbUsuarioEntregado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioEntregado.FormattingEnabled = True
      Me.cmbUsuarioEntregado.IsPK = False
      Me.cmbUsuarioEntregado.IsRequired = False
      Me.cmbUsuarioEntregado.Key = Nothing
      Me.cmbUsuarioEntregado.LabelAsoc = Me.Label4
      Me.cmbUsuarioEntregado.Location = New System.Drawing.Point(314, 166)
      Me.cmbUsuarioEntregado.Name = "cmbUsuarioEntregado"
      Me.cmbUsuarioEntregado.Size = New System.Drawing.Size(119, 21)
      Me.cmbUsuarioEntregado.TabIndex = 15
      '
      'cmbUsuarioLiberado
      '
      Me.cmbUsuarioLiberado.BindearPropiedadControl = "SelectedValue"
      Me.cmbUsuarioLiberado.BindearPropiedadEntidad = "CalidadUserLiberado"
      Me.cmbUsuarioLiberado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioLiberado.Enabled = False
      Me.cmbUsuarioLiberado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioLiberado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioLiberado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioLiberado.FormattingEnabled = True
      Me.cmbUsuarioLiberado.IsPK = False
      Me.cmbUsuarioLiberado.IsRequired = False
      Me.cmbUsuarioLiberado.Key = Nothing
      Me.cmbUsuarioLiberado.LabelAsoc = Me.Label3
      Me.cmbUsuarioLiberado.Location = New System.Drawing.Point(314, 112)
      Me.cmbUsuarioLiberado.Name = "cmbUsuarioLiberado"
      Me.cmbUsuarioLiberado.Size = New System.Drawing.Size(119, 21)
      Me.cmbUsuarioLiberado.TabIndex = 11
      '
      'tbpCertificados
      '
      Me.tbpCertificados.BackColor = System.Drawing.SystemColors.Control
      Me.tbpCertificados.Controls.Add(Me.GroupBox1)
      Me.tbpCertificados.Controls.Add(Me.grpCertificado)
      Me.tbpCertificados.Location = New System.Drawing.Point(4, 22)
      Me.tbpCertificados.Name = "tbpCertificados"
      Me.tbpCertificados.Size = New System.Drawing.Size(506, 214)
      Me.tbpCertificados.TabIndex = 2
      Me.tbpCertificados.Text = "Certificados"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label14)
      Me.GroupBox1.Controls.Add(Me.txtNroRemito)
      Me.GroupBox1.Controls.Add(Me.Label13)
      Me.GroupBox1.Controls.Add(Me.txtObsCertE)
      Me.GroupBox1.Controls.Add(Me.Label11)
      Me.GroupBox1.Controls.Add(Me.txtNroCertEntregado)
      Me.GroupBox1.Controls.Add(Me.dtpCertEntregado)
      Me.GroupBox1.Controls.Add(Me.cmbUsuarioCertEntregado)
      Me.GroupBox1.Controls.Add(Me.Label12)
      Me.GroupBox1.Controls.Add(Me.chbFechaCertEntregado)
      Me.GroupBox1.Location = New System.Drawing.Point(7, 81)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(485, 130)
      Me.GroupBox1.TabIndex = 51
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "ENTREGADO"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.LabelAsoc = Nothing
      Me.Label14.Location = New System.Drawing.Point(21, 76)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(75, 13)
      Me.Label14.TabIndex = 12
      Me.Label14.Text = "Nro de Remito"
      '
      'txtNroRemito
      '
      Me.txtNroRemito.BindearPropiedadControl = "Text"
      Me.txtNroRemito.BindearPropiedadEntidad = "CalidadNroRemito"
      Me.txtNroRemito.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroRemito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroRemito.Formato = ""
      Me.txtNroRemito.IsDecimal = False
      Me.txtNroRemito.IsNumber = True
      Me.txtNroRemito.IsPK = False
      Me.txtNroRemito.IsRequired = False
      Me.txtNroRemito.Key = ""
      Me.txtNroRemito.LabelAsoc = Me.Label5
      Me.txtNroRemito.Location = New System.Drawing.Point(143, 73)
      Me.txtNroRemito.MaxLength = 15
      Me.txtNroRemito.Name = "txtNroRemito"
      Me.txtNroRemito.Size = New System.Drawing.Size(143, 20)
      Me.txtNroRemito.TabIndex = 11
      Me.txtNroRemito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.LabelAsoc = Nothing
      Me.Label13.Location = New System.Drawing.Point(21, 103)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(120, 13)
      Me.Label13.TabIndex = 10
      Me.Label13.Text = "Observación Certificado"
      '
      'txtObsCertE
      '
      Me.txtObsCertE.BindearPropiedadControl = "Text"
      Me.txtObsCertE.BindearPropiedadEntidad = "CalidadNroCertEObs"
      Me.txtObsCertE.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObsCertE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObsCertE.Formato = ""
      Me.txtObsCertE.IsDecimal = False
      Me.txtObsCertE.IsNumber = False
      Me.txtObsCertE.IsPK = False
      Me.txtObsCertE.IsRequired = False
      Me.txtObsCertE.Key = ""
      Me.txtObsCertE.LabelAsoc = Me.Label5
      Me.txtObsCertE.Location = New System.Drawing.Point(143, 99)
      Me.txtObsCertE.MaxLength = 50
      Me.txtObsCertE.Name = "txtObsCertE"
      Me.txtObsCertE.Size = New System.Drawing.Size(334, 20)
      Me.txtObsCertE.TabIndex = 5
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.LabelAsoc = Nothing
      Me.Label11.Location = New System.Drawing.Point(10, 21)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(72, 13)
      Me.Label11.TabIndex = 5
      Me.Label11.Text = "Certificado Nº"
      '
      'txtNroCertEntregado
      '
      Me.txtNroCertEntregado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNroCertEntregado.BindearPropiedadControl = "Text"
      Me.txtNroCertEntregado.BindearPropiedadEntidad = "CalidadNroCertEntregado"
      Me.txtNroCertEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroCertEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroCertEntregado.Formato = ""
      Me.txtNroCertEntregado.IsDecimal = False
      Me.txtNroCertEntregado.IsNumber = True
      Me.txtNroCertEntregado.IsPK = False
      Me.txtNroCertEntregado.IsRequired = False
      Me.txtNroCertEntregado.Key = ""
      Me.txtNroCertEntregado.LabelAsoc = Me.Label11
      Me.txtNroCertEntregado.Location = New System.Drawing.Point(88, 18)
      Me.txtNroCertEntregado.MaxLength = 50
      Me.txtNroCertEntregado.Name = "txtNroCertEntregado"
      Me.txtNroCertEntregado.Size = New System.Drawing.Size(175, 20)
      Me.txtNroCertEntregado.TabIndex = 0
      Me.txtNroCertEntregado.Text = "0"
      '
      'dtpCertEntregado
      '
      Me.dtpCertEntregado.BindearPropiedadControl = "Value"
      Me.dtpCertEntregado.BindearPropiedadEntidad = "CalidadFecCertEntregado"
      Me.dtpCertEntregado.CustomFormat = "dd/MM/yyyy"
      Me.dtpCertEntregado.Enabled = False
      Me.dtpCertEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpCertEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpCertEntregado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpCertEntregado.IsPK = False
      Me.dtpCertEntregado.IsRequired = False
      Me.dtpCertEntregado.Key = ""
      Me.dtpCertEntregado.LabelAsoc = Me.chbFechaCertEntregado
      Me.dtpCertEntregado.Location = New System.Drawing.Point(143, 46)
      Me.dtpCertEntregado.Name = "dtpCertEntregado"
      Me.dtpCertEntregado.Size = New System.Drawing.Size(95, 20)
      Me.dtpCertEntregado.TabIndex = 1
      Me.dtpCertEntregado.Tag = "000"
      '
      'chbFechaCertEntregado
      '
      Me.chbFechaCertEntregado.AutoSize = True
      Me.chbFechaCertEntregado.BindearPropiedadControl = Nothing
      Me.chbFechaCertEntregado.BindearPropiedadEntidad = Nothing
      Me.chbFechaCertEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaCertEntregado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaCertEntregado.IsPK = False
      Me.chbFechaCertEntregado.IsRequired = False
      Me.chbFechaCertEntregado.Key = Nothing
      Me.chbFechaCertEntregado.LabelAsoc = Nothing
      Me.chbFechaCertEntregado.Location = New System.Drawing.Point(21, 46)
      Me.chbFechaCertEntregado.Name = "chbFechaCertEntregado"
      Me.chbFechaCertEntregado.Size = New System.Drawing.Size(109, 17)
      Me.chbFechaCertEntregado.TabIndex = 7
      Me.chbFechaCertEntregado.Tag = "000"
      Me.chbFechaCertEntregado.Text = "Fecha Certificado"
      Me.chbFechaCertEntregado.UseVisualStyleBackColor = True
      '
      'cmbUsuarioCertEntregado
      '
      Me.cmbUsuarioCertEntregado.BindearPropiedadControl = "SelectedValue"
      Me.cmbUsuarioCertEntregado.BindearPropiedadEntidad = "CalidadUsrCertEntregado"
      Me.cmbUsuarioCertEntregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioCertEntregado.Enabled = False
      Me.cmbUsuarioCertEntregado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioCertEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioCertEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioCertEntregado.FormattingEnabled = True
      Me.cmbUsuarioCertEntregado.IsPK = False
      Me.cmbUsuarioCertEntregado.IsRequired = False
      Me.cmbUsuarioCertEntregado.Key = Nothing
      Me.cmbUsuarioCertEntregado.LabelAsoc = Me.Label12
      Me.cmbUsuarioCertEntregado.Location = New System.Drawing.Point(358, 46)
      Me.cmbUsuarioCertEntregado.Name = "cmbUsuarioCertEntregado"
      Me.cmbUsuarioCertEntregado.Size = New System.Drawing.Size(119, 21)
      Me.cmbUsuarioCertEntregado.TabIndex = 2
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.LabelAsoc = Nothing
      Me.Label12.Location = New System.Drawing.Point(256, 49)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(96, 13)
      Me.Label12.TabIndex = 9
      Me.Label12.Text = "Usuario Certificado"
      '
      'grpCertificado
      '
      Me.grpCertificado.Controls.Add(Me.Label6)
      Me.grpCertificado.Controls.Add(Me.txtNroCertificado)
      Me.grpCertificado.Controls.Add(Me.dtpCertificado)
      Me.grpCertificado.Controls.Add(Me.cmbUsuarioCertificado)
      Me.grpCertificado.Controls.Add(Me.Label7)
      Me.grpCertificado.Controls.Add(Me.chbFechaCertificado)
      Me.grpCertificado.Location = New System.Drawing.Point(7, 3)
      Me.grpCertificado.Name = "grpCertificado"
      Me.grpCertificado.Size = New System.Drawing.Size(484, 77)
      Me.grpCertificado.TabIndex = 5
      Me.grpCertificado.TabStop = False
      Me.grpCertificado.Text = "CALIDAD"
      '
      'dtpCertificado
      '
      Me.dtpCertificado.BindearPropiedadControl = "Value"
      Me.dtpCertificado.BindearPropiedadEntidad = "CalidadFecCertificado"
      Me.dtpCertificado.CustomFormat = "dd/MM/yyyy"
      Me.dtpCertificado.Enabled = False
      Me.dtpCertificado.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpCertificado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpCertificado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpCertificado.IsPK = False
      Me.dtpCertificado.IsRequired = False
      Me.dtpCertificado.Key = ""
      Me.dtpCertificado.LabelAsoc = Me.chbFechaCertificado
      Me.dtpCertificado.Location = New System.Drawing.Point(143, 46)
      Me.dtpCertificado.Name = "dtpCertificado"
      Me.dtpCertificado.Size = New System.Drawing.Size(95, 20)
      Me.dtpCertificado.TabIndex = 1
      Me.dtpCertificado.Tag = "000"
      '
      'chbFechaCertificado
      '
      Me.chbFechaCertificado.AutoSize = True
      Me.chbFechaCertificado.BindearPropiedadControl = Nothing
      Me.chbFechaCertificado.BindearPropiedadEntidad = Nothing
      Me.chbFechaCertificado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaCertificado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaCertificado.IsPK = False
      Me.chbFechaCertificado.IsRequired = False
      Me.chbFechaCertificado.Key = Nothing
      Me.chbFechaCertificado.LabelAsoc = Nothing
      Me.chbFechaCertificado.Location = New System.Drawing.Point(21, 46)
      Me.chbFechaCertificado.Name = "chbFechaCertificado"
      Me.chbFechaCertificado.Size = New System.Drawing.Size(109, 17)
      Me.chbFechaCertificado.TabIndex = 7
      Me.chbFechaCertificado.Tag = "000"
      Me.chbFechaCertificado.Text = "Fecha Certificado"
      Me.chbFechaCertificado.UseVisualStyleBackColor = True
      '
      'cmbUsuarioCertificado
      '
      Me.cmbUsuarioCertificado.BindearPropiedadControl = "SelectedValue"
      Me.cmbUsuarioCertificado.BindearPropiedadEntidad = "CalidadUsrCertificado"
      Me.cmbUsuarioCertificado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioCertificado.Enabled = False
      Me.cmbUsuarioCertificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioCertificado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioCertificado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioCertificado.FormattingEnabled = True
      Me.cmbUsuarioCertificado.IsPK = False
      Me.cmbUsuarioCertificado.IsRequired = False
      Me.cmbUsuarioCertificado.Key = Nothing
      Me.cmbUsuarioCertificado.LabelAsoc = Me.Label7
      Me.cmbUsuarioCertificado.Location = New System.Drawing.Point(358, 46)
      Me.cmbUsuarioCertificado.Name = "cmbUsuarioCertificado"
      Me.cmbUsuarioCertificado.Size = New System.Drawing.Size(119, 21)
      Me.cmbUsuarioCertificado.TabIndex = 2
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.LabelAsoc = Nothing
      Me.Label7.Location = New System.Drawing.Point(256, 49)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(96, 13)
      Me.Label7.TabIndex = 9
      Me.Label7.Text = "Usuario Certificado"
      '
      'tbpObservaciones
      '
      Me.tbpObservaciones.Controls.Add(Me.txtObservacion)
      Me.tbpObservaciones.Location = New System.Drawing.Point(4, 22)
      Me.tbpObservaciones.Name = "tbpObservaciones"
      Me.tbpObservaciones.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpObservaciones.Size = New System.Drawing.Size(506, 214)
      Me.tbpObservaciones.TabIndex = 1
      Me.tbpObservaciones.Text = "Observaciones"
      Me.tbpObservaciones.UseVisualStyleBackColor = True
      '
      'txtObservacion
      '
      Me.txtObservacion.BindearPropiedadControl = "Text"
      Me.txtObservacion.BindearPropiedadEntidad = "CalidadObservaciones"
      Me.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtObservacion.Formato = ""
      Me.txtObservacion.IsDecimal = False
      Me.txtObservacion.IsNumber = False
      Me.txtObservacion.IsPK = False
      Me.txtObservacion.IsRequired = False
      Me.txtObservacion.Key = ""
      Me.txtObservacion.LabelAsoc = Nothing
      Me.txtObservacion.Location = New System.Drawing.Point(3, 3)
      Me.txtObservacion.MaxLength = 1000
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtObservacion.Size = New System.Drawing.Size(500, 208)
      Me.txtObservacion.TabIndex = 0
      '
      'tbpDesvios
      '
      Me.tbpDesvios.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDesvios.Controls.Add(Me.ugDesviosProductos)
      Me.tbpDesvios.Location = New System.Drawing.Point(4, 22)
      Me.tbpDesvios.Name = "tbpDesvios"
      Me.tbpDesvios.Size = New System.Drawing.Size(506, 214)
      Me.tbpDesvios.TabIndex = 3
      Me.tbpDesvios.Text = "Desvíos"
      '
      'ugDesviosProductos
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDesviosProductos.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn1.Width = 27
      UltraGridColumn2.Header.Caption = "Fecha Desvío"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Hidden = True
      UltraGridColumn2.Width = 87
      UltraGridColumn21.Header.VisiblePosition = 7
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 136
      UltraGridColumn5.Header.Caption = "Sección"
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Width = 117
      UltraGridColumn6.Header.Caption = "Tipo"
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn6.Width = 113
      UltraGridColumn7.Header.VisiblePosition = 4
      UltraGridColumn7.Width = 191
      UltraGridColumn8.Header.VisiblePosition = 9
      UltraGridColumn8.Width = 231
      UltraGridColumn9.Header.Caption = "Acciones Correctivas"
      UltraGridColumn9.Header.VisiblePosition = 10
      UltraGridColumn9.Width = 253
      UltraGridColumn10.Header.Caption = "Autorizante 1"
      UltraGridColumn10.Header.VisiblePosition = 11
      UltraGridColumn10.Width = 105
      UltraGridColumn11.Header.Caption = "Autorizante 2"
      UltraGridColumn11.Header.VisiblePosition = 13
      UltraGridColumn11.Width = 106
      UltraGridColumn12.Header.Caption = "Autorizante 3"
      UltraGridColumn12.Header.VisiblePosition = 15
      UltraGridColumn12.Width = 116
      UltraGridColumn13.Header.Caption = "Fecha"
      UltraGridColumn13.Header.VisiblePosition = 12
      UltraGridColumn13.Width = 94
      UltraGridColumn14.Header.Caption = "Fecha"
      UltraGridColumn14.Header.VisiblePosition = 14
      UltraGridColumn14.Width = 80
      UltraGridColumn15.Header.Caption = "Fecha"
      UltraGridColumn15.Header.VisiblePosition = 16
      UltraGridColumn15.Width = 92
      UltraGridColumn16.Header.VisiblePosition = 17
      UltraGridColumn16.Hidden = True
      UltraGridColumn17.Header.VisiblePosition = 18
      UltraGridColumn17.Hidden = True
      UltraGridColumn18.Header.VisiblePosition = 19
      UltraGridColumn18.Hidden = True
      UltraGridColumn19.Header.VisiblePosition = 20
      UltraGridColumn19.Hidden = True
      UltraGridColumn20.Header.VisiblePosition = 1
      UltraGridColumn22.Header.Caption = "Responsable"
      UltraGridColumn22.Header.VisiblePosition = 8
      UltraGridColumn22.Hidden = True
      UltraGridColumn22.Width = 106
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn21, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn22})
      Me.ugDesviosProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDesviosProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDesviosProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDesviosProductos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDesviosProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDesviosProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDesviosProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDesviosProductos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDesviosProductos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDesviosProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDesviosProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDesviosProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDesviosProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDesviosProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDesviosProductos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDesviosProductos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDesviosProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDesviosProductos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDesviosProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDesviosProductos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDesviosProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDesviosProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDesviosProductos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDesviosProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDesviosProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDesviosProductos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDesviosProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDesviosProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDesviosProductos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDesviosProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDesviosProductos.Location = New System.Drawing.Point(0, 0)
      Me.ugDesviosProductos.Name = "ugDesviosProductos"
      Me.ugDesviosProductos.Size = New System.Drawing.Size(506, 214)
      Me.ugDesviosProductos.TabIndex = 25
      Me.ugDesviosProductos.Text = "UltraGrid1"
      '
      'lblUbicacion
      '
      Me.lblUbicacion.AutoSize = True
      Me.lblUbicacion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblUbicacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblUbicacion.LabelAsoc = Nothing
      Me.lblUbicacion.Location = New System.Drawing.Point(348, 98)
      Me.lblUbicacion.Name = "lblUbicacion"
      Me.lblUbicacion.Size = New System.Drawing.Size(55, 13)
      Me.lblUbicacion.TabIndex = 49
      Me.lblUbicacion.Text = "Ubicacion"
      Me.lblUbicacion.Visible = False
      '
      'txtUbicacion
      '
      Me.txtUbicacion.BindearPropiedadControl = "Text"
      Me.txtUbicacion.BindearPropiedadEntidad = "Ubicacion"
      Me.txtUbicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUbicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUbicacion.Formato = ""
      Me.txtUbicacion.IsDecimal = False
      Me.txtUbicacion.IsNumber = False
      Me.txtUbicacion.IsPK = False
      Me.txtUbicacion.IsRequired = False
      Me.txtUbicacion.Key = ""
      Me.txtUbicacion.LabelAsoc = Me.lblUbicacion
      Me.txtUbicacion.Location = New System.Drawing.Point(409, 95)
      Me.txtUbicacion.MaxLength = 12
      Me.txtUbicacion.Name = "txtUbicacion"
      Me.txtUbicacion.ReadOnly = True
      Me.txtUbicacion.Size = New System.Drawing.Size(90, 20)
      Me.txtUbicacion.TabIndex = 50
      Me.txtUbicacion.Visible = False
      '
      'lblNumeroChasis
      '
      Me.lblNumeroChasis.AutoSize = True
      Me.lblNumeroChasis.LabelAsoc = Nothing
      Me.lblNumeroChasis.Location = New System.Drawing.Point(8, 70)
      Me.lblNumeroChasis.Name = "lblNumeroChasis"
      Me.lblNumeroChasis.Size = New System.Drawing.Size(93, 13)
      Me.lblNumeroChasis.TabIndex = 6
      Me.lblNumeroChasis.Text = "Número de Chasis"
      '
      'txtNroCarroceria
      '
      Me.txtNroCarroceria.BindearPropiedadControl = "Text"
      Me.txtNroCarroceria.BindearPropiedadEntidad = "CalidadNroCarroceria"
      Me.txtNroCarroceria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroCarroceria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroCarroceria.Formato = ""
      Me.txtNroCarroceria.IsDecimal = False
      Me.txtNroCarroceria.IsNumber = True
      Me.txtNroCarroceria.IsPK = False
      Me.txtNroCarroceria.IsRequired = True
      Me.txtNroCarroceria.Key = ""
      Me.txtNroCarroceria.LabelAsoc = Me.lblNroCarroceria
      Me.txtNroCarroceria.Location = New System.Drawing.Point(151, 36)
      Me.txtNroCarroceria.MaxLength = 9
      Me.txtNroCarroceria.Name = "txtNroCarroceria"
      Me.txtNroCarroceria.Size = New System.Drawing.Size(79, 20)
      Me.txtNroCarroceria.TabIndex = 1
      Me.txtNroCarroceria.Text = "0"
      Me.txtNroCarroceria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroCarroceria
      '
      Me.lblNroCarroceria.AutoSize = True
      Me.lblNroCarroceria.LabelAsoc = Nothing
      Me.lblNroCarroceria.Location = New System.Drawing.Point(12, 40)
      Me.lblNroCarroceria.Name = "lblNroCarroceria"
      Me.lblNroCarroceria.Size = New System.Drawing.Size(112, 13)
      Me.lblNroCarroceria.TabIndex = 51
      Me.lblNroCarroceria.Text = "Número de Carrocería"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.LabelAsoc = Nothing
      Me.Label8.Location = New System.Drawing.Point(246, 40)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(84, 13)
      Me.Label8.TabIndex = 54
      Me.Label8.Text = "Tipo de Servicio"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(9, 97)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(89, 13)
      Me.Label9.TabIndex = 55
      Me.Label9.Text = "Número de Motor"
      '
      'bscNroChasis
      '
      Me.bscNroChasis.ActivarFiltroEnGrilla = True
      Me.bscNroChasis.AutoSize = True
      Me.bscNroChasis.BindearPropiedadControl = ""
      Me.bscNroChasis.BindearPropiedadEntidad = ""
      Me.bscNroChasis.ConfigBuscador = Nothing
      Me.bscNroChasis.Datos = Nothing
      Me.bscNroChasis.Enabled = False
      Me.bscNroChasis.FilaDevuelta = Nothing
      Me.bscNroChasis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNroChasis.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNroChasis.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNroChasis.IsDecimal = False
      Me.bscNroChasis.IsNumber = False
      Me.bscNroChasis.IsPK = False
      Me.bscNroChasis.IsRequired = False
      Me.bscNroChasis.Key = ""
      Me.bscNroChasis.LabelAsoc = Me.Label2
      Me.bscNroChasis.Location = New System.Drawing.Point(101, 66)
      Me.bscNroChasis.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNroChasis.MaxLengh = "32767"
      Me.bscNroChasis.Name = "bscNroChasis"
      Me.bscNroChasis.Permitido = True
      Me.bscNroChasis.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNroChasis.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNroChasis.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNroChasis.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNroChasis.Selecciono = False
      Me.bscNroChasis.Size = New System.Drawing.Size(227, 23)
      Me.bscNroChasis.TabIndex = 2
      '
      'txtNroMotor
      '
      Me.txtNroMotor.BindearPropiedadControl = "Text"
      Me.txtNroMotor.BindearPropiedadEntidad = "CalidadNroDeMotor"
      Me.txtNroMotor.Enabled = False
      Me.txtNroMotor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroMotor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroMotor.Formato = ""
      Me.txtNroMotor.IsDecimal = False
      Me.txtNroMotor.IsNumber = False
      Me.txtNroMotor.IsPK = False
      Me.txtNroMotor.IsRequired = False
      Me.txtNroMotor.Key = ""
      Me.txtNroMotor.LabelAsoc = Me.Label5
      Me.txtNroMotor.Location = New System.Drawing.Point(101, 94)
      Me.txtNroMotor.MaxLength = 50
      Me.txtNroMotor.Name = "txtNroMotor"
      Me.txtNroMotor.Size = New System.Drawing.Size(199, 20)
      Me.txtNroMotor.TabIndex = 3
      '
      'btnActualizarNroMotor
      '
      Me.btnActualizarNroMotor.Enabled = False
      Me.btnActualizarNroMotor.Image = Global.Eniac.Win.My.Resources.Resources.refresh_16
      Me.btnActualizarNroMotor.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.btnActualizarNroMotor.Location = New System.Drawing.Point(300, 94)
      Me.btnActualizarNroMotor.Name = "btnActualizarNroMotor"
      Me.btnActualizarNroMotor.Size = New System.Drawing.Size(28, 21)
      Me.btnActualizarNroMotor.TabIndex = 56
      Me.btnActualizarNroMotor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnActualizarNroMotor.UseVisualStyleBackColor = True
      '
      'bscModelo
      '
      Me.bscModelo.ActivarFiltroEnGrilla = True
      Me.bscModelo.AutoSize = True
      Me.bscModelo.BindearPropiedadControl = ""
      Me.bscModelo.BindearPropiedadEntidad = ""
      Me.bscModelo.ConfigBuscador = Nothing
      Me.bscModelo.Datos = Nothing
      Me.bscModelo.Enabled = False
      Me.bscModelo.FilaDevuelta = Nothing
      Me.bscModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscModelo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscModelo.IsDecimal = False
      Me.bscModelo.IsNumber = False
      Me.bscModelo.IsPK = False
      Me.bscModelo.IsRequired = False
      Me.bscModelo.Key = ""
      Me.bscModelo.LabelAsoc = Me.Label2
      Me.bscModelo.Location = New System.Drawing.Point(101, 38)
      Me.bscModelo.Margin = New System.Windows.Forms.Padding(4)
      Me.bscModelo.MaxLengh = "32767"
      Me.bscModelo.Name = "bscModelo"
      Me.bscModelo.Permitido = True
      Me.bscModelo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscModelo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscModelo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscModelo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscModelo.Selecciono = False
      Me.bscModelo.Size = New System.Drawing.Size(350, 23)
      Me.bscModelo.TabIndex = 1
      '
      'lblModelo
      '
      Me.lblModelo.AutoSize = True
      Me.lblModelo.LabelAsoc = Nothing
      Me.lblModelo.Location = New System.Drawing.Point(9, 42)
      Me.lblModelo.Name = "lblModelo"
      Me.lblModelo.Size = New System.Drawing.Size(42, 13)
      Me.lblModelo.TabIndex = 60
      Me.lblModelo.Text = "Modelo"
      '
      'grpDetalle
      '
      Me.grpDetalle.Controls.Add(Me.txtUbicacion)
      Me.grpDetalle.Controls.Add(Me.bscModelo)
      Me.grpDetalle.Controls.Add(Me.lblNombreTipoAdjunto)
      Me.grpDetalle.Controls.Add(Me.lblModelo)
      Me.grpDetalle.Controls.Add(Me.txtNombreGrupoItem)
      Me.grpDetalle.Controls.Add(Me.btnActualizarNroMotor)
      Me.grpDetalle.Controls.Add(Me.lblUbicacion)
      Me.grpDetalle.Controls.Add(Me.lblNumeroChasis)
      Me.grpDetalle.Controls.Add(Me.txtNroMotor)
      Me.grpDetalle.Controls.Add(Me.Label9)
      Me.grpDetalle.Controls.Add(Me.bscNroChasis)
      Me.grpDetalle.Location = New System.Drawing.Point(7, 64)
      Me.grpDetalle.Name = "grpDetalle"
      Me.grpDetalle.Size = New System.Drawing.Size(519, 131)
      Me.grpDetalle.TabIndex = 3
      Me.grpDetalle.TabStop = False
      '
      'cmbTipoServicio
      '
      Me.cmbTipoServicio.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoServicio.BindearPropiedadEntidad = "IdProductoTipoServicio"
      Me.cmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoServicio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoServicio.FormattingEnabled = True
      Me.cmbTipoServicio.IsPK = False
      Me.cmbTipoServicio.IsRequired = True
      Me.cmbTipoServicio.Key = Nothing
      Me.cmbTipoServicio.LabelAsoc = Me.Label7
      Me.cmbTipoServicio.Location = New System.Drawing.Point(336, 35)
      Me.cmbTipoServicio.Name = "cmbTipoServicio"
      Me.cmbTipoServicio.Size = New System.Drawing.Size(119, 21)
      Me.cmbTipoServicio.TabIndex = 2
      '
      'ProductosCalidadDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(533, 564)
      Me.Controls.Add(Me.grpDetalle)
      Me.Controls.Add(Me.cmbTipoServicio)
      Me.Controls.Add(Me.txtNroCarroceria)
      Me.Controls.Add(Me.lblNroCarroceria)
      Me.Controls.Add(Me.TBCFechas)
      Me.Controls.Add(Me.grpCliente)
      Me.Controls.Add(Me.txtIdProducto)
      Me.Controls.Add(Me.lblIdProducto)
      Me.Controls.Add(Me.Label8)
      Me.Name = "ProductosCalidadDetalle"
      Me.Text = "Producto"
      Me.Controls.SetChildIndex(Me.Label8, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblIdProducto, 0)
      Me.Controls.SetChildIndex(Me.txtIdProducto, 0)
      Me.Controls.SetChildIndex(Me.grpCliente, 0)
      Me.Controls.SetChildIndex(Me.TBCFechas, 0)
      Me.Controls.SetChildIndex(Me.lblNroCarroceria, 0)
      Me.Controls.SetChildIndex(Me.txtNroCarroceria, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoServicio, 0)
      Me.Controls.SetChildIndex(Me.grpDetalle, 0)
      Me.grpCliente.ResumeLayout(False)
      Me.grpCliente.PerformLayout()
      Me.TBCFechas.ResumeLayout(False)
      Me.TbpFechas.ResumeLayout(False)
      Me.TbpFechas.PerformLayout()
      Me.tbpCertificados.ResumeLayout(False)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.grpCertificado.ResumeLayout(False)
      Me.grpCertificado.PerformLayout()
      Me.tbpObservaciones.ResumeLayout(False)
      Me.tbpObservaciones.PerformLayout()
      Me.tbpDesvios.ResumeLayout(False)
      CType(Me.ugDesviosProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpDetalle.ResumeLayout(False)
      Me.grpDetalle.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoAdjunto As Eniac.Controles.Label
    Friend WithEvents txtIdProducto As Eniac.Controles.TextBox
    Friend WithEvents lblIdProducto As Eniac.Controles.Label
    Friend WithEvents txtNombreGrupoItem As Eniac.Controles.TextBox
    Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents bscCliente As Eniac.Controles.Buscador2
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents chbFechaLiberado As Eniac.Controles.CheckBox
    Friend WithEvents chbFechaEntregado As Eniac.Controles.CheckBox
    Friend WithEvents dtpLiberado As Eniac.Controles.DateTimePicker
    Friend WithEvents dtpEntregado As Eniac.Controles.DateTimePicker
    Friend WithEvents txtClienteFantasia As Eniac.Controles.TextBox
    Friend WithEvents Label5 As Eniac.Controles.Label
    Friend WithEvents cmbUsuarioLiberado As Eniac.Controles.ComboBox
    Friend WithEvents cmbUsuarioEntregado As Eniac.Controles.ComboBox
    Friend WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents dtpEgreso As Eniac.Controles.DateTimePicker
    Friend WithEvents chbFechaEgreso As Eniac.Controles.CheckBox
    Friend WithEvents dtpIngreso As Eniac.Controles.DateTimePicker
    Friend WithEvents chbFechaIngreso As Eniac.Controles.CheckBox
    Friend WithEvents dtpPreentrega As Eniac.Controles.DateTimePicker
    Friend WithEvents chbFechaPreEntrega As Eniac.Controles.CheckBox
    Friend WithEvents dtpEntProgramada As Eniac.Controles.DateTimePicker
    Friend WithEvents chbFechaEntProgramada As Eniac.Controles.CheckBox
    Friend WithEvents Label6 As Eniac.Controles.Label
    Friend WithEvents txtNroCertificado As Eniac.Controles.TextBox
    Friend WithEvents TBCFechas As System.Windows.Forms.TabControl
    Friend WithEvents TbpFechas As System.Windows.Forms.TabPage
    Friend WithEvents tbpObservaciones As System.Windows.Forms.TabPage
    Friend WithEvents txtObservacion As Eniac.Controles.TextBox
    Friend WithEvents Label7 As Eniac.Controles.Label
    Friend WithEvents cmbUsuarioCertificado As Eniac.Controles.ComboBox
    Friend WithEvents dtpCertificado As Eniac.Controles.DateTimePicker
    Friend WithEvents chbFechaCertificado As Eniac.Controles.CheckBox
    Friend WithEvents lblUbicacion As Eniac.Controles.Label
    Friend WithEvents txtUbicacion As Eniac.Controles.TextBox
    Friend WithEvents lblNumeroChasis As Eniac.Controles.Label
    Friend WithEvents txtNroCarroceria As Eniac.Controles.TextBox
    Friend WithEvents lblNroCarroceria As Eniac.Controles.Label
    Friend WithEvents cmbTipoServicio As Eniac.Controles.ComboBox
    Friend WithEvents Label8 As Eniac.Controles.Label
    Friend WithEvents Label9 As Eniac.Controles.Label
    Friend WithEvents bscNroChasis As Eniac.Controles.Buscador2
    Friend WithEvents txtNroMotor As Eniac.Controles.TextBox
    Friend WithEvents dtpEntReProgramada As Eniac.Controles.DateTimePicker
    Friend WithEvents chbFechaEntReProgramada As Eniac.Controles.CheckBox
    Friend WithEvents btnActualizarNroMotor As Controles.Button
    Friend WithEvents bscModelo As Controles.Buscador2
    Friend WithEvents lblModelo As Controles.Label
    Friend WithEvents grpDetalle As GroupBox
    Friend WithEvents grpCertificado As GroupBox
    Friend WithEvents tbpCertificados As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Controles.Label
    Friend WithEvents txtNroCertEntregado As Controles.TextBox
    Friend WithEvents dtpCertEntregado As Controles.DateTimePicker
    Friend WithEvents chbFechaCertEntregado As Controles.CheckBox
    Friend WithEvents cmbUsuarioCertEntregado As Controles.ComboBox
    Friend WithEvents Label12 As Controles.Label
    Friend WithEvents Label10 As Controles.Label
    Friend WithEvents cmbUsuarioLiberadoPDI As Controles.ComboBox
    Friend WithEvents dtpLiberadoPDI As Controles.DateTimePicker
    Friend WithEvents chbFechaLiberadoPDI As Controles.CheckBox
    Friend WithEvents Label13 As Controles.Label
    Friend WithEvents txtObsCertE As Controles.TextBox
    Friend WithEvents Label14 As Controles.Label
    Friend WithEvents txtNroRemito As Controles.TextBox
   Friend WithEvents tbpDesvios As TabPage
   Friend WithEvents ugDesviosProductos As UltraGrid
End Class
