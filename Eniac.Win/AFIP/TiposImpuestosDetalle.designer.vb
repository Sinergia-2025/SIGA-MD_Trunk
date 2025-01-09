<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposImpuestosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposImpuestosDetalle))
      Me.txtIdTipoImpuesto = New Eniac.Controles.TextBox()
      Me.lblIdTipoImpuesto = New Eniac.Controles.Label()
      Me.lblNombreTipoImpuesto = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblTipo = New Eniac.Controles.Label()
      Me.txtTipo = New Eniac.Controles.TextBox()
      Me.bscCuentaCaja = New Eniac.Controles.Buscador()
      Me.bscNombreCuentaCaja = New Eniac.Controles.Buscador()
      Me.Label1 = New Eniac.Controles.Label()
      Me.UcCuentasCompras = New Eniac.Win.ucCuentas()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.UcCuentasVentas = New Eniac.Win.ucCuentas()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtAplicativoAfip = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtArticuloInciso = New Eniac.Controles.TextBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.txtCodigoArticuloInciso = New Eniac.Controles.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(307, 323)
        Me.btnAceptar.TabIndex = 17
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(393, 323)
        Me.btnCancelar.TabIndex = 18
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(206, 323)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(149, 323)
        '
        'txtIdTipoImpuesto
        '
        Me.txtIdTipoImpuesto.BindearPropiedadControl = "Text"
        Me.txtIdTipoImpuesto.BindearPropiedadEntidad = "IdTipoImpuesto"
        Me.txtIdTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTipoImpuesto.Formato = ""
        Me.txtIdTipoImpuesto.IsDecimal = False
        Me.txtIdTipoImpuesto.IsNumber = False
        Me.txtIdTipoImpuesto.IsPK = True
        Me.txtIdTipoImpuesto.IsRequired = True
        Me.txtIdTipoImpuesto.Key = ""
        Me.txtIdTipoImpuesto.LabelAsoc = Me.lblIdTipoImpuesto
        Me.txtIdTipoImpuesto.Location = New System.Drawing.Point(90, 17)
        Me.txtIdTipoImpuesto.MaxLength = 5
        Me.txtIdTipoImpuesto.Name = "txtIdTipoImpuesto"
        Me.txtIdTipoImpuesto.Size = New System.Drawing.Size(59, 20)
        Me.txtIdTipoImpuesto.TabIndex = 0
        '
        'lblIdTipoImpuesto
        '
        Me.lblIdTipoImpuesto.AutoSize = True
        Me.lblIdTipoImpuesto.LabelAsoc = Nothing
        Me.lblIdTipoImpuesto.Location = New System.Drawing.Point(11, 20)
        Me.lblIdTipoImpuesto.Name = "lblIdTipoImpuesto"
        Me.lblIdTipoImpuesto.Size = New System.Drawing.Size(40, 13)
        Me.lblIdTipoImpuesto.TabIndex = 8
        Me.lblIdTipoImpuesto.Text = "Codigo"
        '
        'lblNombreTipoImpuesto
        '
        Me.lblNombreTipoImpuesto.AutoSize = True
        Me.lblNombreTipoImpuesto.LabelAsoc = Nothing
        Me.lblNombreTipoImpuesto.Location = New System.Drawing.Point(10, 48)
        Me.lblNombreTipoImpuesto.Name = "lblNombreTipoImpuesto"
        Me.lblNombreTipoImpuesto.Size = New System.Drawing.Size(63, 13)
        Me.lblNombreTipoImpuesto.TabIndex = 9
        Me.lblNombreTipoImpuesto.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "NombreTipoImpuesto"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.lblNombreTipoImpuesto
        Me.txtDescripcion.Location = New System.Drawing.Point(90, 45)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(294, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(9, 75)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 10
        Me.lblTipo.Text = "Tipo"
        '
        'txtTipo
        '
        Me.txtTipo.BindearPropiedadControl = "Text"
        Me.txtTipo.BindearPropiedadEntidad = "Tipo"
        Me.txtTipo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipo.Formato = ""
        Me.txtTipo.IsDecimal = False
        Me.txtTipo.IsNumber = False
        Me.txtTipo.IsPK = False
        Me.txtTipo.IsRequired = True
        Me.txtTipo.Key = ""
        Me.txtTipo.LabelAsoc = Me.lblTipo
        Me.txtTipo.Location = New System.Drawing.Point(90, 71)
        Me.txtTipo.MaxLength = 15
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(118, 20)
        Me.txtTipo.TabIndex = 2
        '
        'bscCuentaCaja
        '
        Me.bscCuentaCaja.AyudaAncho = 608
        Me.bscCuentaCaja.BindearPropiedadControl = Nothing
        Me.bscCuentaCaja.BindearPropiedadEntidad = Nothing
        Me.bscCuentaCaja.ColumnasAlineacion = Nothing
        Me.bscCuentaCaja.ColumnasAncho = Nothing
        Me.bscCuentaCaja.ColumnasFormato = Nothing
        Me.bscCuentaCaja.ColumnasOcultas = Nothing
        Me.bscCuentaCaja.ColumnasTitulos = Nothing
        Me.bscCuentaCaja.Datos = Nothing
        Me.bscCuentaCaja.FilaDevuelta = Nothing
        Me.bscCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaCaja.IsDecimal = False
        Me.bscCuentaCaja.IsNumber = False
        Me.bscCuentaCaja.IsPK = False
        Me.bscCuentaCaja.IsRequired = False
        Me.bscCuentaCaja.Key = ""
        Me.bscCuentaCaja.LabelAsoc = Nothing
        Me.bscCuentaCaja.Location = New System.Drawing.Point(90, 100)
        Me.bscCuentaCaja.MaxLengh = "32767"
        Me.bscCuentaCaja.Name = "bscCuentaCaja"
        Me.bscCuentaCaja.Permitido = True
        Me.bscCuentaCaja.Selecciono = False
        Me.bscCuentaCaja.Size = New System.Drawing.Size(93, 23)
        Me.bscCuentaCaja.TabIndex = 3
        Me.bscCuentaCaja.Titulo = Nothing
        '
        'bscNombreCuentaCaja
        '
        Me.bscNombreCuentaCaja.AutoSize = True
        Me.bscNombreCuentaCaja.AyudaAncho = 608
        Me.bscNombreCuentaCaja.BindearPropiedadControl = Nothing
        Me.bscNombreCuentaCaja.BindearPropiedadEntidad = Nothing
        Me.bscNombreCuentaCaja.ColumnasAlineacion = Nothing
        Me.bscNombreCuentaCaja.ColumnasAncho = Nothing
        Me.bscNombreCuentaCaja.ColumnasFormato = Nothing
        Me.bscNombreCuentaCaja.ColumnasOcultas = Nothing
        Me.bscNombreCuentaCaja.ColumnasTitulos = Nothing
        Me.bscNombreCuentaCaja.Datos = Nothing
        Me.bscNombreCuentaCaja.FilaDevuelta = Nothing
        Me.bscNombreCuentaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuentaCaja.IsDecimal = False
        Me.bscNombreCuentaCaja.IsNumber = False
        Me.bscNombreCuentaCaja.IsPK = False
        Me.bscNombreCuentaCaja.IsRequired = False
        Me.bscNombreCuentaCaja.Key = ""
        Me.bscNombreCuentaCaja.LabelAsoc = Nothing
        Me.bscNombreCuentaCaja.Location = New System.Drawing.Point(185, 101)
        Me.bscNombreCuentaCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCuentaCaja.MaxLengh = "32767"
        Me.bscNombreCuentaCaja.Name = "bscNombreCuentaCaja"
        Me.bscNombreCuentaCaja.Permitido = True
        Me.bscNombreCuentaCaja.Selecciono = False
        Me.bscNombreCuentaCaja.Size = New System.Drawing.Size(277, 23)
        Me.bscNombreCuentaCaja.TabIndex = 4
        Me.bscNombreCuentaCaja.Titulo = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(9, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Cuenta de Caja"
        '
        'UcCuentasCompras
        '
        Me.UcCuentasCompras.Cuenta = Nothing
        Me.UcCuentasCompras.Location = New System.Drawing.Point(6, 19)
        Me.UcCuentasCompras.Name = "UcCuentasCompras"
        Me.UcCuentasCompras.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentasCompras.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UcCuentasCompras)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 49)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Compras / Pago a Proveedores"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UcCuentasVentas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 266)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 48)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ventas / Emisión de Recibos"
        '
        'UcCuentasVentas
        '
        Me.UcCuentasVentas.Cuenta = Nothing
        Me.UcCuentasVentas.Location = New System.Drawing.Point(6, 19)
        Me.UcCuentasVentas.Name = "UcCuentasVentas"
        Me.UcCuentasVentas.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentasVentas.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(9, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Aplicativo Afip"
        '
        'txtAplicativoAfip
        '
        Me.txtAplicativoAfip.BindearPropiedadControl = "Text"
        Me.txtAplicativoAfip.BindearPropiedadEntidad = "AplicativoAfip"
        Me.txtAplicativoAfip.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAplicativoAfip.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAplicativoAfip.Formato = ""
        Me.txtAplicativoAfip.IsDecimal = False
        Me.txtAplicativoAfip.IsNumber = False
        Me.txtAplicativoAfip.IsPK = False
        Me.txtAplicativoAfip.IsRequired = False
        Me.txtAplicativoAfip.Key = ""
        Me.txtAplicativoAfip.LabelAsoc = Me.Label2
        Me.txtAplicativoAfip.Location = New System.Drawing.Point(90, 130)
        Me.txtAplicativoAfip.MaxLength = 15
        Me.txtAplicativoAfip.Name = "txtAplicativoAfip"
        Me.txtAplicativoAfip.Size = New System.Drawing.Size(118, 20)
        Me.txtAplicativoAfip.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(9, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Artículo/Inciso para el cálculo"
        '
        'txtArticuloInciso
        '
        Me.txtArticuloInciso.BindearPropiedadControl = "Text"
        Me.txtArticuloInciso.BindearPropiedadEntidad = "ArticuloInciso"
        Me.txtArticuloInciso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArticuloInciso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArticuloInciso.Formato = ""
        Me.txtArticuloInciso.IsDecimal = False
        Me.txtArticuloInciso.IsNumber = False
        Me.txtArticuloInciso.IsPK = False
        Me.txtArticuloInciso.IsRequired = False
        Me.txtArticuloInciso.Key = ""
        Me.txtArticuloInciso.LabelAsoc = Me.Label3
        Me.txtArticuloInciso.Location = New System.Drawing.Point(163, 183)
        Me.txtArticuloInciso.MaxLength = 15
        Me.txtArticuloInciso.Name = "txtArticuloInciso"
        Me.txtArticuloInciso.Size = New System.Drawing.Size(45, 20)
        Me.txtArticuloInciso.TabIndex = 7
        Me.txtArticuloInciso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(9, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Código artículo inciso "
        '
        'txtCodigoArticuloInciso
        '
        Me.txtCodigoArticuloInciso.BindearPropiedadControl = "Text"
        Me.txtCodigoArticuloInciso.BindearPropiedadEntidad = "CodigoArticuloInciso"
        Me.txtCodigoArticuloInciso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoArticuloInciso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoArticuloInciso.Formato = ""
        Me.txtCodigoArticuloInciso.IsDecimal = False
        Me.txtCodigoArticuloInciso.IsNumber = False
        Me.txtCodigoArticuloInciso.IsPK = False
        Me.txtCodigoArticuloInciso.IsRequired = False
        Me.txtCodigoArticuloInciso.Key = ""
        Me.txtCodigoArticuloInciso.LabelAsoc = Me.Label4
        Me.txtCodigoArticuloInciso.Location = New System.Drawing.Point(163, 157)
        Me.txtCodigoArticuloInciso.MaxLength = 15
        Me.txtCodigoArticuloInciso.Name = "txtCodigoArticuloInciso"
        Me.txtCodigoArticuloInciso.Size = New System.Drawing.Size(45, 20)
        Me.txtCodigoArticuloInciso.TabIndex = 6
        Me.txtCodigoArticuloInciso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TiposImpuestosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(482, 358)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodigoArticuloInciso)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtArticuloInciso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAplicativoAfip)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bscCuentaCaja)
        Me.Controls.Add(Me.bscNombreCuentaCaja)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.lblNombreTipoImpuesto)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblIdTipoImpuesto)
        Me.Controls.Add(Me.txtIdTipoImpuesto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TiposImpuestosDetalle"
        Me.Text = "Tipo de Impuesto"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtIdTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.lblIdTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblNombreTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.txtTipo, 0)
        Me.Controls.SetChildIndex(Me.lblTipo, 0)
        Me.Controls.SetChildIndex(Me.bscNombreCuentaCaja, 0)
        Me.Controls.SetChildIndex(Me.bscCuentaCaja, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.txtAplicativoAfip, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtArticuloInciso, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoArticuloInciso, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdTipoImpuesto As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoImpuesto As Eniac.Controles.Label
   Friend WithEvents lblNombreTipoImpuesto As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents txtTipo As Eniac.Controles.TextBox
   Friend WithEvents bscCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents bscNombreCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents UcCuentasCompras As Eniac.Win.ucCuentas
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentasVentas As Eniac.Win.ucCuentas
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtAplicativoAfip As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents txtArticuloInciso As Eniac.Controles.TextBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents txtCodigoArticuloInciso As Eniac.Controles.TextBox

End Class
