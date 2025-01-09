<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SucursalesDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSucursal")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenVentas")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenCompras")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenFichas")
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
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SucursalesDetalle))
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.tbpSucursal = New System.Windows.Forms.TabPage()
      Me.lblEmpresa = New Eniac.Controles.Label()
      Me.cmbEmpresa = New Eniac.Controles.ComboBox()
      Me.chbPublicarEnWeb = New Eniac.Controles.CheckBox()
      Me.chbSucursalAsociadaPrecios = New Eniac.Controles.CheckBox()
      Me.cmbSucursalAsociadaPrecios = New Eniac.Controles.ComboBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.TextBox1 = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtDireccionComercial = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbLocalidadComercial = New Eniac.Controles.ComboBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.lblTamano = New Eniac.Controles.Label()
      Me.pcbFoto = New System.Windows.Forms.PictureBox()
      Me.btnLimpiarImagen = New Eniac.Controles.Button()
      Me.btnBuscarImagen = New Eniac.Controles.Button()
      Me.txtColor = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.btnLimpiarSucursal = New System.Windows.Forms.Button()
      Me.btnColorSucursal = New System.Windows.Forms.Button()
        Me.chbSoyLaCentral = New Eniac.Controles.CheckBox()
        Me.chbEstoyAca = New Eniac.Controles.CheckBox()
        Me.dtpFechaInicioActiv = New Eniac.Controles.DateTimePicker()
        Me.lblFechaInicioActiv = New Eniac.Controles.Label()
        Me.txtIdSucursal = New Eniac.Controles.TextBox()
        Me.lblIdSucursal = New Eniac.Controles.Label()
        Me.lblCorreo = New Eniac.Controles.Label()
        Me.txtCorreo = New Eniac.Controles.TextBox()
        Me.lblTelefono = New Eniac.Controles.Label()
        Me.txtTelefono = New Eniac.Controles.TextBox()
        Me.lblDireccion = New Eniac.Controles.Label()
        Me.txtDireccion = New Eniac.Controles.TextBox()
        Me.lblLocalidad = New Eniac.Controles.Label()
        Me.cmbLocalidad = New Eniac.Controles.ComboBox()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtNombre = New Eniac.Controles.TextBox()
        Me.tbpFormasPago = New System.Windows.Forms.TabPage()
        Me.btnLimpiarFormaDePago = New Eniac.Controles.Button()
        Me.lblFormaDePago = New System.Windows.Forms.Label()
        Me.cmbFormaDePago = New Eniac.Win.ComboBoxFormaDePago()
        Me.btnEliminarFormaDePago = New Eniac.Controles.Button()
        Me.btnAgregarFormaDePago = New Eniac.Controles.Button()
        Me.ugFormasDePago = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtSucursales = New Eniac.Controles.TextBox()
        Me.lblSucursalAsociada = New Eniac.Controles.Label()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpSucursal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpFormasPago.SuspendLayout()
        CType(Me.ugFormasDePago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(623, 370)
        Me.btnAceptar.TabIndex = 35
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(709, 370)
        Me.btnCancelar.TabIndex = 36
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(522, 370)
        Me.btnCopiar.TabIndex = 33
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(465, 370)
        Me.btnAplicar.TabIndex = 31
        '
        'ofdArchivos
        '
        Me.ofdArchivos.Filter = "jpg files|*.jpg"
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Controls.Add(Me.tbpSucursal)
        Me.tbcDetalle.Controls.Add(Me.tbpFormasPago)
        Me.tbcDetalle.Location = New System.Drawing.Point(12, 12)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(777, 352)
        Me.tbcDetalle.TabIndex = 37
        '
        'tbpSucursal
        '
        Me.tbpSucursal.BackColor = System.Drawing.SystemColors.Control
        Me.tbpSucursal.Controls.Add(Me.lblSucursalAsociada)
        Me.tbpSucursal.Controls.Add(Me.txtSucursales)
        Me.tbpSucursal.Controls.Add(Me.lblEmpresa)
        Me.tbpSucursal.Controls.Add(Me.cmbEmpresa)
        Me.tbpSucursal.Controls.Add(Me.chbPublicarEnWeb)
        Me.tbpSucursal.Controls.Add(Me.chbSucursalAsociadaPrecios)
        Me.tbpSucursal.Controls.Add(Me.cmbSucursalAsociadaPrecios)
        Me.tbpSucursal.Controls.Add(Me.Label4)
        Me.tbpSucursal.Controls.Add(Me.TextBox1)
        Me.tbpSucursal.Controls.Add(Me.Label1)
        Me.tbpSucursal.Controls.Add(Me.txtDireccionComercial)
        Me.tbpSucursal.Controls.Add(Me.Label3)
        Me.tbpSucursal.Controls.Add(Me.cmbLocalidadComercial)
        Me.tbpSucursal.Controls.Add(Me.GroupBox1)
        Me.tbpSucursal.Controls.Add(Me.txtColor)
        Me.tbpSucursal.Controls.Add(Me.Label2)
        Me.tbpSucursal.Controls.Add(Me.btnLimpiarSucursal)
        Me.tbpSucursal.Controls.Add(Me.btnColorSucursal)
        Me.tbpSucursal.Controls.Add(Me.chbSoyLaCentral)
        Me.tbpSucursal.Controls.Add(Me.chbEstoyAca)
        Me.tbpSucursal.Controls.Add(Me.dtpFechaInicioActiv)
        Me.tbpSucursal.Controls.Add(Me.lblFechaInicioActiv)
        Me.tbpSucursal.Controls.Add(Me.txtIdSucursal)
        Me.tbpSucursal.Controls.Add(Me.lblIdSucursal)
        Me.tbpSucursal.Controls.Add(Me.lblCorreo)
        Me.tbpSucursal.Controls.Add(Me.txtCorreo)
        Me.tbpSucursal.Controls.Add(Me.lblTelefono)
        Me.tbpSucursal.Controls.Add(Me.txtTelefono)
        Me.tbpSucursal.Controls.Add(Me.lblDireccion)
        Me.tbpSucursal.Controls.Add(Me.txtDireccion)
        Me.tbpSucursal.Controls.Add(Me.lblLocalidad)
        Me.tbpSucursal.Controls.Add(Me.cmbLocalidad)
        Me.tbpSucursal.Controls.Add(Me.lblNombre)
        Me.tbpSucursal.Controls.Add(Me.txtNombre)
        Me.tbpSucursal.Location = New System.Drawing.Point(4, 22)
        Me.tbpSucursal.Name = "tbpSucursal"
        Me.tbpSucursal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSucursal.Size = New System.Drawing.Size(769, 326)
        Me.tbpSucursal.TabIndex = 0
        Me.tbpSucursal.Text = "Sucursal"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.LabelAsoc = Nothing
        Me.lblEmpresa.Location = New System.Drawing.Point(163, 13)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 40
        Me.lblEmpresa.Text = "Empresa"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BindearPropiedadControl = "SelectedValue"
        Me.cmbEmpresa.BindearPropiedadEntidad = "IdEmpresa"
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.IsPK = False
        Me.cmbEmpresa.IsRequired = True
        Me.cmbEmpresa.Key = Nothing
        Me.cmbEmpresa.LabelAsoc = Me.lblEmpresa
        Me.cmbEmpresa.Location = New System.Drawing.Point(217, 9)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(183, 21)
        Me.cmbEmpresa.TabIndex = 41
        '
        'chbPublicarEnWeb
        '
        Me.chbPublicarEnWeb.AutoSize = True
        Me.chbPublicarEnWeb.BindearPropiedadControl = "Checked"
        Me.chbPublicarEnWeb.BindearPropiedadEntidad = "PublicarEnWeb"
        Me.chbPublicarEnWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPublicarEnWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPublicarEnWeb.IsPK = False
        Me.chbPublicarEnWeb.IsRequired = False
        Me.chbPublicarEnWeb.Key = Nothing
        Me.chbPublicarEnWeb.LabelAsoc = Nothing
        Me.chbPublicarEnWeb.Location = New System.Drawing.Point(640, 293)
        Me.chbPublicarEnWeb.Name = "chbPublicarEnWeb"
        Me.chbPublicarEnWeb.Size = New System.Drawing.Size(105, 17)
        Me.chbPublicarEnWeb.TabIndex = 70
        Me.chbPublicarEnWeb.Text = "Publicar en Web"
        Me.chbPublicarEnWeb.UseVisualStyleBackColor = True
        '
        'chbSucursalAsociadaPrecios
        '
        Me.chbSucursalAsociadaPrecios.AutoSize = True
        Me.chbSucursalAsociadaPrecios.BindearPropiedadControl = ""
        Me.chbSucursalAsociadaPrecios.BindearPropiedadEntidad = ""
        Me.chbSucursalAsociadaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSucursalAsociadaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSucursalAsociadaPrecios.IsPK = False
        Me.chbSucursalAsociadaPrecios.IsRequired = False
        Me.chbSucursalAsociadaPrecios.Key = Nothing
        Me.chbSucursalAsociadaPrecios.LabelAsoc = Nothing
        Me.chbSucursalAsociadaPrecios.Location = New System.Drawing.Point(6, 248)
        Me.chbSucursalAsociadaPrecios.Name = "chbSucursalAsociadaPrecios"
        Me.chbSucursalAsociadaPrecios.Size = New System.Drawing.Size(152, 17)
        Me.chbSucursalAsociadaPrecios.TabIndex = 65
        Me.chbSucursalAsociadaPrecios.Text = "Sucursal Asociada Precios"
        Me.chbSucursalAsociadaPrecios.UseVisualStyleBackColor = True
        Me.chbSucursalAsociadaPrecios.Visible = False
        '
        'cmbSucursalAsociadaPrecios
        '
        Me.cmbSucursalAsociadaPrecios.BindearPropiedadControl = "SelectedValue"
        Me.cmbSucursalAsociadaPrecios.BindearPropiedadEntidad = "IdSucursalAsociadaPrecios"
        Me.cmbSucursalAsociadaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalAsociadaPrecios.Enabled = False
        Me.cmbSucursalAsociadaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalAsociadaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalAsociadaPrecios.FormattingEnabled = True
        Me.cmbSucursalAsociadaPrecios.IsPK = False
        Me.cmbSucursalAsociadaPrecios.IsRequired = False
        Me.cmbSucursalAsociadaPrecios.Key = Nothing
        Me.cmbSucursalAsociadaPrecios.LabelAsoc = Nothing
        Me.cmbSucursalAsociadaPrecios.Location = New System.Drawing.Point(169, 245)
        Me.cmbSucursalAsociadaPrecios.Name = "cmbSucursalAsociadaPrecios"
        Me.cmbSucursalAsociadaPrecios.Size = New System.Drawing.Size(179, 21)
        Me.cmbSucursalAsociadaPrecios.TabIndex = 66
        Me.cmbSucursalAsociadaPrecios.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(6, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Redes Sociales"
        '
        'TextBox1
        '
        Me.TextBox1.BindearPropiedadControl = "Text"
        Me.TextBox1.BindearPropiedadEntidad = "RedesSociales"
        Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
        Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Formato = ""
        Me.TextBox1.IsDecimal = False
        Me.TextBox1.IsNumber = False
        Me.TextBox1.IsPK = False
        Me.TextBox1.IsRequired = False
        Me.TextBox1.Key = ""
        Me.TextBox1.LabelAsoc = Me.Label4
        Me.TextBox1.Location = New System.Drawing.Point(111, 166)
        Me.TextBox1.MaxLength = 100
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(289, 20)
        Me.TextBox1.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(6, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Dirección Comercial"
        '
        'txtDireccionComercial
        '
        Me.txtDireccionComercial.BindearPropiedadControl = "Text"
        Me.txtDireccionComercial.BindearPropiedadEntidad = "DireccionComercial"
        Me.txtDireccionComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccionComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccionComercial.Formato = ""
        Me.txtDireccionComercial.IsDecimal = False
        Me.txtDireccionComercial.IsNumber = False
        Me.txtDireccionComercial.IsPK = False
        Me.txtDireccionComercial.IsRequired = True
        Me.txtDireccionComercial.Key = ""
        Me.txtDireccionComercial.LabelAsoc = Me.Label1
        Me.txtDireccionComercial.Location = New System.Drawing.Point(111, 88)
        Me.txtDireccionComercial.MaxLength = 50
        Me.txtDireccionComercial.Name = "txtDireccionComercial"
        Me.txtDireccionComercial.Size = New System.Drawing.Size(289, 20)
        Me.txtDireccionComercial.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(433, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Localidad Comercial"
        '
        'cmbLocalidadComercial
        '
        Me.cmbLocalidadComercial.BindearPropiedadControl = "SelectedValue"
        Me.cmbLocalidadComercial.BindearPropiedadEntidad = "LocalidadComercial.IdLocalidad"
        Me.cmbLocalidadComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidadComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidadComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidadComercial.FormattingEnabled = True
        Me.cmbLocalidadComercial.IsPK = False
        Me.cmbLocalidadComercial.IsRequired = True
        Me.cmbLocalidadComercial.Key = Nothing
        Me.cmbLocalidadComercial.LabelAsoc = Me.Label3
        Me.cmbLocalidadComercial.Location = New System.Drawing.Point(538, 82)
        Me.cmbLocalidadComercial.Name = "cmbLocalidadComercial"
        Me.cmbLocalidadComercial.Size = New System.Drawing.Size(205, 21)
        Me.cmbLocalidadComercial.TabIndex = 53
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTamano)
        Me.GroupBox1.Controls.Add(Me.pcbFoto)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarImagen)
        Me.GroupBox1.Controls.Add(Me.btnBuscarImagen)
        Me.GroupBox1.Location = New System.Drawing.Point(433, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 173)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Logo Empresa"
        '
        'lblTamano
        '
        Me.lblTamano.AutoSize = True
        Me.lblTamano.LabelAsoc = Nothing
        Me.lblTamano.Location = New System.Drawing.Point(157, 150)
        Me.lblTamano.Name = "lblTamano"
        Me.lblTamano.Size = New System.Drawing.Size(0, 13)
        Me.lblTamano.TabIndex = 2
        '
        'pcbFoto
        '
        Me.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pcbFoto.Location = New System.Drawing.Point(147, 20)
        Me.pcbFoto.Name = "pcbFoto"
        Me.pcbFoto.Size = New System.Drawing.Size(171, 121)
        Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFoto.TabIndex = 9
        Me.pcbFoto.TabStop = False
        Me.pcbFoto.Tag = "LOGOEMPRESA"
        '
        'btnLimpiarImagen
        '
        Me.btnLimpiarImagen.Location = New System.Drawing.Point(17, 85)
        Me.btnLimpiarImagen.Name = "btnLimpiarImagen"
        Me.btnLimpiarImagen.Size = New System.Drawing.Size(124, 33)
        Me.btnLimpiarImagen.TabIndex = 1
        Me.btnLimpiarImagen.Text = "&Limpiar imagen"
        Me.btnLimpiarImagen.UseVisualStyleBackColor = True
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.Location = New System.Drawing.Point(17, 29)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(124, 33)
        Me.btnBuscarImagen.TabIndex = 0
        Me.btnBuscarImagen.Text = "&Buscar imagen"
        Me.btnBuscarImagen.UseVisualStyleBackColor = True
        '
        'txtColor
        '
        Me.txtColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "ColorSucursal"
        Me.txtColor.Enabled = False
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Nothing
        Me.txtColor.Location = New System.Drawing.Point(169, 192)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 61
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(6, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Color Sucursal"
        '
        'btnLimpiarSucursal
        '
        Me.btnLimpiarSucursal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiarSucursal.Image = Global.Eniac.Win.My.Resources.Resources.brush3
        Me.btnLimpiarSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarSucursal.Location = New System.Drawing.Point(3, 283)
        Me.btnLimpiarSucursal.Name = "btnLimpiarSucursal"
        Me.btnLimpiarSucursal.Size = New System.Drawing.Size(131, 40)
        Me.btnLimpiarSucursal.TabIndex = 71
        Me.btnLimpiarSucursal.Text = "Limpia Sucursal"
        Me.btnLimpiarSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarSucursal.UseVisualStyleBackColor = True
        '
        'btnColorSucursal
        '
        Me.btnColorSucursal.Location = New System.Drawing.Point(257, 190)
        Me.btnColorSucursal.Name = "btnColorSucursal"
        Me.btnColorSucursal.Size = New System.Drawing.Size(75, 23)
        Me.btnColorSucursal.TabIndex = 62
        Me.btnColorSucursal.Text = "Color"
        Me.btnColorSucursal.UseVisualStyleBackColor = True
        '
        'chbSoyLaCentral
        '
        Me.chbSoyLaCentral.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbSoyLaCentral.AutoSize = True
        Me.chbSoyLaCentral.BindearPropiedadControl = "Checked"
        Me.chbSoyLaCentral.BindearPropiedadEntidad = "SoyLaCentral"
        Me.chbSoyLaCentral.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSoyLaCentral.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSoyLaCentral.IsPK = False
        Me.chbSoyLaCentral.IsRequired = False
        Me.chbSoyLaCentral.Key = Nothing
        Me.chbSoyLaCentral.LabelAsoc = Nothing
        Me.chbSoyLaCentral.Location = New System.Drawing.Point(539, 293)
        Me.chbSoyLaCentral.Name = "chbSoyLaCentral"
        Me.chbSoyLaCentral.Size = New System.Drawing.Size(95, 17)
        Me.chbSoyLaCentral.TabIndex = 69
        Me.chbSoyLaCentral.Text = "Soy La Central"
        Me.chbSoyLaCentral.UseVisualStyleBackColor = True
        '
        'chbEstoyAca
        '
        Me.chbEstoyAca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbEstoyAca.AutoSize = True
        Me.chbEstoyAca.BindearPropiedadControl = "Checked"
        Me.chbEstoyAca.BindearPropiedadEntidad = "EstoyAca"
        Me.chbEstoyAca.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstoyAca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstoyAca.IsPK = False
        Me.chbEstoyAca.IsRequired = False
        Me.chbEstoyAca.Key = Nothing
        Me.chbEstoyAca.LabelAsoc = Nothing
        Me.chbEstoyAca.Location = New System.Drawing.Point(459, 293)
        Me.chbEstoyAca.Name = "chbEstoyAca"
        Me.chbEstoyAca.Size = New System.Drawing.Size(74, 17)
        Me.chbEstoyAca.TabIndex = 68
        Me.chbEstoyAca.Text = "Estoy Acá"
        Me.chbEstoyAca.UseVisualStyleBackColor = True
        '
        'dtpFechaInicioActiv
        '
        Me.dtpFechaInicioActiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaInicioActiv.BindearPropiedadControl = "Value"
        Me.dtpFechaInicioActiv.BindearPropiedadEntidad = "FechaInicioActiv"
        Me.dtpFechaInicioActiv.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInicioActiv.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaInicioActiv.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaInicioActiv.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicioActiv.IsPK = False
        Me.dtpFechaInicioActiv.IsRequired = True
        Me.dtpFechaInicioActiv.Key = ""
        Me.dtpFechaInicioActiv.LabelAsoc = Me.lblFechaInicioActiv
        Me.dtpFechaInicioActiv.Location = New System.Drawing.Point(538, 3)
        Me.dtpFechaInicioActiv.Name = "dtpFechaInicioActiv"
        Me.dtpFechaInicioActiv.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaInicioActiv.TabIndex = 43
        '
        'lblFechaInicioActiv
        '
        Me.lblFechaInicioActiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaInicioActiv.AutoSize = True
        Me.lblFechaInicioActiv.LabelAsoc = Nothing
        Me.lblFechaInicioActiv.Location = New System.Drawing.Point(433, 7)
        Me.lblFechaInicioActiv.Name = "lblFechaInicioActiv"
        Me.lblFechaInicioActiv.Size = New System.Drawing.Size(90, 13)
        Me.lblFechaInicioActiv.TabIndex = 42
        Me.lblFechaInicioActiv.Text = "Inicio Actividades"
        '
        'txtIdSucursal
        '
        Me.txtIdSucursal.BindearPropiedadControl = "Text"
        Me.txtIdSucursal.BindearPropiedadEntidad = "IdSucursal"
        Me.txtIdSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSucursal.Formato = ""
        Me.txtIdSucursal.IsDecimal = False
        Me.txtIdSucursal.IsNumber = True
        Me.txtIdSucursal.IsPK = True
        Me.txtIdSucursal.IsRequired = True
        Me.txtIdSucursal.Key = ""
        Me.txtIdSucursal.LabelAsoc = Me.lblIdSucursal
        Me.txtIdSucursal.Location = New System.Drawing.Point(111, 10)
        Me.txtIdSucursal.MaxLength = 4
        Me.txtIdSucursal.Name = "txtIdSucursal"
        Me.txtIdSucursal.Size = New System.Drawing.Size(46, 20)
        Me.txtIdSucursal.TabIndex = 39
        Me.txtIdSucursal.Text = "0"
        Me.txtIdSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSucursal
        '
        Me.lblIdSucursal.AutoSize = True
        Me.lblIdSucursal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdSucursal.LabelAsoc = Nothing
        Me.lblIdSucursal.Location = New System.Drawing.Point(6, 13)
        Me.lblIdSucursal.Name = "lblIdSucursal"
        Me.lblIdSucursal.Size = New System.Drawing.Size(40, 13)
        Me.lblIdSucursal.TabIndex = 38
        Me.lblIdSucursal.Text = "Codigo"
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.LabelAsoc = Nothing
        Me.lblCorreo.Location = New System.Drawing.Point(6, 144)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(38, 13)
        Me.lblCorreo.TabIndex = 56
        Me.lblCorreo.Text = "Correo"
        '
        'txtCorreo
        '
        Me.txtCorreo.BindearPropiedadControl = "Text"
        Me.txtCorreo.BindearPropiedadEntidad = "Correo"
        Me.txtCorreo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCorreo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCorreo.Formato = ""
        Me.txtCorreo.IsDecimal = False
        Me.txtCorreo.IsNumber = False
        Me.txtCorreo.IsPK = False
        Me.txtCorreo.IsRequired = False
        Me.txtCorreo.Key = ""
        Me.txtCorreo.LabelAsoc = Me.lblCorreo
        Me.txtCorreo.Location = New System.Drawing.Point(111, 140)
        Me.txtCorreo.MaxLength = 100
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(289, 20)
        Me.txtCorreo.TabIndex = 57
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.LabelAsoc = Nothing
        Me.lblTelefono.Location = New System.Drawing.Point(6, 119)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
        Me.lblTelefono.TabIndex = 54
        Me.lblTelefono.Text = "Teléfono"
        '
        'txtTelefono
        '
        Me.txtTelefono.BindearPropiedadControl = "Text"
        Me.txtTelefono.BindearPropiedadEntidad = "Telefono"
        Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTelefono.Formato = ""
        Me.txtTelefono.IsDecimal = False
        Me.txtTelefono.IsNumber = False
        Me.txtTelefono.IsPK = False
        Me.txtTelefono.IsRequired = False
        Me.txtTelefono.Key = ""
        Me.txtTelefono.LabelAsoc = Me.lblTelefono
        Me.txtTelefono.Location = New System.Drawing.Point(111, 114)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(289, 20)
        Me.txtTelefono.TabIndex = 55
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.LabelAsoc = Nothing
        Me.lblDireccion.Location = New System.Drawing.Point(6, 63)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblDireccion.TabIndex = 46
        Me.lblDireccion.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.BindearPropiedadControl = "Text"
        Me.txtDireccion.BindearPropiedadEntidad = "Direccion"
        Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccion.Formato = ""
        Me.txtDireccion.IsDecimal = False
        Me.txtDireccion.IsNumber = False
        Me.txtDireccion.IsPK = False
        Me.txtDireccion.IsRequired = True
        Me.txtDireccion.Key = ""
        Me.txtDireccion.LabelAsoc = Me.lblDireccion
        Me.txtDireccion.Location = New System.Drawing.Point(111, 62)
        Me.txtDireccion.MaxLength = 50
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(289, 20)
        Me.txtDireccion.TabIndex = 47
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.LabelAsoc = Nothing
        Me.lblLocalidad.Location = New System.Drawing.Point(433, 58)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 48
        Me.lblLocalidad.Text = "Localidad"
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.BindearPropiedadControl = "SelectedValue"
        Me.cmbLocalidad.BindearPropiedadEntidad = "Localidad.IdLocalidad"
        Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.IsPK = False
        Me.cmbLocalidad.IsRequired = True
        Me.cmbLocalidad.Key = Nothing
        Me.cmbLocalidad.LabelAsoc = Me.lblLocalidad
        Me.cmbLocalidad.Location = New System.Drawing.Point(538, 55)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(205, 21)
        Me.cmbLocalidad.TabIndex = 49
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(6, 39)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 44
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "Nombre"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(111, 36)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(289, 20)
        Me.txtNombre.TabIndex = 45
        '
        'tbpFormasPago
        '
        Me.tbpFormasPago.BackColor = System.Drawing.SystemColors.Control
        Me.tbpFormasPago.Controls.Add(Me.btnLimpiarFormaDePago)
        Me.tbpFormasPago.Controls.Add(Me.lblFormaDePago)
        Me.tbpFormasPago.Controls.Add(Me.cmbFormaDePago)
        Me.tbpFormasPago.Controls.Add(Me.btnEliminarFormaDePago)
        Me.tbpFormasPago.Controls.Add(Me.btnAgregarFormaDePago)
        Me.tbpFormasPago.Controls.Add(Me.ugFormasDePago)
        Me.tbpFormasPago.Location = New System.Drawing.Point(4, 22)
        Me.tbpFormasPago.Name = "tbpFormasPago"
        Me.tbpFormasPago.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFormasPago.Size = New System.Drawing.Size(769, 326)
        Me.tbpFormasPago.TabIndex = 1
        Me.tbpFormasPago.Text = "Formas de Pago"
        '
        'btnLimpiarFormaDePago
        '
        Me.btnLimpiarFormaDePago.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarFormaDePago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiarFormaDePago.Location = New System.Drawing.Point(199, 32)
        Me.btnLimpiarFormaDePago.Name = "btnLimpiarFormaDePago"
        Me.btnLimpiarFormaDePago.Size = New System.Drawing.Size(29, 30)
        Me.btnLimpiarFormaDePago.TabIndex = 0
        Me.btnLimpiarFormaDePago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarFormaDePago.UseVisualStyleBackColor = True
        '
        'lblFormaDePago
        '
        Me.lblFormaDePago.AutoSize = True
        Me.lblFormaDePago.Location = New System.Drawing.Point(234, 41)
        Me.lblFormaDePago.Name = "lblFormaDePago"
        Me.lblFormaDePago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaDePago.TabIndex = 1
        Me.lblFormaDePago.Text = "Forma de Pago"
        '
        'cmbFormaDePago
        '
        Me.cmbFormaDePago.BindearPropiedadControl = Nothing
        Me.cmbFormaDePago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaDePago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaDePago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaDePago.FormattingEnabled = True
        Me.cmbFormaDePago.IsPK = False
        Me.cmbFormaDePago.IsRequired = False
        Me.cmbFormaDePago.Key = Nothing
        Me.cmbFormaDePago.LabelAsoc = Nothing
        Me.cmbFormaDePago.Location = New System.Drawing.Point(319, 38)
        Me.cmbFormaDePago.Name = "cmbFormaDePago"
        Me.cmbFormaDePago.Size = New System.Drawing.Size(176, 21)
        Me.cmbFormaDePago.TabIndex = 2
        '
        'btnEliminarFormaDePago
        '
        Me.btnEliminarFormaDePago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarFormaDePago.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnEliminarFormaDePago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarFormaDePago.Location = New System.Drawing.Point(534, 32)
        Me.btnEliminarFormaDePago.Name = "btnEliminarFormaDePago"
        Me.btnEliminarFormaDePago.Size = New System.Drawing.Size(30, 30)
        Me.btnEliminarFormaDePago.TabIndex = 4
        Me.btnEliminarFormaDePago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarFormaDePago.UseVisualStyleBackColor = True
        '
        'btnAgregarFormaDePago
        '
        Me.btnAgregarFormaDePago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarFormaDePago.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnAgregarFormaDePago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregarFormaDePago.Location = New System.Drawing.Point(501, 32)
        Me.btnAgregarFormaDePago.Name = "btnAgregarFormaDePago"
        Me.btnAgregarFormaDePago.Size = New System.Drawing.Size(30, 30)
        Me.btnAgregarFormaDePago.TabIndex = 3
        Me.btnAgregarFormaDePago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAgregarFormaDePago.UseVisualStyleBackColor = True
        '
        'ugFormasDePago
        '
        Me.ugFormasDePago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugFormasDePago.DisplayLayout.Appearance = Appearance1
        Me.ugFormasDePago.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "S."
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 31
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Código"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 54
        Appearance4.TextHAlignAsString = "Left"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 163
        Appearance5.TextHAlignAsString = "Left"
        UltraGridColumn4.CellAppearance = Appearance5
        UltraGridColumn4.Header.Caption = "Forma de Pago"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 380
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance6
        UltraGridColumn5.Header.Caption = "Orden Ventas"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 48
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance7
        UltraGridColumn6.Header.Caption = "Orden Compras"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 63
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance8
        UltraGridColumn7.Header.Caption = "Orden Fichas"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 52
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
        Me.ugFormasDePago.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugFormasDePago.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugFormasDePago.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugFormasDePago.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugFormasDePago.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugFormasDePago.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugFormasDePago.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugFormasDePago.DisplayLayout.MaxColScrollRegions = 1
        Me.ugFormasDePago.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugFormasDePago.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugFormasDePago.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugFormasDePago.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugFormasDePago.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugFormasDePago.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugFormasDePago.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugFormasDePago.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugFormasDePago.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugFormasDePago.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugFormasDePago.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugFormasDePago.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugFormasDePago.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugFormasDePago.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugFormasDePago.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugFormasDePago.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugFormasDePago.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugFormasDePago.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugFormasDePago.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugFormasDePago.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugFormasDePago.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugFormasDePago.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugFormasDePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ugFormasDePago.Location = New System.Drawing.Point(107, 68)
        Me.ugFormasDePago.Name = "ugFormasDePago"
        Me.ugFormasDePago.Size = New System.Drawing.Size(599, 230)
        Me.ugFormasDePago.TabIndex = 5
        Me.ugFormasDePago.Text = "Códigos Alternativos"
        '
        'txtSucursales
        '
        Me.txtSucursales.BindearPropiedadControl = "Text"
        Me.txtSucursales.BindearPropiedadEntidad = "NombreSucursalAsociada"
        Me.txtSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSucursales.Formato = ""
        Me.txtSucursales.IsDecimal = False
        Me.txtSucursales.IsNumber = False
        Me.txtSucursales.IsPK = False
        Me.txtSucursales.IsRequired = False
        Me.txtSucursales.Key = ""
        Me.txtSucursales.LabelAsoc = Me.lblSucursalAsociada
        Me.txtSucursales.Location = New System.Drawing.Point(169, 218)
        Me.txtSucursales.MaxLength = 100
        Me.txtSucursales.Name = "txtSucursales"
        Me.txtSucursales.ReadOnly = True
        Me.txtSucursales.Size = New System.Drawing.Size(179, 20)
        Me.txtSucursales.TabIndex = 72
        '
        'lblSucursalAsociada
        '
        Me.lblSucursalAsociada.AutoSize = True
        Me.lblSucursalAsociada.LabelAsoc = Nothing
        Me.lblSucursalAsociada.Location = New System.Drawing.Point(6, 221)
        Me.lblSucursalAsociada.Name = "lblSucursalAsociada"
        Me.lblSucursalAsociada.Size = New System.Drawing.Size(95, 13)
        Me.lblSucursalAsociada.TabIndex = 73
        Me.lblSucursalAsociada.Text = "Sucursal Asociada"
        '
        'SucursalesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(799, 407)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SucursalesDetalle"
        Me.Text = "Sucursal"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.tbcDetalle, 0)
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpSucursal.ResumeLayout(False)
        Me.tbpSucursal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpFormasPago.ResumeLayout(False)
        Me.tbpFormasPago.PerformLayout()
        CType(Me.ugFormasDePago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpSucursal As System.Windows.Forms.TabPage
   Friend WithEvents lblEmpresa As Eniac.Controles.Label
   Friend WithEvents cmbEmpresa As Eniac.Controles.ComboBox
   Friend WithEvents chbPublicarEnWeb As Eniac.Controles.CheckBox
   Friend WithEvents chbSucursalAsociadaPrecios As Eniac.Controles.CheckBox
   Public WithEvents cmbSucursalAsociadaPrecios As Eniac.Controles.ComboBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents TextBox1 As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtDireccionComercial As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbLocalidadComercial As Eniac.Controles.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lblTamano As Eniac.Controles.Label
   Friend WithEvents pcbFoto As System.Windows.Forms.PictureBox
   Friend WithEvents btnLimpiarImagen As Eniac.Controles.Button
   Friend WithEvents btnBuscarImagen As Eniac.Controles.Button
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents btnLimpiarSucursal As System.Windows.Forms.Button
   Friend WithEvents btnColorSucursal As System.Windows.Forms.Button
    Friend WithEvents chbSoyLaCentral As Eniac.Controles.CheckBox
    Friend WithEvents chbEstoyAca As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaInicioActiv As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaInicioActiv As Eniac.Controles.Label
   Friend WithEvents txtIdSucursal As Eniac.Controles.TextBox
   Friend WithEvents lblIdSucursal As Eniac.Controles.Label
   Friend WithEvents lblCorreo As Eniac.Controles.Label
   Friend WithEvents txtCorreo As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents tbpFormasPago As System.Windows.Forms.TabPage
   Friend WithEvents ugFormasDePago As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnEliminarFormaDePago As Eniac.Controles.Button
   Friend WithEvents btnAgregarFormaDePago As Eniac.Controles.Button
   Friend WithEvents lblFormaDePago As System.Windows.Forms.Label
   Friend WithEvents cmbFormaDePago As Eniac.Win.ComboBoxFormaDePago
   Friend WithEvents btnLimpiarFormaDePago As Eniac.Controles.Button
    Friend WithEvents txtSucursales As Controles.TextBox
    Friend WithEvents lblSucursalAsociada As Controles.Label
End Class
