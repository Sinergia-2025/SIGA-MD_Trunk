<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresorasAComprobantes
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpresorasAComprobantes))
      Me.lblImpresora = New Eniac.Controles.Label()
      Me.cmbImpresora = New Eniac.Controles.ComboBox()
      Me.grbAgregar = New System.Windows.Forms.GroupBox()
      Me.txtCantidadCopias = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.chbImprime = New Eniac.Controles.CheckBox()
      Me.txtCantItemsObservaciones = New Eniac.Controles.TextBox()
      Me.lblCantItemsObservaciones = New Eniac.Controles.Label()
      Me.txtCantItemsProductos = New Eniac.Controles.TextBox()
      Me.lblCantItemsProductos = New Eniac.Controles.Label()
      Me.txtServidor = New Eniac.Controles.TextBox()
      Me.lblServidor = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtArchivoAImprimir = New Eniac.Controles.TextBox()
      Me.lblArchivoAImprimir = New Eniac.Controles.Label()
      Me.chbArchivoEmbebido2 = New Eniac.Controles.CheckBox()
      Me.chbArchivoEmbebido = New Eniac.Controles.CheckBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.cmbComprobante = New Eniac.Controles.ComboBox()
      Me.lblComprobante = New Eniac.Controles.Label()
      Me.txtLetra = New Eniac.Controles.TextBox()
      Me.lblLetra = New Eniac.Controles.Label()
      Me.dgvImpComp = New Eniac.Controles.DataGridView()
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.txtArchivoAImprimirComplementario = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.chbArchivoAImprimirComplementarioEmbebido = New Eniac.Controles.CheckBox()
      Me.txtArchivoAImprimir2 = New Eniac.Controles.TextBox()
      Me.NombreComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ArchivoAImprimir = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ArchivoAImprimirEmbebido = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.NombreImpresora = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CantidadItemsProductos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CantidadItemsObservaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CantidadCopias = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Imprime = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ArchivoAImprimir2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ArchivoAImprimirEmbebido2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.ArchivoAImprimirComplementario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ArchivoAImprimirComplementarioEmbebido = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.grbAgregar.SuspendLayout()
      CType(Me.dgvImpComp, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tspFacturacion.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblImpresora
      '
      Me.lblImpresora.AutoSize = True
      Me.lblImpresora.LabelAsoc = Nothing
      Me.lblImpresora.Location = New System.Drawing.Point(469, 12)
      Me.lblImpresora.Name = "lblImpresora"
      Me.lblImpresora.Size = New System.Drawing.Size(53, 13)
      Me.lblImpresora.TabIndex = 7
      Me.lblImpresora.Text = "Impresora"
      '
      'cmbImpresora
      '
      Me.cmbImpresora.BindearPropiedadControl = Nothing
      Me.cmbImpresora.BindearPropiedadEntidad = Nothing
      Me.cmbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbImpresora.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbImpresora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbImpresora.FormattingEnabled = True
      Me.cmbImpresora.IsPK = False
      Me.cmbImpresora.IsRequired = False
      Me.cmbImpresora.Key = Nothing
      Me.cmbImpresora.LabelAsoc = Me.lblImpresora
      Me.cmbImpresora.Location = New System.Drawing.Point(472, 27)
      Me.cmbImpresora.Name = "cmbImpresora"
      Me.cmbImpresora.Size = New System.Drawing.Size(287, 21)
      Me.cmbImpresora.TabIndex = 8
      '
      'grbAgregar
      '
      Me.grbAgregar.Controls.Add(Me.txtArchivoAImprimirComplementario)
      Me.grbAgregar.Controls.Add(Me.Label3)
      Me.grbAgregar.Controls.Add(Me.chbArchivoAImprimirComplementarioEmbebido)
      Me.grbAgregar.Controls.Add(Me.txtCantidadCopias)
      Me.grbAgregar.Controls.Add(Me.Label1)
      Me.grbAgregar.Controls.Add(Me.chbImprime)
      Me.grbAgregar.Controls.Add(Me.txtCantItemsObservaciones)
      Me.grbAgregar.Controls.Add(Me.txtCantItemsProductos)
      Me.grbAgregar.Controls.Add(Me.lblCantItemsObservaciones)
      Me.grbAgregar.Controls.Add(Me.lblCantItemsProductos)
      Me.grbAgregar.Controls.Add(Me.txtServidor)
      Me.grbAgregar.Controls.Add(Me.lblServidor)
      Me.grbAgregar.Controls.Add(Me.txtArchivoAImprimir2)
      Me.grbAgregar.Controls.Add(Me.Label2)
      Me.grbAgregar.Controls.Add(Me.txtArchivoAImprimir)
      Me.grbAgregar.Controls.Add(Me.chbArchivoEmbebido2)
      Me.grbAgregar.Controls.Add(Me.lblArchivoAImprimir)
      Me.grbAgregar.Controls.Add(Me.chbArchivoEmbebido)
      Me.grbAgregar.Controls.Add(Me.btnEliminar)
      Me.grbAgregar.Controls.Add(Me.btnInsertar)
      Me.grbAgregar.Controls.Add(Me.cmbComprobante)
      Me.grbAgregar.Controls.Add(Me.lblComprobante)
      Me.grbAgregar.Controls.Add(Me.txtLetra)
      Me.grbAgregar.Controls.Add(Me.lblLetra)
      Me.grbAgregar.Controls.Add(Me.cmbImpresora)
      Me.grbAgregar.Controls.Add(Me.lblImpresora)
      Me.grbAgregar.Location = New System.Drawing.Point(6, 28)
      Me.grbAgregar.Name = "grbAgregar"
      Me.grbAgregar.Size = New System.Drawing.Size(927, 151)
      Me.grbAgregar.TabIndex = 0
      Me.grbAgregar.TabStop = False
      '
      'txtCantidadCopias
      '
      Me.txtCantidadCopias.BindearPropiedadControl = Nothing
      Me.txtCantidadCopias.BindearPropiedadEntidad = Nothing
      Me.txtCantidadCopias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtCantidadCopias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadCopias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadCopias.Formato = ""
      Me.txtCantidadCopias.IsDecimal = False
      Me.txtCantidadCopias.IsNumber = True
      Me.txtCantidadCopias.IsPK = False
      Me.txtCantidadCopias.IsRequired = True
      Me.txtCantidadCopias.Key = ""
      Me.txtCantidadCopias.LabelAsoc = Me.Label1
      Me.txtCantidadCopias.Location = New System.Drawing.Point(716, 111)
      Me.txtCantidadCopias.MaxLength = 3
      Me.txtCantidadCopias.Name = "txtCantidadCopias"
      Me.txtCantidadCopias.Size = New System.Drawing.Size(43, 20)
      Me.txtCantidadCopias.TabIndex = 23
      Me.txtCantidadCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(579, 114)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(84, 13)
      Me.Label1.TabIndex = 22
      Me.Label1.Text = "Cantidad Copias"
      '
      'chbImprime
      '
      Me.chbImprime.AutoSize = True
      Me.chbImprime.BindearPropiedadControl = "Checked"
      Me.chbImprime.BindearPropiedadEntidad = "Imprime"
      Me.chbImprime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbImprime.Checked = True
      Me.chbImprime.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbImprime.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprime.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprime.IsPK = False
      Me.chbImprime.IsRequired = False
      Me.chbImprime.Key = Nothing
      Me.chbImprime.LabelAsoc = Nothing
      Me.chbImprime.Location = New System.Drawing.Point(232, 29)
      Me.chbImprime.Name = "chbImprime"
      Me.chbImprime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbImprime.Size = New System.Drawing.Size(62, 17)
      Me.chbImprime.TabIndex = 4
      Me.chbImprime.Text = "Imprime"
      Me.chbImprime.UseVisualStyleBackColor = True
      '
      'txtCantItemsObservaciones
      '
      Me.txtCantItemsObservaciones.BindearPropiedadControl = Nothing
      Me.txtCantItemsObservaciones.BindearPropiedadEntidad = Nothing
      Me.txtCantItemsObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtCantItemsObservaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantItemsObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantItemsObservaciones.Formato = ""
      Me.txtCantItemsObservaciones.IsDecimal = False
      Me.txtCantItemsObservaciones.IsNumber = True
      Me.txtCantItemsObservaciones.IsPK = False
      Me.txtCantItemsObservaciones.IsRequired = True
      Me.txtCantItemsObservaciones.Key = ""
      Me.txtCantItemsObservaciones.LabelAsoc = Me.lblCantItemsObservaciones
      Me.txtCantItemsObservaciones.Location = New System.Drawing.Point(716, 85)
      Me.txtCantItemsObservaciones.MaxLength = 3
      Me.txtCantItemsObservaciones.Name = "txtCantItemsObservaciones"
      Me.txtCantItemsObservaciones.Size = New System.Drawing.Size(43, 20)
      Me.txtCantItemsObservaciones.TabIndex = 21
      Me.txtCantItemsObservaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblCantItemsObservaciones
      '
      Me.lblCantItemsObservaciones.AutoSize = True
      Me.lblCantItemsObservaciones.LabelAsoc = Nothing
      Me.lblCantItemsObservaciones.Location = New System.Drawing.Point(579, 88)
      Me.lblCantItemsObservaciones.Name = "lblCantItemsObservaciones"
      Me.lblCantItemsObservaciones.Size = New System.Drawing.Size(134, 13)
      Me.lblCantItemsObservaciones.TabIndex = 20
      Me.lblCantItemsObservaciones.Text = "Cant. Items Observaciones"
      '
      'txtCantItemsProductos
      '
      Me.txtCantItemsProductos.BindearPropiedadControl = Nothing
      Me.txtCantItemsProductos.BindearPropiedadEntidad = Nothing
      Me.txtCantItemsProductos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtCantItemsProductos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantItemsProductos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantItemsProductos.Formato = ""
      Me.txtCantItemsProductos.IsDecimal = False
      Me.txtCantItemsProductos.IsNumber = True
      Me.txtCantItemsProductos.IsPK = False
      Me.txtCantItemsProductos.IsRequired = True
      Me.txtCantItemsProductos.Key = ""
      Me.txtCantItemsProductos.LabelAsoc = Me.lblCantItemsProductos
      Me.txtCantItemsProductos.Location = New System.Drawing.Point(716, 59)
      Me.txtCantItemsProductos.MaxLength = 3
      Me.txtCantItemsProductos.Name = "txtCantItemsProductos"
      Me.txtCantItemsProductos.Size = New System.Drawing.Size(43, 20)
      Me.txtCantItemsProductos.TabIndex = 19
      Me.txtCantItemsProductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblCantItemsProductos
      '
      Me.lblCantItemsProductos.AutoSize = True
      Me.lblCantItemsProductos.LabelAsoc = Nothing
      Me.lblCantItemsProductos.Location = New System.Drawing.Point(579, 63)
      Me.lblCantItemsProductos.Name = "lblCantItemsProductos"
      Me.lblCantItemsProductos.Size = New System.Drawing.Size(111, 13)
      Me.lblCantItemsProductos.TabIndex = 18
      Me.lblCantItemsProductos.Text = "Cant. Items Productos"
      '
      'txtServidor
      '
      Me.txtServidor.BindearPropiedadControl = Nothing
      Me.txtServidor.BindearPropiedadEntidad = Nothing
      Me.txtServidor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtServidor.Formato = ""
      Me.txtServidor.IsDecimal = False
      Me.txtServidor.IsNumber = False
      Me.txtServidor.IsPK = False
      Me.txtServidor.IsRequired = False
      Me.txtServidor.Key = ""
      Me.txtServidor.LabelAsoc = Me.lblServidor
      Me.txtServidor.Location = New System.Drawing.Point(304, 27)
      Me.txtServidor.MaxLength = 30
      Me.txtServidor.Name = "txtServidor"
      Me.txtServidor.Size = New System.Drawing.Size(159, 20)
      Me.txtServidor.TabIndex = 6
      '
      'lblServidor
      '
      Me.lblServidor.AutoSize = True
      Me.lblServidor.LabelAsoc = Nothing
      Me.lblServidor.Location = New System.Drawing.Point(301, 12)
      Me.lblServidor.Name = "lblServidor"
      Me.lblServidor.Size = New System.Drawing.Size(46, 13)
      Me.lblServidor.TabIndex = 5
      Me.lblServidor.Text = "Servidor"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(14, 110)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(161, 13)
      Me.Label2.TabIndex = 15
      Me.Label2.Text = "Archivo a Imprimir 2 / en Dolares"
      '
      'txtArchivoAImprimir
      '
      Me.txtArchivoAImprimir.BindearPropiedadControl = Nothing
      Me.txtArchivoAImprimir.BindearPropiedadEntidad = Nothing
      Me.txtArchivoAImprimir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoAImprimir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoAImprimir.Formato = ""
      Me.txtArchivoAImprimir.IsDecimal = False
      Me.txtArchivoAImprimir.IsNumber = False
      Me.txtArchivoAImprimir.IsPK = False
      Me.txtArchivoAImprimir.IsRequired = False
      Me.txtArchivoAImprimir.Key = ""
      Me.txtArchivoAImprimir.LabelAsoc = Me.lblArchivoAImprimir
      Me.txtArchivoAImprimir.Location = New System.Drawing.Point(182, 60)
      Me.txtArchivoAImprimir.MaxLength = 100
      Me.txtArchivoAImprimir.Name = "txtArchivoAImprimir"
      Me.txtArchivoAImprimir.Size = New System.Drawing.Size(250, 20)
      Me.txtArchivoAImprimir.TabIndex = 10
      '
      'lblArchivoAImprimir
      '
      Me.lblArchivoAImprimir.AutoSize = True
      Me.lblArchivoAImprimir.LabelAsoc = Nothing
      Me.lblArchivoAImprimir.Location = New System.Drawing.Point(14, 62)
      Me.lblArchivoAImprimir.Name = "lblArchivoAImprimir"
      Me.lblArchivoAImprimir.Size = New System.Drawing.Size(90, 13)
      Me.lblArchivoAImprimir.TabIndex = 9
      Me.lblArchivoAImprimir.Text = "Archivo a Imprimir"
      '
      'chbArchivoEmbebido2
      '
      Me.chbArchivoEmbebido2.AutoSize = True
      Me.chbArchivoEmbebido2.BindearPropiedadControl = Nothing
      Me.chbArchivoEmbebido2.BindearPropiedadEntidad = Nothing
      Me.chbArchivoEmbebido2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbArchivoEmbebido2.ForeColorFocus = System.Drawing.Color.Red
      Me.chbArchivoEmbebido2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbArchivoEmbebido2.IsPK = False
      Me.chbArchivoEmbebido2.IsRequired = False
      Me.chbArchivoEmbebido2.Key = Nothing
      Me.chbArchivoEmbebido2.LabelAsoc = Nothing
      Me.chbArchivoEmbebido2.Location = New System.Drawing.Point(460, 115)
      Me.chbArchivoEmbebido2.Name = "chbArchivoEmbebido2"
      Me.chbArchivoEmbebido2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbArchivoEmbebido2.Size = New System.Drawing.Size(73, 17)
      Me.chbArchivoEmbebido2.TabIndex = 17
      Me.chbArchivoEmbebido2.Text = "Embebido"
      Me.chbArchivoEmbebido2.UseVisualStyleBackColor = True
      '
      'chbArchivoEmbebido
      '
      Me.chbArchivoEmbebido.AutoSize = True
      Me.chbArchivoEmbebido.BindearPropiedadControl = Nothing
      Me.chbArchivoEmbebido.BindearPropiedadEntidad = Nothing
      Me.chbArchivoEmbebido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbArchivoEmbebido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbArchivoEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbArchivoEmbebido.IsPK = False
      Me.chbArchivoEmbebido.IsRequired = False
      Me.chbArchivoEmbebido.Key = Nothing
      Me.chbArchivoEmbebido.LabelAsoc = Nothing
      Me.chbArchivoEmbebido.Location = New System.Drawing.Point(460, 62)
      Me.chbArchivoEmbebido.Name = "chbArchivoEmbebido"
      Me.chbArchivoEmbebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbArchivoEmbebido.Size = New System.Drawing.Size(73, 17)
      Me.chbArchivoEmbebido.TabIndex = 11
      Me.chbArchivoEmbebido.Text = "Embebido"
      Me.chbArchivoEmbebido.UseVisualStyleBackColor = True
      '
      'btnEliminar
      '
      Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminar.Location = New System.Drawing.Point(860, 63)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 25
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertar.Location = New System.Drawing.Point(817, 64)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 24
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'cmbComprobante
      '
      Me.cmbComprobante.BindearPropiedadControl = Nothing
      Me.cmbComprobante.BindearPropiedadEntidad = Nothing
      Me.cmbComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbComprobante.FormattingEnabled = True
      Me.cmbComprobante.IsPK = False
      Me.cmbComprobante.IsRequired = False
      Me.cmbComprobante.Key = Nothing
      Me.cmbComprobante.LabelAsoc = Me.lblComprobante
      Me.cmbComprobante.Location = New System.Drawing.Point(14, 26)
      Me.cmbComprobante.Name = "cmbComprobante"
      Me.cmbComprobante.Size = New System.Drawing.Size(159, 21)
      Me.cmbComprobante.TabIndex = 1
      '
      'lblComprobante
      '
      Me.lblComprobante.AutoSize = True
      Me.lblComprobante.LabelAsoc = Nothing
      Me.lblComprobante.Location = New System.Drawing.Point(11, 12)
      Me.lblComprobante.Name = "lblComprobante"
      Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblComprobante.TabIndex = 0
      Me.lblComprobante.Text = "Comprobante"
      '
      'txtLetra
      '
      Me.txtLetra.BindearPropiedadControl = Nothing
      Me.txtLetra.BindearPropiedadEntidad = Nothing
      Me.txtLetra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLetra.Formato = ""
      Me.txtLetra.IsDecimal = False
      Me.txtLetra.IsNumber = False
      Me.txtLetra.IsPK = False
      Me.txtLetra.IsRequired = False
      Me.txtLetra.Key = ""
      Me.txtLetra.LabelAsoc = Me.lblLetra
      Me.txtLetra.Location = New System.Drawing.Point(180, 26)
      Me.txtLetra.MaxLength = 1
      Me.txtLetra.Name = "txtLetra"
      Me.txtLetra.Size = New System.Drawing.Size(32, 20)
      Me.txtLetra.TabIndex = 3
      Me.txtLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblLetra
      '
      Me.lblLetra.AutoSize = True
      Me.lblLetra.LabelAsoc = Nothing
      Me.lblLetra.Location = New System.Drawing.Point(179, 12)
      Me.lblLetra.Name = "lblLetra"
      Me.lblLetra.Size = New System.Drawing.Size(31, 13)
      Me.lblLetra.TabIndex = 2
      Me.lblLetra.Text = "Letra"
      '
      'dgvImpComp
      '
      Me.dgvImpComp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreComprobante, Me.Letra, Me.ArchivoAImprimir, Me.ArchivoAImprimirEmbebido, Me.NombreImpresora, Me.TipoComprobante, Me.Password, Me.CantidadItemsProductos, Me.CantidadItemsObservaciones, Me.CantidadCopias, Me.Imprime, Me.IdSucursal, Me.Usuario, Me.ArchivoAImprimir2, Me.ArchivoAImprimirEmbebido2, Me.ArchivoAImprimirComplementario, Me.ArchivoAImprimirComplementarioEmbebido})
      Me.dgvImpComp.Location = New System.Drawing.Point(6, 185)
      Me.dgvImpComp.Name = "dgvImpComp"
      Me.dgvImpComp.RowHeadersVisible = False
      Me.dgvImpComp.Size = New System.Drawing.Size(927, 283)
      Me.dgvImpComp.TabIndex = 1
      '
      'tspFacturacion
      '
      Me.tspFacturacion.AllowItemReorder = True
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(937, 29)
      Me.tspFacturacion.TabIndex = 2
      Me.tspFacturacion.Text = "ToolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'txtArchivoAImprimirComplementario
      '
      Me.txtArchivoAImprimirComplementario.BindearPropiedadControl = Nothing
      Me.txtArchivoAImprimirComplementario.BindearPropiedadEntidad = Nothing
      Me.txtArchivoAImprimirComplementario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoAImprimirComplementario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoAImprimirComplementario.Formato = ""
      Me.txtArchivoAImprimirComplementario.IsDecimal = False
      Me.txtArchivoAImprimirComplementario.IsNumber = False
      Me.txtArchivoAImprimirComplementario.IsPK = False
      Me.txtArchivoAImprimirComplementario.IsRequired = False
      Me.txtArchivoAImprimirComplementario.Key = ""
      Me.txtArchivoAImprimirComplementario.LabelAsoc = Me.Label3
      Me.txtArchivoAImprimirComplementario.Location = New System.Drawing.Point(182, 86)
      Me.txtArchivoAImprimirComplementario.MaxLength = 100
      Me.txtArchivoAImprimirComplementario.Name = "txtArchivoAImprimirComplementario"
      Me.txtArchivoAImprimirComplementario.Size = New System.Drawing.Size(250, 20)
      Me.txtArchivoAImprimirComplementario.TabIndex = 13
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(14, 88)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(168, 13)
      Me.Label3.TabIndex = 12
      Me.Label3.Text = "Archivo a Imprimir Complementario"
      '
      'chbArchivoAImprimirComplementarioEmbebido
      '
      Me.chbArchivoAImprimirComplementarioEmbebido.AutoSize = True
      Me.chbArchivoAImprimirComplementarioEmbebido.BindearPropiedadControl = Nothing
      Me.chbArchivoAImprimirComplementarioEmbebido.BindearPropiedadEntidad = Nothing
      Me.chbArchivoAImprimirComplementarioEmbebido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbArchivoAImprimirComplementarioEmbebido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbArchivoAImprimirComplementarioEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbArchivoAImprimirComplementarioEmbebido.IsPK = False
      Me.chbArchivoAImprimirComplementarioEmbebido.IsRequired = False
      Me.chbArchivoAImprimirComplementarioEmbebido.Key = Nothing
      Me.chbArchivoAImprimirComplementarioEmbebido.LabelAsoc = Nothing
      Me.chbArchivoAImprimirComplementarioEmbebido.Location = New System.Drawing.Point(460, 89)
      Me.chbArchivoAImprimirComplementarioEmbebido.Name = "chbArchivoAImprimirComplementarioEmbebido"
      Me.chbArchivoAImprimirComplementarioEmbebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbArchivoAImprimirComplementarioEmbebido.Size = New System.Drawing.Size(73, 17)
      Me.chbArchivoAImprimirComplementarioEmbebido.TabIndex = 14
      Me.chbArchivoAImprimirComplementarioEmbebido.Text = "Embebido"
      Me.chbArchivoAImprimirComplementarioEmbebido.UseVisualStyleBackColor = True
      '
      'txtArchivoAImprimir2
      '
      Me.txtArchivoAImprimir2.BindearPropiedadControl = Nothing
      Me.txtArchivoAImprimir2.BindearPropiedadEntidad = Nothing
      Me.txtArchivoAImprimir2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoAImprimir2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoAImprimir2.Formato = ""
      Me.txtArchivoAImprimir2.IsDecimal = False
      Me.txtArchivoAImprimir2.IsNumber = False
      Me.txtArchivoAImprimir2.IsPK = False
      Me.txtArchivoAImprimir2.IsRequired = False
      Me.txtArchivoAImprimir2.Key = ""
      Me.txtArchivoAImprimir2.LabelAsoc = Me.Label2
      Me.txtArchivoAImprimir2.Location = New System.Drawing.Point(182, 112)
      Me.txtArchivoAImprimir2.MaxLength = 100
      Me.txtArchivoAImprimir2.Name = "txtArchivoAImprimir2"
      Me.txtArchivoAImprimir2.Size = New System.Drawing.Size(250, 20)
      Me.txtArchivoAImprimir2.TabIndex = 16
      '
      'NombreComprobante
      '
      Me.NombreComprobante.DataPropertyName = "NombreComprobante"
      Me.NombreComprobante.HeaderText = "Comprobante"
      Me.NombreComprobante.Name = "NombreComprobante"
      Me.NombreComprobante.ReadOnly = True
      Me.NombreComprobante.Width = 160
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle1
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.ReadOnly = True
      Me.Letra.Width = 40
      '
      'ArchivoAImprimir
      '
      Me.ArchivoAImprimir.DataPropertyName = "ArchivoAImprimir"
      Me.ArchivoAImprimir.HeaderText = "Archivo a Imprimir"
      Me.ArchivoAImprimir.Name = "ArchivoAImprimir"
      Me.ArchivoAImprimir.ReadOnly = True
      Me.ArchivoAImprimir.Width = 250
      '
      'ArchivoAImprimirEmbebido
      '
      Me.ArchivoAImprimirEmbebido.DataPropertyName = "ArchivoAImprimirEmbebido"
      Me.ArchivoAImprimirEmbebido.HeaderText = "Emb."
      Me.ArchivoAImprimirEmbebido.Name = "ArchivoAImprimirEmbebido"
      Me.ArchivoAImprimirEmbebido.ReadOnly = True
      Me.ArchivoAImprimirEmbebido.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.ArchivoAImprimirEmbebido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.ArchivoAImprimirEmbebido.Width = 40
      '
      'NombreImpresora
      '
      Me.NombreImpresora.DataPropertyName = "NombreImpresora"
      Me.NombreImpresora.HeaderText = "Impresora"
      Me.NombreImpresora.Name = "NombreImpresora"
      Me.NombreImpresora.ReadOnly = True
      Me.NombreImpresora.Width = 150
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "TipoComprobante"
      Me.TipoComprobante.HeaderText = "TipoComprobante"
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.Visible = False
      '
      'Password
      '
      Me.Password.DataPropertyName = "Password"
      Me.Password.HeaderText = "Password"
      Me.Password.Name = "Password"
      Me.Password.Visible = False
      '
      'CantidadItemsProductos
      '
      Me.CantidadItemsProductos.DataPropertyName = "CantidadItemsProductos"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CantidadItemsProductos.DefaultCellStyle = DataGridViewCellStyle2
      Me.CantidadItemsProductos.HeaderText = "Cant. Prod."
      Me.CantidadItemsProductos.Name = "CantidadItemsProductos"
      Me.CantidadItemsProductos.Width = 50
      '
      'CantidadItemsObservaciones
      '
      Me.CantidadItemsObservaciones.DataPropertyName = "CantidadItemsObservaciones"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CantidadItemsObservaciones.DefaultCellStyle = DataGridViewCellStyle3
      Me.CantidadItemsObservaciones.HeaderText = "Cant. Observ."
      Me.CantidadItemsObservaciones.Name = "CantidadItemsObservaciones"
      Me.CantidadItemsObservaciones.Width = 50
      '
      'CantidadCopias
      '
      Me.CantidadCopias.DataPropertyName = "CantidadCopias"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CantidadCopias.DefaultCellStyle = DataGridViewCellStyle4
      Me.CantidadCopias.HeaderText = "Cant. Copias"
      Me.CantidadCopias.Name = "CantidadCopias"
      Me.CantidadCopias.Width = 50
      '
      'Imprime
      '
      Me.Imprime.DataPropertyName = "Imprime"
      Me.Imprime.HeaderText = "Imprime"
      Me.Imprime.Name = "Imprime"
      Me.Imprime.ReadOnly = True
      Me.Imprime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.Imprime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.Imprime.Width = 50
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.Visible = False
      '
      'Usuario
      '
      Me.Usuario.DataPropertyName = "Usuario"
      Me.Usuario.HeaderText = "Usuario"
      Me.Usuario.Name = "Usuario"
      Me.Usuario.Visible = False
      '
      'ArchivoAImprimir2
      '
      Me.ArchivoAImprimir2.DataPropertyName = "ArchivoAImprimir2"
      Me.ArchivoAImprimir2.HeaderText = "Archivo a Imprimir 2 / Dolares"
      Me.ArchivoAImprimir2.Name = "ArchivoAImprimir2"
      Me.ArchivoAImprimir2.ReadOnly = True
      Me.ArchivoAImprimir2.Width = 250
      '
      'ArchivoAImprimirEmbebido2
      '
      Me.ArchivoAImprimirEmbebido2.DataPropertyName = "ArchivoAImprimirEmbebido2"
      Me.ArchivoAImprimirEmbebido2.HeaderText = "Emb. 2"
      Me.ArchivoAImprimirEmbebido2.Name = "ArchivoAImprimirEmbebido2"
      Me.ArchivoAImprimirEmbebido2.ReadOnly = True
      '
      'ArchivoAImprimirComplementario
      '
      Me.ArchivoAImprimirComplementario.DataPropertyName = "ArchivoAImprimirComplementario"
      Me.ArchivoAImprimirComplementario.HeaderText = "Archivo a Imprimir Complementario"
      Me.ArchivoAImprimirComplementario.Name = "ArchivoAImprimirComplementario"
      Me.ArchivoAImprimirComplementario.Width = 250
      '
      'ArchivoAImprimirComplementarioEmbebido
      '
      Me.ArchivoAImprimirComplementarioEmbebido.DataPropertyName = "ArchivoAImprimirComplementarioEmbebido"
      Me.ArchivoAImprimirComplementarioEmbebido.HeaderText = "Emb. Complementario"
      Me.ArchivoAImprimirComplementarioEmbebido.Name = "ArchivoAImprimirComplementarioEmbebido"
      '
      'ImpresorasAComprobantes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(937, 472)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Controls.Add(Me.dgvImpComp)
      Me.Controls.Add(Me.grbAgregar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ImpresorasAComprobantes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Asignar Impresora a Comprobante"
      Me.grbAgregar.ResumeLayout(False)
      Me.grbAgregar.PerformLayout()
      CType(Me.dgvImpComp, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblImpresora As Eniac.Controles.Label
   Friend WithEvents cmbImpresora As Eniac.Controles.ComboBox
   Friend WithEvents grbAgregar As System.Windows.Forms.GroupBox
   Friend WithEvents dgvImpComp As Eniac.Controles.DataGridView
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtLetra As Eniac.Controles.TextBox
   Friend WithEvents lblLetra As Eniac.Controles.Label
   Friend WithEvents cmbComprobante As Eniac.Controles.ComboBox
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents chbArchivoEmbebido As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoAImprimir As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoAImprimir As Eniac.Controles.Label
   Friend WithEvents txtServidor As Eniac.Controles.TextBox
   Friend WithEvents lblServidor As Eniac.Controles.Label
   Friend WithEvents lblCantItemsProductos As Eniac.Controles.Label
   Friend WithEvents lblCantItemsObservaciones As Eniac.Controles.Label
   Friend WithEvents txtCantItemsProductos As Eniac.Controles.TextBox
   Friend WithEvents txtCantItemsObservaciones As Eniac.Controles.TextBox
   Friend WithEvents chbImprime As Eniac.Controles.CheckBox
   Friend WithEvents txtCantidadCopias As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbArchivoEmbebido2 As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoAImprimirComplementario As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents chbArchivoAImprimirComplementarioEmbebido As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoAImprimir2 As Eniac.Controles.TextBox
   Friend WithEvents NombreComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ArchivoAImprimir As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ArchivoAImprimirEmbebido As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents NombreImpresora As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CantidadItemsProductos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CantidadItemsObservaciones As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CantidadCopias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Imprime As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ArchivoAImprimir2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ArchivoAImprimirEmbebido2 As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents ArchivoAImprimirComplementario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ArchivoAImprimirComplementarioEmbebido As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
