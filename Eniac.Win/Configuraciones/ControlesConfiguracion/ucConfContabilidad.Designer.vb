<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfContabilidad
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblPermiteCambiarCentroCostos = New Eniac.Controles.Label()
      Me.lblPermiteCambiarCentroCostosCompras = New Eniac.Controles.Label()
      Me.lblPermiteCambiarCentroCostosVentas = New Eniac.Controles.Label()
      Me.lblPermiteCambiarCentroCostosCaja = New Eniac.Controles.Label()
      Me.lblPermiteCambiarCentroCostosBanco = New Eniac.Controles.Label()
      Me.chbPermiteCambiarCentroCostosCompras = New Eniac.Controles.CheckBox()
      Me.chbPermiteCambiarCentroCostosVentas = New Eniac.Controles.CheckBox()
      Me.chbPermiteCambiarCentroCostosCaja = New Eniac.Controles.CheckBox()
      Me.chbPermiteCambiarCentroCostosBanco = New Eniac.Controles.CheckBox()
      Me.txtContabilidadRedondeoImporteMaximo = New Eniac.Controles.TextBox()
      Me.lblContabilidadRedondeoImporteMaximo = New Eniac.Controles.Label()
      Me.lblFormatoExportacion = New Eniac.Controles.Label()
      Me.lblCuentaContabilidadRedondeo = New Eniac.Controles.Label()
      Me.lblContabilidadCompras = New Eniac.Controles.Label()
      Me.lblContabilidadVentas = New Eniac.Controles.Label()
      Me.chbUtilizaCentroCostos = New Eniac.Controles.CheckBox()
      Me.chbCuentaSecundariaCategoria = New Eniac.Controles.CheckBox()
      Me.chbCuentaSecundariaProducto = New Eniac.Controles.CheckBox()
      Me.chbContabilidadEjecutarEnLinea = New Eniac.Controles.CheckBox()
      Me.ucCuentaContabilidadRedondeo = New Eniac.Win.ucCuentas()
      Me.ucCuentaContabilidadCompras = New Eniac.Win.ucCuentas()
      Me.ucCuentaContabilidadVentas = New Eniac.Win.ucCuentas()
      Me.cmbFormatoExportacion = New Eniac.Controles.ComboBox()
        Me.grpCerrarPeriodoConAsientoPermitir = New System.Windows.Forms.GroupBox()
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir = New System.Windows.Forms.RadioButton()
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir = New System.Windows.Forms.RadioButton()
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpCerrarPeriodoConAsientoPermitir.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblPermiteCambiarCentroCostos, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPermiteCambiarCentroCostosCompras, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPermiteCambiarCentroCostosVentas, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPermiteCambiarCentroCostosCaja, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPermiteCambiarCentroCostosBanco, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbPermiteCambiarCentroCostosCompras, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chbPermiteCambiarCentroCostosVentas, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chbPermiteCambiarCentroCostosCaja, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chbPermiteCambiarCentroCostosBanco, 4, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(409, 238)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(447, 34)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'lblPermiteCambiarCentroCostos
        '
        Me.lblPermiteCambiarCentroCostos.AutoSize = True
        Me.lblPermiteCambiarCentroCostos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPermiteCambiarCentroCostos.LabelAsoc = Nothing
        Me.lblPermiteCambiarCentroCostos.Location = New System.Drawing.Point(3, 13)
        Me.lblPermiteCambiarCentroCostos.Name = "lblPermiteCambiarCentroCostos"
        Me.lblPermiteCambiarCentroCostos.Size = New System.Drawing.Size(184, 13)
        Me.lblPermiteCambiarCentroCostos.TabIndex = 0
        Me.lblPermiteCambiarCentroCostos.Text = "Permite cambiar Centro de Costos en "
        '
        'lblPermiteCambiarCentroCostosCompras
        '
        Me.lblPermiteCambiarCentroCostosCompras.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPermiteCambiarCentroCostosCompras.AutoSize = True
        Me.lblPermiteCambiarCentroCostosCompras.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPermiteCambiarCentroCostosCompras.LabelAsoc = Nothing
        Me.lblPermiteCambiarCentroCostosCompras.Location = New System.Drawing.Point(198, 0)
        Me.lblPermiteCambiarCentroCostosCompras.Name = "lblPermiteCambiarCentroCostosCompras"
        Me.lblPermiteCambiarCentroCostosCompras.Size = New System.Drawing.Size(48, 13)
        Me.lblPermiteCambiarCentroCostosCompras.TabIndex = 1
        Me.lblPermiteCambiarCentroCostosCompras.Text = "Compras"
        '
        'lblPermiteCambiarCentroCostosVentas
        '
        Me.lblPermiteCambiarCentroCostosVentas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPermiteCambiarCentroCostosVentas.AutoSize = True
        Me.lblPermiteCambiarCentroCostosVentas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPermiteCambiarCentroCostosVentas.LabelAsoc = Nothing
        Me.lblPermiteCambiarCentroCostosVentas.Location = New System.Drawing.Point(266, 0)
        Me.lblPermiteCambiarCentroCostosVentas.Name = "lblPermiteCambiarCentroCostosVentas"
        Me.lblPermiteCambiarCentroCostosVentas.Size = New System.Drawing.Size(40, 13)
        Me.lblPermiteCambiarCentroCostosVentas.TabIndex = 3
        Me.lblPermiteCambiarCentroCostosVentas.Text = "Ventas"
        '
        'lblPermiteCambiarCentroCostosCaja
        '
        Me.lblPermiteCambiarCentroCostosCaja.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPermiteCambiarCentroCostosCaja.AutoSize = True
        Me.lblPermiteCambiarCentroCostosCaja.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPermiteCambiarCentroCostosCaja.LabelAsoc = Nothing
        Me.lblPermiteCambiarCentroCostosCaja.Location = New System.Drawing.Point(336, 0)
        Me.lblPermiteCambiarCentroCostosCaja.Name = "lblPermiteCambiarCentroCostosCaja"
        Me.lblPermiteCambiarCentroCostosCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblPermiteCambiarCentroCostosCaja.TabIndex = 5
        Me.lblPermiteCambiarCentroCostosCaja.Text = "Caja"
        '
        'lblPermiteCambiarCentroCostosBanco
        '
        Me.lblPermiteCambiarCentroCostosBanco.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPermiteCambiarCentroCostosBanco.AutoSize = True
        Me.lblPermiteCambiarCentroCostosBanco.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPermiteCambiarCentroCostosBanco.LabelAsoc = Nothing
        Me.lblPermiteCambiarCentroCostosBanco.Location = New System.Drawing.Point(395, 0)
        Me.lblPermiteCambiarCentroCostosBanco.Name = "lblPermiteCambiarCentroCostosBanco"
        Me.lblPermiteCambiarCentroCostosBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblPermiteCambiarCentroCostosBanco.TabIndex = 7
        Me.lblPermiteCambiarCentroCostosBanco.Text = "Banco"
        '
        'chbPermiteCambiarCentroCostosCompras
        '
        Me.chbPermiteCambiarCentroCostosCompras.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chbPermiteCambiarCentroCostosCompras.AutoSize = True
        Me.chbPermiteCambiarCentroCostosCompras.BindearPropiedadControl = Nothing
        Me.chbPermiteCambiarCentroCostosCompras.BindearPropiedadEntidad = Nothing
        Me.chbPermiteCambiarCentroCostosCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteCambiarCentroCostosCompras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteCambiarCentroCostosCompras.IsPK = False
        Me.chbPermiteCambiarCentroCostosCompras.IsRequired = False
        Me.chbPermiteCambiarCentroCostosCompras.Key = Nothing
        Me.chbPermiteCambiarCentroCostosCompras.LabelAsoc = Me.lblPermiteCambiarCentroCostosCompras
        Me.chbPermiteCambiarCentroCostosCompras.Location = New System.Drawing.Point(214, 16)
        Me.chbPermiteCambiarCentroCostosCompras.Name = "chbPermiteCambiarCentroCostosCompras"
        Me.chbPermiteCambiarCentroCostosCompras.Size = New System.Drawing.Size(15, 14)
        Me.chbPermiteCambiarCentroCostosCompras.TabIndex = 2
        Me.chbPermiteCambiarCentroCostosCompras.UseVisualStyleBackColor = True
        '
        'chbPermiteCambiarCentroCostosVentas
        '
        Me.chbPermiteCambiarCentroCostosVentas.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chbPermiteCambiarCentroCostosVentas.AutoSize = True
        Me.chbPermiteCambiarCentroCostosVentas.BindearPropiedadControl = Nothing
        Me.chbPermiteCambiarCentroCostosVentas.BindearPropiedadEntidad = Nothing
        Me.chbPermiteCambiarCentroCostosVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteCambiarCentroCostosVentas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteCambiarCentroCostosVentas.IsPK = False
        Me.chbPermiteCambiarCentroCostosVentas.IsRequired = False
        Me.chbPermiteCambiarCentroCostosVentas.Key = Nothing
        Me.chbPermiteCambiarCentroCostosVentas.LabelAsoc = Me.lblPermiteCambiarCentroCostosVentas
        Me.chbPermiteCambiarCentroCostosVentas.Location = New System.Drawing.Point(278, 16)
        Me.chbPermiteCambiarCentroCostosVentas.Name = "chbPermiteCambiarCentroCostosVentas"
        Me.chbPermiteCambiarCentroCostosVentas.Size = New System.Drawing.Size(15, 14)
        Me.chbPermiteCambiarCentroCostosVentas.TabIndex = 4
        Me.chbPermiteCambiarCentroCostosVentas.UseVisualStyleBackColor = True
        '
        'chbPermiteCambiarCentroCostosCaja
        '
        Me.chbPermiteCambiarCentroCostosCaja.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chbPermiteCambiarCentroCostosCaja.AutoSize = True
        Me.chbPermiteCambiarCentroCostosCaja.BindearPropiedadControl = Nothing
        Me.chbPermiteCambiarCentroCostosCaja.BindearPropiedadEntidad = Nothing
        Me.chbPermiteCambiarCentroCostosCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteCambiarCentroCostosCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteCambiarCentroCostosCaja.IsPK = False
        Me.chbPermiteCambiarCentroCostosCaja.IsRequired = False
        Me.chbPermiteCambiarCentroCostosCaja.Key = Nothing
        Me.chbPermiteCambiarCentroCostosCaja.LabelAsoc = Me.lblPermiteCambiarCentroCostosCaja
        Me.chbPermiteCambiarCentroCostosCaja.Location = New System.Drawing.Point(342, 16)
        Me.chbPermiteCambiarCentroCostosCaja.Name = "chbPermiteCambiarCentroCostosCaja"
        Me.chbPermiteCambiarCentroCostosCaja.Size = New System.Drawing.Size(15, 14)
        Me.chbPermiteCambiarCentroCostosCaja.TabIndex = 6
        Me.chbPermiteCambiarCentroCostosCaja.UseVisualStyleBackColor = True
        '
        'chbPermiteCambiarCentroCostosBanco
        '
        Me.chbPermiteCambiarCentroCostosBanco.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chbPermiteCambiarCentroCostosBanco.AutoSize = True
        Me.chbPermiteCambiarCentroCostosBanco.BindearPropiedadControl = Nothing
        Me.chbPermiteCambiarCentroCostosBanco.BindearPropiedadEntidad = Nothing
        Me.chbPermiteCambiarCentroCostosBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteCambiarCentroCostosBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteCambiarCentroCostosBanco.IsPK = False
        Me.chbPermiteCambiarCentroCostosBanco.IsRequired = False
        Me.chbPermiteCambiarCentroCostosBanco.Key = Nothing
        Me.chbPermiteCambiarCentroCostosBanco.LabelAsoc = Me.lblPermiteCambiarCentroCostosBanco
        Me.chbPermiteCambiarCentroCostosBanco.Location = New System.Drawing.Point(407, 16)
        Me.chbPermiteCambiarCentroCostosBanco.Name = "chbPermiteCambiarCentroCostosBanco"
        Me.chbPermiteCambiarCentroCostosBanco.Size = New System.Drawing.Size(15, 14)
        Me.chbPermiteCambiarCentroCostosBanco.TabIndex = 8
        Me.chbPermiteCambiarCentroCostosBanco.UseVisualStyleBackColor = True
        '
        'txtContabilidadRedondeoImporteMaximo
        '
        Me.txtContabilidadRedondeoImporteMaximo.BindearPropiedadControl = Nothing
        Me.txtContabilidadRedondeoImporteMaximo.BindearPropiedadEntidad = Nothing
        Me.txtContabilidadRedondeoImporteMaximo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtContabilidadRedondeoImporteMaximo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtContabilidadRedondeoImporteMaximo.Formato = "N2"
        Me.txtContabilidadRedondeoImporteMaximo.IsDecimal = True
        Me.txtContabilidadRedondeoImporteMaximo.IsNumber = True
        Me.txtContabilidadRedondeoImporteMaximo.IsPK = False
        Me.txtContabilidadRedondeoImporteMaximo.IsRequired = False
        Me.txtContabilidadRedondeoImporteMaximo.Key = ""
        Me.txtContabilidadRedondeoImporteMaximo.LabelAsoc = Me.lblContabilidadRedondeoImporteMaximo
        Me.txtContabilidadRedondeoImporteMaximo.Location = New System.Drawing.Point(839, 161)
        Me.txtContabilidadRedondeoImporteMaximo.MaxLength = 3
        Me.txtContabilidadRedondeoImporteMaximo.Name = "txtContabilidadRedondeoImporteMaximo"
        Me.txtContabilidadRedondeoImporteMaximo.Size = New System.Drawing.Size(49, 20)
        Me.txtContabilidadRedondeoImporteMaximo.TabIndex = 8
        Me.txtContabilidadRedondeoImporteMaximo.Tag = "COMPRASVALORREDONDEO"
        Me.txtContabilidadRedondeoImporteMaximo.Text = "0.10"
        Me.txtContabilidadRedondeoImporteMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblContabilidadRedondeoImporteMaximo
        '
        Me.lblContabilidadRedondeoImporteMaximo.AutoSize = True
        Me.lblContabilidadRedondeoImporteMaximo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblContabilidadRedondeoImporteMaximo.LabelAsoc = Nothing
        Me.lblContabilidadRedondeoImporteMaximo.Location = New System.Drawing.Point(763, 164)
        Me.lblContabilidadRedondeoImporteMaximo.Name = "lblContabilidadRedondeoImporteMaximo"
        Me.lblContabilidadRedondeoImporteMaximo.Size = New System.Drawing.Size(70, 13)
        Me.lblContabilidadRedondeoImporteMaximo.TabIndex = 7
        Me.lblContabilidadRedondeoImporteMaximo.Text = "Máximo auto."
        '
        'lblFormatoExportacion
        '
        Me.lblFormatoExportacion.AutoSize = True
        Me.lblFormatoExportacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFormatoExportacion.LabelAsoc = Nothing
        Me.lblFormatoExportacion.Location = New System.Drawing.Point(13, 209)
        Me.lblFormatoExportacion.Name = "lblFormatoExportacion"
        Me.lblFormatoExportacion.Size = New System.Drawing.Size(118, 13)
        Me.lblFormatoExportacion.TabIndex = 9
        Me.lblFormatoExportacion.Text = "Formato de exportación"
        '
        'lblCuentaContabilidadRedondeo
        '
        Me.lblCuentaContabilidadRedondeo.AutoSize = True
        Me.lblCuentaContabilidadRedondeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentaContabilidadRedondeo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCuentaContabilidadRedondeo.LabelAsoc = Nothing
        Me.lblCuentaContabilidadRedondeo.Location = New System.Drawing.Point(13, 162)
        Me.lblCuentaContabilidadRedondeo.Name = "lblCuentaContabilidadRedondeo"
        Me.lblCuentaContabilidadRedondeo.Size = New System.Drawing.Size(221, 15)
        Me.lblCuentaContabilidadRedondeo.TabIndex = 5
        Me.lblCuentaContabilidadRedondeo.Text = "Cuenta para Diferencias por Redondeo"
        '
        'lblContabilidadCompras
        '
        Me.lblContabilidadCompras.AutoSize = True
        Me.lblContabilidadCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContabilidadCompras.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblContabilidadCompras.LabelAsoc = Nothing
        Me.lblContabilidadCompras.Location = New System.Drawing.Point(13, 123)
        Me.lblContabilidadCompras.Name = "lblContabilidadCompras"
        Me.lblContabilidadCompras.Size = New System.Drawing.Size(283, 15)
        Me.lblContabilidadCompras.TabIndex = 3
        Me.lblContabilidadCompras.Text = "Cuenta por defecto para Categoría de Proveedores"
        '
        'lblContabilidadVentas
        '
        Me.lblContabilidadVentas.AutoSize = True
        Me.lblContabilidadVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContabilidadVentas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblContabilidadVentas.LabelAsoc = Nothing
        Me.lblContabilidadVentas.Location = New System.Drawing.Point(13, 83)
        Me.lblContabilidadVentas.Name = "lblContabilidadVentas"
        Me.lblContabilidadVentas.Size = New System.Drawing.Size(258, 15)
        Me.lblContabilidadVentas.TabIndex = 1
        Me.lblContabilidadVentas.Text = "Cuenta por defecto para Categoría de Clientes"
        '
        'chbUtilizaCentroCostos
        '
        Me.chbUtilizaCentroCostos.BindearPropiedadControl = Nothing
        Me.chbUtilizaCentroCostos.BindearPropiedadEntidad = Nothing
        Me.chbUtilizaCentroCostos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaCentroCostos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaCentroCostos.IsPK = False
        Me.chbUtilizaCentroCostos.IsRequired = False
        Me.chbUtilizaCentroCostos.Key = Nothing
        Me.chbUtilizaCentroCostos.LabelAsoc = Nothing
        Me.chbUtilizaCentroCostos.Location = New System.Drawing.Point(409, 206)
        Me.chbUtilizaCentroCostos.Name = "chbUtilizaCentroCostos"
        Me.chbUtilizaCentroCostos.Size = New System.Drawing.Size(243, 26)
        Me.chbUtilizaCentroCostos.TabIndex = 13
        Me.chbUtilizaCentroCostos.Text = "Utiliza Centros de Costos"
        Me.chbUtilizaCentroCostos.UseVisualStyleBackColor = True
        '
        'chbCuentaSecundariaCategoria
        '
        Me.chbCuentaSecundariaCategoria.BindearPropiedadControl = Nothing
        Me.chbCuentaSecundariaCategoria.BindearPropiedadEntidad = Nothing
        Me.chbCuentaSecundariaCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCuentaSecundariaCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCuentaSecundariaCategoria.IsPK = False
        Me.chbCuentaSecundariaCategoria.IsRequired = False
        Me.chbCuentaSecundariaCategoria.Key = Nothing
        Me.chbCuentaSecundariaCategoria.LabelAsoc = Nothing
        Me.chbCuentaSecundariaCategoria.Location = New System.Drawing.Point(16, 265)
        Me.chbCuentaSecundariaCategoria.Name = "chbCuentaSecundariaCategoria"
        Me.chbCuentaSecundariaCategoria.Size = New System.Drawing.Size(243, 26)
        Me.chbCuentaSecundariaCategoria.TabIndex = 12
        Me.chbCuentaSecundariaCategoria.Text = "Habilitar cuenta secundaria en categorias"
        Me.chbCuentaSecundariaCategoria.UseVisualStyleBackColor = True
        '
        'chbCuentaSecundariaProducto
        '
        Me.chbCuentaSecundariaProducto.BindearPropiedadControl = Nothing
        Me.chbCuentaSecundariaProducto.BindearPropiedadEntidad = Nothing
        Me.chbCuentaSecundariaProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCuentaSecundariaProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCuentaSecundariaProducto.IsPK = False
        Me.chbCuentaSecundariaProducto.IsRequired = False
        Me.chbCuentaSecundariaProducto.Key = Nothing
        Me.chbCuentaSecundariaProducto.LabelAsoc = Nothing
        Me.chbCuentaSecundariaProducto.Location = New System.Drawing.Point(16, 233)
        Me.chbCuentaSecundariaProducto.Name = "chbCuentaSecundariaProducto"
        Me.chbCuentaSecundariaProducto.Size = New System.Drawing.Size(243, 26)
        Me.chbCuentaSecundariaProducto.TabIndex = 11
        Me.chbCuentaSecundariaProducto.Text = "Habilitar cuenta secundaria en productos"
        Me.chbCuentaSecundariaProducto.UseVisualStyleBackColor = True
        '
        'chbContabilidadEjecutarEnLinea
        '
        Me.chbContabilidadEjecutarEnLinea.BindearPropiedadControl = Nothing
        Me.chbContabilidadEjecutarEnLinea.BindearPropiedadEntidad = Nothing
        Me.chbContabilidadEjecutarEnLinea.ForeColorFocus = System.Drawing.Color.Red
        Me.chbContabilidadEjecutarEnLinea.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbContabilidadEjecutarEnLinea.IsPK = False
        Me.chbContabilidadEjecutarEnLinea.IsRequired = False
        Me.chbContabilidadEjecutarEnLinea.Key = Nothing
        Me.chbContabilidadEjecutarEnLinea.LabelAsoc = Nothing
        Me.chbContabilidadEjecutarEnLinea.Location = New System.Drawing.Point(16, 46)
        Me.chbContabilidadEjecutarEnLinea.Name = "chbContabilidadEjecutarEnLinea"
        Me.chbContabilidadEjecutarEnLinea.Size = New System.Drawing.Size(215, 26)
        Me.chbContabilidadEjecutarEnLinea.TabIndex = 0
        Me.chbContabilidadEjecutarEnLinea.Tag = "CONTABILIDADEJECUTARENLINEA"
        Me.chbContabilidadEjecutarEnLinea.Text = "Ejecutar en linea con las operaciones"
        Me.chbContabilidadEjecutarEnLinea.UseVisualStyleBackColor = True
        '
        'ucCuentaContabilidadRedondeo
        '
        Me.ucCuentaContabilidadRedondeo.Cuenta = Nothing
        Me.ucCuentaContabilidadRedondeo.Cursor = System.Windows.Forms.Cursors.Default
        Me.ucCuentaContabilidadRedondeo.Location = New System.Drawing.Point(304, 159)
        Me.ucCuentaContabilidadRedondeo.Name = "ucCuentaContabilidadRedondeo"
        Me.ucCuentaContabilidadRedondeo.Size = New System.Drawing.Size(444, 20)
        Me.ucCuentaContabilidadRedondeo.TabIndex = 6
        '
        'ucCuentaContabilidadCompras
        '
        Me.ucCuentaContabilidadCompras.Cuenta = Nothing
        Me.ucCuentaContabilidadCompras.Cursor = System.Windows.Forms.Cursors.Default
        Me.ucCuentaContabilidadCompras.Location = New System.Drawing.Point(304, 120)
        Me.ucCuentaContabilidadCompras.Name = "ucCuentaContabilidadCompras"
        Me.ucCuentaContabilidadCompras.Size = New System.Drawing.Size(444, 20)
        Me.ucCuentaContabilidadCompras.TabIndex = 4
        '
        'ucCuentaContabilidadVentas
        '
        Me.ucCuentaContabilidadVentas.Cuenta = Nothing
        Me.ucCuentaContabilidadVentas.Cursor = System.Windows.Forms.Cursors.Default
        Me.ucCuentaContabilidadVentas.Location = New System.Drawing.Point(304, 80)
        Me.ucCuentaContabilidadVentas.Name = "ucCuentaContabilidadVentas"
        Me.ucCuentaContabilidadVentas.Size = New System.Drawing.Size(444, 20)
        Me.ucCuentaContabilidadVentas.TabIndex = 2
        '
        'cmbFormatoExportacion
        '
        Me.cmbFormatoExportacion.BindearPropiedadControl = Nothing
        Me.cmbFormatoExportacion.BindearPropiedadEntidad = Nothing
        Me.cmbFormatoExportacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatoExportacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormatoExportacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormatoExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormatoExportacion.FormattingEnabled = True
        Me.cmbFormatoExportacion.IsPK = False
        Me.cmbFormatoExportacion.IsRequired = False
        Me.cmbFormatoExportacion.Key = Nothing
        Me.cmbFormatoExportacion.LabelAsoc = Me.lblFormatoExportacion
        Me.cmbFormatoExportacion.Location = New System.Drawing.Point(137, 206)
        Me.cmbFormatoExportacion.Name = "cmbFormatoExportacion"
        Me.cmbFormatoExportacion.Size = New System.Drawing.Size(122, 21)
        Me.cmbFormatoExportacion.TabIndex = 10
        '
        'grpCerrarPeriodoConAsientoPermitir
        '
        Me.grpCerrarPeriodoConAsientoPermitir.Controls.Add(Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir)
        Me.grpCerrarPeriodoConAsientoPermitir.Controls.Add(Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir)
        Me.grpCerrarPeriodoConAsientoPermitir.Controls.Add(Me.rbtCerrarPeriodoConAsientoPermitir_Permitir)
        Me.grpCerrarPeriodoConAsientoPermitir.Location = New System.Drawing.Point(409, 278)
        Me.grpCerrarPeriodoConAsientoPermitir.Name = "grpCerrarPeriodoConAsientoPermitir"
        Me.grpCerrarPeriodoConAsientoPermitir.Size = New System.Drawing.Size(319, 53)
        Me.grpCerrarPeriodoConAsientoPermitir.TabIndex = 15
        Me.grpCerrarPeriodoConAsientoPermitir.TabStop = False
        Me.grpCerrarPeriodoConAsientoPermitir.Text = "Cerrar Períodos de Ejercicio con movimientos pendientes"
        '
        'rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir
        '
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.AutoSize = True
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Location = New System.Drawing.Point(201, 24)
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Name = "rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir"
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Size = New System.Drawing.Size(99, 17)
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.TabIndex = 2
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Tag = "AVISARYPERMITIR"
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Text = "Avisar y Permitir"
        Me.rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.UseVisualStyleBackColor = True
        '
        'rbtCerrarPeriodoConAsientoPermitir_NoPermitir
        '
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.AutoSize = True
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Location = New System.Drawing.Point(99, 24)
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Name = "rbtCerrarPeriodoConAsientoPermitir_NoPermitir"
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Size = New System.Drawing.Size(76, 17)
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.TabIndex = 1
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Tag = "NOPERMITIR"
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Text = "No Permitir"
        Me.rbtCerrarPeriodoConAsientoPermitir_NoPermitir.UseVisualStyleBackColor = True
        '
        'rbtCerrarPeriodoConAsientoPermitir_Permitir
        '
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.AutoSize = True
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.Checked = True
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.Location = New System.Drawing.Point(21, 24)
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.Name = "rbtCerrarPeriodoConAsientoPermitir_Permitir"
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.Size = New System.Drawing.Size(59, 17)
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.TabIndex = 0
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.TabStop = True
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.Tag = "PERMITIR"
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.Text = "Permitir"
        Me.rbtCerrarPeriodoConAsientoPermitir_Permitir.UseVisualStyleBackColor = True
        '
        'ucConfContabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpCerrarPeriodoConAsientoPermitir)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtContabilidadRedondeoImporteMaximo)
        Me.Controls.Add(Me.lblFormatoExportacion)
        Me.Controls.Add(Me.lblContabilidadRedondeoImporteMaximo)
        Me.Controls.Add(Me.lblCuentaContabilidadRedondeo)
        Me.Controls.Add(Me.lblContabilidadCompras)
        Me.Controls.Add(Me.lblContabilidadVentas)
        Me.Controls.Add(Me.chbUtilizaCentroCostos)
        Me.Controls.Add(Me.chbCuentaSecundariaCategoria)
        Me.Controls.Add(Me.chbCuentaSecundariaProducto)
        Me.Controls.Add(Me.chbContabilidadEjecutarEnLinea)
        Me.Controls.Add(Me.ucCuentaContabilidadRedondeo)
        Me.Controls.Add(Me.ucCuentaContabilidadCompras)
        Me.Controls.Add(Me.ucCuentaContabilidadVentas)
        Me.Controls.Add(Me.cmbFormatoExportacion)
        Me.Name = "ucConfContabilidad"
        Me.Controls.SetChildIndex(Me.cmbFormatoExportacion, 0)
        Me.Controls.SetChildIndex(Me.ucCuentaContabilidadVentas, 0)
        Me.Controls.SetChildIndex(Me.ucCuentaContabilidadCompras, 0)
        Me.Controls.SetChildIndex(Me.ucCuentaContabilidadRedondeo, 0)
        Me.Controls.SetChildIndex(Me.chbContabilidadEjecutarEnLinea, 0)
        Me.Controls.SetChildIndex(Me.chbCuentaSecundariaProducto, 0)
        Me.Controls.SetChildIndex(Me.chbCuentaSecundariaCategoria, 0)
        Me.Controls.SetChildIndex(Me.chbUtilizaCentroCostos, 0)
        Me.Controls.SetChildIndex(Me.lblContabilidadVentas, 0)
        Me.Controls.SetChildIndex(Me.lblContabilidadCompras, 0)
        Me.Controls.SetChildIndex(Me.lblCuentaContabilidadRedondeo, 0)
        Me.Controls.SetChildIndex(Me.lblContabilidadRedondeoImporteMaximo, 0)
        Me.Controls.SetChildIndex(Me.lblFormatoExportacion, 0)
        Me.Controls.SetChildIndex(Me.txtContabilidadRedondeoImporteMaximo, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.Controls.SetChildIndex(Me.grpCerrarPeriodoConAsientoPermitir, 0)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grpCerrarPeriodoConAsientoPermitir.ResumeLayout(False)
        Me.grpCerrarPeriodoConAsientoPermitir.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents lblPermiteCambiarCentroCostos As Controles.Label
   Friend WithEvents lblPermiteCambiarCentroCostosCompras As Controles.Label
   Friend WithEvents lblPermiteCambiarCentroCostosVentas As Controles.Label
   Friend WithEvents lblPermiteCambiarCentroCostosCaja As Controles.Label
   Friend WithEvents lblPermiteCambiarCentroCostosBanco As Controles.Label
   Friend WithEvents chbPermiteCambiarCentroCostosCompras As Controles.CheckBox
   Friend WithEvents chbPermiteCambiarCentroCostosVentas As Controles.CheckBox
   Friend WithEvents chbPermiteCambiarCentroCostosCaja As Controles.CheckBox
   Friend WithEvents chbPermiteCambiarCentroCostosBanco As Controles.CheckBox
   Friend WithEvents txtContabilidadRedondeoImporteMaximo As Controles.TextBox
   Friend WithEvents lblContabilidadRedondeoImporteMaximo As Controles.Label
   Friend WithEvents lblFormatoExportacion As Controles.Label
   Friend WithEvents lblCuentaContabilidadRedondeo As Controles.Label
   Friend WithEvents lblContabilidadCompras As Controles.Label
   Friend WithEvents lblContabilidadVentas As Controles.Label
   Friend WithEvents chbUtilizaCentroCostos As Controles.CheckBox
   Friend WithEvents chbCuentaSecundariaCategoria As Controles.CheckBox
   Friend WithEvents chbCuentaSecundariaProducto As Controles.CheckBox
   Friend WithEvents chbContabilidadEjecutarEnLinea As Controles.CheckBox
   Friend WithEvents ucCuentaContabilidadRedondeo As ucCuentas
   Friend WithEvents ucCuentaContabilidadCompras As ucCuentas
   Friend WithEvents ucCuentaContabilidadVentas As ucCuentas
   Friend WithEvents cmbFormatoExportacion As Controles.ComboBox
    Friend WithEvents grpCerrarPeriodoConAsientoPermitir As GroupBox
    Friend WithEvents rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir As RadioButton
    Friend WithEvents rbtCerrarPeriodoConAsientoPermitir_NoPermitir As RadioButton
    Friend WithEvents rbtCerrarPeriodoConAsientoPermitir_Permitir As RadioButton
End Class
