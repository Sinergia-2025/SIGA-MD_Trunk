<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasFiscalesDetalle
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoriasFiscalesDetalle))
		Me.txtIdCategoriaFiscal = New Eniac.Controles.TextBox()
		Me.lblIdCategoriaFiscal = New Eniac.Controles.Label()
		Me.lblLetraFiscal = New Eniac.Controles.Label()
		Me.txtLetraFiscal = New Eniac.Controles.TextBox()
		Me.txtNombreCategoriaFiscal = New Eniac.Controles.TextBox()
		Me.lblNombreCategoriaFiscal = New Eniac.Controles.Label()
		Me.chbIvaDiscriminado = New Eniac.Controles.CheckBox()
		Me.LblCondicionIvaImpresoraFiscalEpson = New Eniac.Controles.Label()
		Me.txtCondicionIvaImpresoraFiscalEpson = New Eniac.Controles.TextBox()
		Me.LblNombreCategoriaFiscalAbrev = New Eniac.Controles.Label()
		Me.txtNombreCategoriaFiscalAbrev = New Eniac.Controles.TextBox()
		Me.lblLetraFiscalCompra = New Eniac.Controles.Label()
		Me.txtLetraFiscalCompra = New Eniac.Controles.TextBox()
		Me.chbActivo = New Eniac.Controles.CheckBox()
		Me.lblActivo = New Eniac.Controles.Label()
		Me.chbUtilizaImpuestos = New Eniac.Controles.CheckBox()
		Me.txtCondicionIvaImpresoraFiscalHasar = New Eniac.Controles.TextBox()
		Me.LblCondicionIvaImpresoraFiscalHasar = New Eniac.Controles.Label()
		Me.chbSolicitaCUIT = New Eniac.Controles.CheckBox()
		Me.chbEsPasiblePercIIBB = New Eniac.Controles.CheckBox()
		Me.chbUtilizaAlicuota2Producto = New Eniac.Controles.CheckBox()
		Me.txtCodigoExportacion = New Eniac.Controles.TextBox()
		Me.Label1 = New Eniac.Controles.Label()
		Me.lblLeyenda = New Eniac.Controles.Label()
		Me.TextBox1 = New Eniac.Controles.TextBox()
		Me.lblIvaCero = New Eniac.Controles.Label()
		Me.cmbIvaCero = New Eniac.Controles.ComboBox()
		Me.SuspendLayout()
		'
		'btnAceptar
		'
		Me.btnAceptar.Location = New System.Drawing.Point(169, 415)
		Me.btnAceptar.TabIndex = 23
		'
		'btnCancelar
		'
		Me.btnCancelar.Location = New System.Drawing.Point(255, 415)
		Me.btnCancelar.TabIndex = 24
		'
		'btnCopiar
		'
		Me.btnCopiar.Location = New System.Drawing.Point(68, 415)
		Me.btnCopiar.TabIndex = 28
		'
		'btnAplicar
		'
		Me.btnAplicar.Location = New System.Drawing.Point(8, 415)
		Me.btnAplicar.TabIndex = 27
		'
		'txtIdCategoriaFiscal
		'
		Me.txtIdCategoriaFiscal.BindearPropiedadControl = "Text"
		Me.txtIdCategoriaFiscal.BindearPropiedadEntidad = "IdCategoriaFiscal"
		Me.txtIdCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
		Me.txtIdCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtIdCategoriaFiscal.Formato = ""
		Me.txtIdCategoriaFiscal.IsDecimal = False
		Me.txtIdCategoriaFiscal.IsNumber = True
		Me.txtIdCategoriaFiscal.IsPK = True
		Me.txtIdCategoriaFiscal.IsRequired = True
		Me.txtIdCategoriaFiscal.Key = ""
		Me.txtIdCategoriaFiscal.LabelAsoc = Me.lblIdCategoriaFiscal
		Me.txtIdCategoriaFiscal.Location = New System.Drawing.Point(133, 13)
		Me.txtIdCategoriaFiscal.MaxLength = 2
		Me.txtIdCategoriaFiscal.Name = "txtIdCategoriaFiscal"
		Me.txtIdCategoriaFiscal.Size = New System.Drawing.Size(41, 20)
		Me.txtIdCategoriaFiscal.TabIndex = 1
		Me.txtIdCategoriaFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblIdCategoriaFiscal
		'
		Me.lblIdCategoriaFiscal.AutoSize = True
		Me.lblIdCategoriaFiscal.LabelAsoc = Nothing
		Me.lblIdCategoriaFiscal.Location = New System.Drawing.Point(15, 17)
		Me.lblIdCategoriaFiscal.Name = "lblIdCategoriaFiscal"
		Me.lblIdCategoriaFiscal.Size = New System.Drawing.Size(40, 13)
		Me.lblIdCategoriaFiscal.TabIndex = 0
		Me.lblIdCategoriaFiscal.Text = "Codigo"
		'
		'lblLetraFiscal
		'
		Me.lblLetraFiscal.AutoSize = True
		Me.lblLetraFiscal.LabelAsoc = Nothing
		Me.lblLetraFiscal.Location = New System.Drawing.Point(15, 123)
		Me.lblLetraFiscal.Name = "lblLetraFiscal"
		Me.lblLetraFiscal.Size = New System.Drawing.Size(107, 13)
		Me.lblLetraFiscal.TabIndex = 8
		Me.lblLetraFiscal.Text = "Letra Fiscal de Venta"
		'
		'txtLetraFiscal
		'
		Me.txtLetraFiscal.BindearPropiedadControl = "Text"
		Me.txtLetraFiscal.BindearPropiedadEntidad = "LetraFiscal"
		Me.txtLetraFiscal.ForeColorFocus = System.Drawing.Color.Red
		Me.txtLetraFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtLetraFiscal.Formato = ""
		Me.txtLetraFiscal.IsDecimal = False
		Me.txtLetraFiscal.IsNumber = False
		Me.txtLetraFiscal.IsPK = False
		Me.txtLetraFiscal.IsRequired = True
		Me.txtLetraFiscal.Key = ""
		Me.txtLetraFiscal.LabelAsoc = Me.lblLetraFiscal
		Me.txtLetraFiscal.Location = New System.Drawing.Point(133, 119)
		Me.txtLetraFiscal.MaxLength = 1
		Me.txtLetraFiscal.Name = "txtLetraFiscal"
		Me.txtLetraFiscal.Size = New System.Drawing.Size(29, 20)
		Me.txtLetraFiscal.TabIndex = 9
		Me.txtLetraFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'txtNombreCategoriaFiscal
		'
		Me.txtNombreCategoriaFiscal.BindearPropiedadControl = "Text"
		Me.txtNombreCategoriaFiscal.BindearPropiedadEntidad = "NombreCategoriaFiscal"
		Me.txtNombreCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
		Me.txtNombreCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtNombreCategoriaFiscal.Formato = ""
		Me.txtNombreCategoriaFiscal.IsDecimal = False
		Me.txtNombreCategoriaFiscal.IsNumber = False
		Me.txtNombreCategoriaFiscal.IsPK = False
		Me.txtNombreCategoriaFiscal.IsRequired = True
		Me.txtNombreCategoriaFiscal.Key = ""
		Me.txtNombreCategoriaFiscal.LabelAsoc = Me.lblNombreCategoriaFiscal
		Me.txtNombreCategoriaFiscal.Location = New System.Drawing.Point(133, 42)
		Me.txtNombreCategoriaFiscal.MaxLength = 40
		Me.txtNombreCategoriaFiscal.Name = "txtNombreCategoriaFiscal"
		Me.txtNombreCategoriaFiscal.Size = New System.Drawing.Size(200, 20)
		Me.txtNombreCategoriaFiscal.TabIndex = 3
		'
		'lblNombreCategoriaFiscal
		'
		Me.lblNombreCategoriaFiscal.AutoSize = True
		Me.lblNombreCategoriaFiscal.LabelAsoc = Nothing
		Me.lblNombreCategoriaFiscal.Location = New System.Drawing.Point(15, 46)
		Me.lblNombreCategoriaFiscal.Name = "lblNombreCategoriaFiscal"
		Me.lblNombreCategoriaFiscal.Size = New System.Drawing.Size(44, 13)
		Me.lblNombreCategoriaFiscal.TabIndex = 2
		Me.lblNombreCategoriaFiscal.Text = "Nombre"
		'
		'chbIvaDiscriminado
		'
		Me.chbIvaDiscriminado.AutoSize = True
		Me.chbIvaDiscriminado.BindearPropiedadControl = "Checked"
		Me.chbIvaDiscriminado.BindearPropiedadEntidad = "IvaDiscriminado"
		Me.chbIvaDiscriminado.ForeColorFocus = System.Drawing.Color.Red
		Me.chbIvaDiscriminado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbIvaDiscriminado.IsPK = False
		Me.chbIvaDiscriminado.IsRequired = False
		Me.chbIvaDiscriminado.Key = Nothing
		Me.chbIvaDiscriminado.LabelAsoc = Nothing
		Me.chbIvaDiscriminado.Location = New System.Drawing.Point(133, 176)
		Me.chbIvaDiscriminado.Name = "chbIvaDiscriminado"
		Me.chbIvaDiscriminado.Size = New System.Drawing.Size(94, 17)
		Me.chbIvaDiscriminado.TabIndex = 16
		Me.chbIvaDiscriminado.Text = "Discrimina IVA"
		Me.chbIvaDiscriminado.UseVisualStyleBackColor = True
		'
		'LblCondicionIvaImpresoraFiscalEpson
		'
		Me.LblCondicionIvaImpresoraFiscalEpson.AutoSize = True
		Me.LblCondicionIvaImpresoraFiscalEpson.LabelAsoc = Nothing
		Me.LblCondicionIvaImpresoraFiscalEpson.Location = New System.Drawing.Point(15, 149)
		Me.LblCondicionIvaImpresoraFiscalEpson.Name = "LblCondicionIvaImpresoraFiscalEpson"
		Me.LblCondicionIvaImpresoraFiscalEpson.Size = New System.Drawing.Size(110, 13)
		Me.LblCondicionIvaImpresoraFiscalEpson.TabIndex = 12
		Me.LblCondicionIvaImpresoraFiscalEpson.Text = "Código Fiscal EPSON"
		'
		'txtCondicionIvaImpresoraFiscalEpson
		'
		Me.txtCondicionIvaImpresoraFiscalEpson.BindearPropiedadControl = "Text"
		Me.txtCondicionIvaImpresoraFiscalEpson.BindearPropiedadEntidad = "CondicionIvaImpresoraFiscalEpson"
		Me.txtCondicionIvaImpresoraFiscalEpson.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCondicionIvaImpresoraFiscalEpson.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCondicionIvaImpresoraFiscalEpson.Formato = ""
		Me.txtCondicionIvaImpresoraFiscalEpson.IsDecimal = False
		Me.txtCondicionIvaImpresoraFiscalEpson.IsNumber = False
		Me.txtCondicionIvaImpresoraFiscalEpson.IsPK = False
		Me.txtCondicionIvaImpresoraFiscalEpson.IsRequired = True
		Me.txtCondicionIvaImpresoraFiscalEpson.Key = ""
		Me.txtCondicionIvaImpresoraFiscalEpson.LabelAsoc = Me.LblCondicionIvaImpresoraFiscalEpson
		Me.txtCondicionIvaImpresoraFiscalEpson.Location = New System.Drawing.Point(133, 145)
		Me.txtCondicionIvaImpresoraFiscalEpson.MaxLength = 1
		Me.txtCondicionIvaImpresoraFiscalEpson.Name = "txtCondicionIvaImpresoraFiscalEpson"
		Me.txtCondicionIvaImpresoraFiscalEpson.Size = New System.Drawing.Size(29, 20)
		Me.txtCondicionIvaImpresoraFiscalEpson.TabIndex = 13
		Me.txtCondicionIvaImpresoraFiscalEpson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'LblNombreCategoriaFiscalAbrev
		'
		Me.LblNombreCategoriaFiscalAbrev.AutoSize = True
		Me.LblNombreCategoriaFiscalAbrev.LabelAsoc = Nothing
		Me.LblNombreCategoriaFiscalAbrev.Location = New System.Drawing.Point(15, 71)
		Me.LblNombreCategoriaFiscalAbrev.Name = "LblNombreCategoriaFiscalAbrev"
		Me.LblNombreCategoriaFiscalAbrev.Size = New System.Drawing.Size(95, 13)
		Me.LblNombreCategoriaFiscalAbrev.TabIndex = 4
		Me.LblNombreCategoriaFiscalAbrev.Text = "Nombre Abreviado"
		'
		'txtNombreCategoriaFiscalAbrev
		'
		Me.txtNombreCategoriaFiscalAbrev.BindearPropiedadControl = "Text"
		Me.txtNombreCategoriaFiscalAbrev.BindearPropiedadEntidad = "NombreCategoriaFiscalAbrev"
		Me.txtNombreCategoriaFiscalAbrev.ForeColorFocus = System.Drawing.Color.Red
		Me.txtNombreCategoriaFiscalAbrev.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtNombreCategoriaFiscalAbrev.Formato = ""
		Me.txtNombreCategoriaFiscalAbrev.IsDecimal = False
		Me.txtNombreCategoriaFiscalAbrev.IsNumber = False
		Me.txtNombreCategoriaFiscalAbrev.IsPK = False
		Me.txtNombreCategoriaFiscalAbrev.IsRequired = True
		Me.txtNombreCategoriaFiscalAbrev.Key = ""
		Me.txtNombreCategoriaFiscalAbrev.LabelAsoc = Me.LblNombreCategoriaFiscalAbrev
		Me.txtNombreCategoriaFiscalAbrev.Location = New System.Drawing.Point(133, 67)
		Me.txtNombreCategoriaFiscalAbrev.MaxLength = 10
		Me.txtNombreCategoriaFiscalAbrev.Name = "txtNombreCategoriaFiscalAbrev"
		Me.txtNombreCategoriaFiscalAbrev.Size = New System.Drawing.Size(75, 20)
		Me.txtNombreCategoriaFiscalAbrev.TabIndex = 5
		'
		'lblLetraFiscalCompra
		'
		Me.lblLetraFiscalCompra.AutoSize = True
		Me.lblLetraFiscalCompra.LabelAsoc = Nothing
		Me.lblLetraFiscalCompra.Location = New System.Drawing.Point(186, 124)
		Me.lblLetraFiscalCompra.Name = "lblLetraFiscalCompra"
		Me.lblLetraFiscalCompra.Size = New System.Drawing.Size(115, 13)
		Me.lblLetraFiscalCompra.TabIndex = 10
		Me.lblLetraFiscalCompra.Text = "Letra Fiscal de Compra"
		'
		'txtLetraFiscalCompra
		'
		Me.txtLetraFiscalCompra.BindearPropiedadControl = "Text"
		Me.txtLetraFiscalCompra.BindearPropiedadEntidad = "LetraFiscalCompra"
		Me.txtLetraFiscalCompra.ForeColorFocus = System.Drawing.Color.Red
		Me.txtLetraFiscalCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtLetraFiscalCompra.Formato = ""
		Me.txtLetraFiscalCompra.IsDecimal = False
		Me.txtLetraFiscalCompra.IsNumber = False
		Me.txtLetraFiscalCompra.IsPK = False
		Me.txtLetraFiscalCompra.IsRequired = True
		Me.txtLetraFiscalCompra.Key = ""
		Me.txtLetraFiscalCompra.LabelAsoc = Me.lblLetraFiscalCompra
		Me.txtLetraFiscalCompra.Location = New System.Drawing.Point(304, 120)
		Me.txtLetraFiscalCompra.MaxLength = 1
		Me.txtLetraFiscalCompra.Name = "txtLetraFiscalCompra"
		Me.txtLetraFiscalCompra.Size = New System.Drawing.Size(29, 20)
		Me.txtLetraFiscalCompra.TabIndex = 11
		Me.txtLetraFiscalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'chbActivo
		'
		Me.chbActivo.AutoSize = True
		Me.chbActivo.BindearPropiedadControl = "Checked"
		Me.chbActivo.BindearPropiedadEntidad = "Activo"
		Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbActivo.IsPK = False
		Me.chbActivo.IsRequired = False
		Me.chbActivo.Key = Nothing
		Me.chbActivo.LabelAsoc = Me.lblActivo
		Me.chbActivo.Location = New System.Drawing.Point(319, 16)
		Me.chbActivo.Name = "chbActivo"
		Me.chbActivo.Size = New System.Drawing.Size(15, 14)
		Me.chbActivo.TabIndex = 26
		Me.chbActivo.UseVisualStyleBackColor = True
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.LabelAsoc = Nothing
		Me.lblActivo.Location = New System.Drawing.Point(276, 17)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 25
		Me.lblActivo.Text = "Activo"
		'
		'chbUtilizaImpuestos
		'
		Me.chbUtilizaImpuestos.AutoSize = True
		Me.chbUtilizaImpuestos.BindearPropiedadControl = "Checked"
		Me.chbUtilizaImpuestos.BindearPropiedadEntidad = "UtilizaImpuestos"
		Me.chbUtilizaImpuestos.ForeColorFocus = System.Drawing.Color.Red
		Me.chbUtilizaImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbUtilizaImpuestos.IsPK = False
		Me.chbUtilizaImpuestos.IsRequired = False
		Me.chbUtilizaImpuestos.Key = Nothing
		Me.chbUtilizaImpuestos.LabelAsoc = Nothing
		Me.chbUtilizaImpuestos.Location = New System.Drawing.Point(133, 199)
		Me.chbUtilizaImpuestos.Name = "chbUtilizaImpuestos"
		Me.chbUtilizaImpuestos.Size = New System.Drawing.Size(105, 17)
		Me.chbUtilizaImpuestos.TabIndex = 17
		Me.chbUtilizaImpuestos.Text = "Utiliza Impuestos"
		Me.chbUtilizaImpuestos.UseVisualStyleBackColor = True
		'
		'txtCondicionIvaImpresoraFiscalHasar
		'
		Me.txtCondicionIvaImpresoraFiscalHasar.BindearPropiedadControl = "Text"
		Me.txtCondicionIvaImpresoraFiscalHasar.BindearPropiedadEntidad = "CondicionIvaImpresoraFiscalHasar"
		Me.txtCondicionIvaImpresoraFiscalHasar.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCondicionIvaImpresoraFiscalHasar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCondicionIvaImpresoraFiscalHasar.Formato = ""
		Me.txtCondicionIvaImpresoraFiscalHasar.IsDecimal = False
		Me.txtCondicionIvaImpresoraFiscalHasar.IsNumber = False
		Me.txtCondicionIvaImpresoraFiscalHasar.IsPK = False
		Me.txtCondicionIvaImpresoraFiscalHasar.IsRequired = True
		Me.txtCondicionIvaImpresoraFiscalHasar.Key = ""
		Me.txtCondicionIvaImpresoraFiscalHasar.LabelAsoc = Me.LblCondicionIvaImpresoraFiscalHasar
		Me.txtCondicionIvaImpresoraFiscalHasar.Location = New System.Drawing.Point(304, 145)
		Me.txtCondicionIvaImpresoraFiscalHasar.MaxLength = 1
		Me.txtCondicionIvaImpresoraFiscalHasar.Name = "txtCondicionIvaImpresoraFiscalHasar"
		Me.txtCondicionIvaImpresoraFiscalHasar.Size = New System.Drawing.Size(29, 20)
		Me.txtCondicionIvaImpresoraFiscalHasar.TabIndex = 15
		Me.txtCondicionIvaImpresoraFiscalHasar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'LblCondicionIvaImpresoraFiscalHasar
		'
		Me.LblCondicionIvaImpresoraFiscalHasar.AutoSize = True
		Me.LblCondicionIvaImpresoraFiscalHasar.LabelAsoc = Nothing
		Me.LblCondicionIvaImpresoraFiscalHasar.Location = New System.Drawing.Point(191, 148)
		Me.LblCondicionIvaImpresoraFiscalHasar.Name = "LblCondicionIvaImpresoraFiscalHasar"
		Me.LblCondicionIvaImpresoraFiscalHasar.Size = New System.Drawing.Size(110, 13)
		Me.LblCondicionIvaImpresoraFiscalHasar.TabIndex = 14
		Me.LblCondicionIvaImpresoraFiscalHasar.Text = "Código Fiscal HASAR"
		'
		'chbSolicitaCUIT
		'
		Me.chbSolicitaCUIT.AutoSize = True
		Me.chbSolicitaCUIT.BindearPropiedadControl = "Checked"
		Me.chbSolicitaCUIT.BindearPropiedadEntidad = "SolicitaCUIT"
		Me.chbSolicitaCUIT.ForeColorFocus = System.Drawing.Color.Red
		Me.chbSolicitaCUIT.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbSolicitaCUIT.IsPK = False
		Me.chbSolicitaCUIT.IsRequired = False
		Me.chbSolicitaCUIT.Key = Nothing
		Me.chbSolicitaCUIT.LabelAsoc = Nothing
		Me.chbSolicitaCUIT.Location = New System.Drawing.Point(133, 222)
		Me.chbSolicitaCUIT.Name = "chbSolicitaCUIT"
		Me.chbSolicitaCUIT.Size = New System.Drawing.Size(88, 17)
		Me.chbSolicitaCUIT.TabIndex = 18
		Me.chbSolicitaCUIT.Text = "Solicita CUIT"
		Me.chbSolicitaCUIT.UseVisualStyleBackColor = True
		'
		'chbEsPasiblePercIIBB
		'
		Me.chbEsPasiblePercIIBB.AutoSize = True
		Me.chbEsPasiblePercIIBB.BindearPropiedadControl = "Checked"
		Me.chbEsPasiblePercIIBB.BindearPropiedadEntidad = "EsPasiblePercIIBB"
		Me.chbEsPasiblePercIIBB.ForeColorFocus = System.Drawing.Color.Red
		Me.chbEsPasiblePercIIBB.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbEsPasiblePercIIBB.IsPK = False
		Me.chbEsPasiblePercIIBB.IsRequired = False
		Me.chbEsPasiblePercIIBB.Key = Nothing
		Me.chbEsPasiblePercIIBB.LabelAsoc = Nothing
		Me.chbEsPasiblePercIIBB.Location = New System.Drawing.Point(133, 245)
		Me.chbEsPasiblePercIIBB.Name = "chbEsPasiblePercIIBB"
		Me.chbEsPasiblePercIIBB.Size = New System.Drawing.Size(155, 17)
		Me.chbEsPasiblePercIIBB.TabIndex = 19
		Me.chbEsPasiblePercIIBB.Text = "Es Pasible Percepción IIBB"
		Me.chbEsPasiblePercIIBB.UseVisualStyleBackColor = True
		'
		'chbUtilizaAlicuota2Producto
		'
		Me.chbUtilizaAlicuota2Producto.AutoSize = True
		Me.chbUtilizaAlicuota2Producto.BindearPropiedadControl = "Checked"
		Me.chbUtilizaAlicuota2Producto.BindearPropiedadEntidad = "UtilizaAlicuota2Producto"
		Me.chbUtilizaAlicuota2Producto.ForeColorFocus = System.Drawing.Color.Red
		Me.chbUtilizaAlicuota2Producto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbUtilizaAlicuota2Producto.IsPK = False
		Me.chbUtilizaAlicuota2Producto.IsRequired = False
		Me.chbUtilizaAlicuota2Producto.Key = Nothing
		Me.chbUtilizaAlicuota2Producto.LabelAsoc = Nothing
		Me.chbUtilizaAlicuota2Producto.Location = New System.Drawing.Point(133, 268)
		Me.chbUtilizaAlicuota2Producto.Name = "chbUtilizaAlicuota2Producto"
		Me.chbUtilizaAlicuota2Producto.Size = New System.Drawing.Size(167, 17)
		Me.chbUtilizaAlicuota2Producto.TabIndex = 20
		Me.chbUtilizaAlicuota2Producto.Text = "Utiliza Alícuota 2 de Producto"
		Me.chbUtilizaAlicuota2Producto.UseVisualStyleBackColor = True
		'
		'txtCodigoExportacion
		'
		Me.txtCodigoExportacion.BindearPropiedadControl = "Text"
		Me.txtCodigoExportacion.BindearPropiedadEntidad = "CodigoExportacion"
		Me.txtCodigoExportacion.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCodigoExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCodigoExportacion.Formato = ""
		Me.txtCodigoExportacion.IsDecimal = False
		Me.txtCodigoExportacion.IsNumber = False
		Me.txtCodigoExportacion.IsPK = False
		Me.txtCodigoExportacion.IsRequired = True
		Me.txtCodigoExportacion.Key = ""
		Me.txtCodigoExportacion.LabelAsoc = Me.Label1
		Me.txtCodigoExportacion.Location = New System.Drawing.Point(133, 93)
		Me.txtCodigoExportacion.MaxLength = 10
		Me.txtCodigoExportacion.Name = "txtCodigoExportacion"
		Me.txtCodigoExportacion.Size = New System.Drawing.Size(75, 20)
		Me.txtCodigoExportacion.TabIndex = 7
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.LabelAsoc = Nothing
		Me.Label1.Location = New System.Drawing.Point(15, 97)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(88, 13)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "Cod. Exportación"
		'
		'lblLeyenda
		'
		Me.lblLeyenda.AutoSize = True
		Me.lblLeyenda.LabelAsoc = Nothing
		Me.lblLeyenda.Location = New System.Drawing.Point(12, 298)
		Me.lblLeyenda.Name = "lblLeyenda"
		Me.lblLeyenda.Size = New System.Drawing.Size(48, 13)
		Me.lblLeyenda.TabIndex = 21
		Me.lblLeyenda.Text = "Leyenda"
		'
		'TextBox1
		'
		Me.TextBox1.BindearPropiedadControl = "Text"
		Me.TextBox1.BindearPropiedadEntidad = "LeyendaCategoriaFiscal"
		Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
		Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.TextBox1.Formato = ""
		Me.TextBox1.IsDecimal = False
		Me.TextBox1.IsNumber = False
		Me.TextBox1.IsPK = False
		Me.TextBox1.IsRequired = False
		Me.TextBox1.Key = ""
		Me.TextBox1.LabelAsoc = Me.lblLeyenda
		Me.TextBox1.Location = New System.Drawing.Point(133, 295)
		Me.TextBox1.MaxLength = 500
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.TextBox1.Size = New System.Drawing.Size(200, 59)
		Me.TextBox1.TabIndex = 22
		'
		'lblIvaCero
		'
		Me.lblIvaCero.AutoSize = True
		Me.lblIvaCero.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblIvaCero.LabelAsoc = Nothing
		Me.lblIvaCero.Location = New System.Drawing.Point(18, 373)
		Me.lblIvaCero.Name = "lblIvaCero"
		Me.lblIvaCero.Size = New System.Drawing.Size(49, 13)
		Me.lblIvaCero.TabIndex = 29
		Me.lblIvaCero.Text = "IVA Cero"
		'
		'cmbIvaCero
		'
		Me.cmbIvaCero.BindearPropiedadControl = "SelectedValue"
		Me.cmbIvaCero.BindearPropiedadEntidad = "IvaCeroCategoriaFiscal"
		Me.cmbIvaCero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbIvaCero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbIvaCero.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbIvaCero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbIvaCero.FormattingEnabled = True
		Me.cmbIvaCero.IsPK = False
		Me.cmbIvaCero.IsRequired = False
		Me.cmbIvaCero.Key = Nothing
		Me.cmbIvaCero.LabelAsoc = Me.lblIvaCero
		Me.cmbIvaCero.Location = New System.Drawing.Point(133, 370)
		Me.cmbIvaCero.Name = "cmbIvaCero"
		Me.cmbIvaCero.Size = New System.Drawing.Size(200, 21)
		Me.cmbIvaCero.TabIndex = 30
		Me.cmbIvaCero.Tag = ""
		'
		'CategoriasFiscalesDetalle
		'
		Me.AcceptButton = Nothing
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.ClientSize = New System.Drawing.Size(350, 457)
		Me.Controls.Add(Me.cmbIvaCero)
		Me.Controls.Add(Me.lblIvaCero)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.lblLeyenda)
		Me.Controls.Add(Me.txtCodigoExportacion)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.chbUtilizaAlicuota2Producto)
		Me.Controls.Add(Me.chbEsPasiblePercIIBB)
		Me.Controls.Add(Me.chbSolicitaCUIT)
		Me.Controls.Add(Me.txtCondicionIvaImpresoraFiscalHasar)
		Me.Controls.Add(Me.LblCondicionIvaImpresoraFiscalHasar)
		Me.Controls.Add(Me.chbUtilizaImpuestos)
		Me.Controls.Add(Me.lblActivo)
		Me.Controls.Add(Me.chbActivo)
		Me.Controls.Add(Me.txtLetraFiscalCompra)
		Me.Controls.Add(Me.lblLetraFiscalCompra)
		Me.Controls.Add(Me.txtNombreCategoriaFiscalAbrev)
		Me.Controls.Add(Me.LblNombreCategoriaFiscalAbrev)
		Me.Controls.Add(Me.txtCondicionIvaImpresoraFiscalEpson)
		Me.Controls.Add(Me.LblCondicionIvaImpresoraFiscalEpson)
		Me.Controls.Add(Me.chbIvaDiscriminado)
		Me.Controls.Add(Me.lblNombreCategoriaFiscal)
		Me.Controls.Add(Me.txtNombreCategoriaFiscal)
		Me.Controls.Add(Me.lblLetraFiscal)
		Me.Controls.Add(Me.txtLetraFiscal)
		Me.Controls.Add(Me.lblIdCategoriaFiscal)
		Me.Controls.Add(Me.txtIdCategoriaFiscal)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "CategoriasFiscalesDetalle"
		Me.Text = "Categoria Fiscal"
		Me.Controls.SetChildIndex(Me.btnAplicar, 0)
		Me.Controls.SetChildIndex(Me.btnCopiar, 0)
		Me.Controls.SetChildIndex(Me.txtIdCategoriaFiscal, 0)
		Me.Controls.SetChildIndex(Me.lblIdCategoriaFiscal, 0)
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.btnAceptar, 0)
		Me.Controls.SetChildIndex(Me.txtLetraFiscal, 0)
		Me.Controls.SetChildIndex(Me.lblLetraFiscal, 0)
		Me.Controls.SetChildIndex(Me.txtNombreCategoriaFiscal, 0)
		Me.Controls.SetChildIndex(Me.lblNombreCategoriaFiscal, 0)
		Me.Controls.SetChildIndex(Me.chbIvaDiscriminado, 0)
		Me.Controls.SetChildIndex(Me.LblCondicionIvaImpresoraFiscalEpson, 0)
		Me.Controls.SetChildIndex(Me.txtCondicionIvaImpresoraFiscalEpson, 0)
		Me.Controls.SetChildIndex(Me.LblNombreCategoriaFiscalAbrev, 0)
		Me.Controls.SetChildIndex(Me.txtNombreCategoriaFiscalAbrev, 0)
		Me.Controls.SetChildIndex(Me.lblLetraFiscalCompra, 0)
		Me.Controls.SetChildIndex(Me.txtLetraFiscalCompra, 0)
		Me.Controls.SetChildIndex(Me.chbActivo, 0)
		Me.Controls.SetChildIndex(Me.lblActivo, 0)
		Me.Controls.SetChildIndex(Me.chbUtilizaImpuestos, 0)
		Me.Controls.SetChildIndex(Me.LblCondicionIvaImpresoraFiscalHasar, 0)
		Me.Controls.SetChildIndex(Me.txtCondicionIvaImpresoraFiscalHasar, 0)
		Me.Controls.SetChildIndex(Me.chbSolicitaCUIT, 0)
		Me.Controls.SetChildIndex(Me.chbEsPasiblePercIIBB, 0)
		Me.Controls.SetChildIndex(Me.chbUtilizaAlicuota2Producto, 0)
		Me.Controls.SetChildIndex(Me.Label1, 0)
		Me.Controls.SetChildIndex(Me.txtCodigoExportacion, 0)
		Me.Controls.SetChildIndex(Me.lblLeyenda, 0)
		Me.Controls.SetChildIndex(Me.TextBox1, 0)
		Me.Controls.SetChildIndex(Me.lblIvaCero, 0)
		Me.Controls.SetChildIndex(Me.cmbIvaCero, 0)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtIdCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblIdCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents lblLetraFiscal As Eniac.Controles.Label
   Friend WithEvents txtLetraFiscal As Eniac.Controles.TextBox
   Friend WithEvents txtNombreCategoriaFiscal As Eniac.Controles.TextBox
   Friend WithEvents lblNombreCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents chbIvaDiscriminado As Eniac.Controles.CheckBox
   Friend WithEvents LblCondicionIvaImpresoraFiscalEpson As Eniac.Controles.Label
   Friend WithEvents txtCondicionIvaImpresoraFiscalEpson As Eniac.Controles.TextBox
   Friend WithEvents LblNombreCategoriaFiscalAbrev As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoriaFiscalAbrev As Eniac.Controles.TextBox
   Friend WithEvents lblLetraFiscalCompra As Eniac.Controles.Label
   Friend WithEvents txtLetraFiscalCompra As Eniac.Controles.TextBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents lblActivo As Eniac.Controles.Label
   Friend WithEvents chbUtilizaImpuestos As Eniac.Controles.CheckBox
   Friend WithEvents txtCondicionIvaImpresoraFiscalHasar As Eniac.Controles.TextBox
   Friend WithEvents LblCondicionIvaImpresoraFiscalHasar As Eniac.Controles.Label
   Friend WithEvents chbSolicitaCUIT As Eniac.Controles.CheckBox
   Friend WithEvents chbEsPasiblePercIIBB As Eniac.Controles.CheckBox
   Friend WithEvents chbUtilizaAlicuota2Producto As Eniac.Controles.CheckBox
   Friend WithEvents txtCodigoExportacion As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents lblLeyenda As Controles.Label
    Friend WithEvents TextBox1 As Controles.TextBox
	Friend WithEvents cmbIvaCero As Controles.ComboBox
	Friend WithEvents lblIvaCero As Controles.Label
End Class
