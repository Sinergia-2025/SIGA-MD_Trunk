<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucConfProcesos
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.grpTareasProgramadas = New System.Windows.Forms.GroupBox()
      Me.btnEjecutableTareaProgramada = New System.Windows.Forms.Button()
      Me.txtEjecutableTareaProgramada = New Eniac.Controles.TextBox()
      Me.lblEjecutableTareaProgramada = New Eniac.Controles.Label()
      Me.GroupBox16 = New System.Windows.Forms.GroupBox()
      Me.chbRubrosComprasBajarWeb = New Eniac.Controles.CheckBox()
      Me.chbProveedoresBajarWeb = New Eniac.Controles.CheckBox()
      Me.chbMarcasBajarWeb = New Eniac.Controles.CheckBox()
      Me.chbRubrosBajarWeb = New Eniac.Controles.CheckBox()
      Me.chbLocalidadesBajarWeb = New Eniac.Controles.CheckBox()
      Me.chbProductosBajarWeb = New Eniac.Controles.CheckBox()
      Me.chbClientesBajarWeb = New Eniac.Controles.CheckBox()
      Me.grbSubirAWeb = New System.Windows.Forms.GroupBox()
      Me.chbRubrosComprasSubirWeb = New Eniac.Controles.CheckBox()
      Me.chbProveedoresSubirWeb = New Eniac.Controles.CheckBox()
      Me.chbMarcasSubirWeb = New Eniac.Controles.CheckBox()
      Me.chbRubrosSubirWeb = New Eniac.Controles.CheckBox()
      Me.chbLocalidadesSubirWeb = New Eniac.Controles.CheckBox()
      Me.chbProductosSubirWeb = New Eniac.Controles.CheckBox()
      Me.chbClientesSubirWeb = New Eniac.Controles.CheckBox()
      Me.txtCorreoPruebaPara = New Eniac.Controles.TextBox()
      Me.lblCorreoPruebaPara = New Eniac.Controles.Label()
      Me.txtExportarProductosDecimalesRedondeoEnPrecio = New Eniac.Controles.TextBox()
      Me.lblExportarProductosDecimalesRedondeoEnPrecio = New Eniac.Controles.Label()
      Me.chbExportarPreciosConIVA = New Eniac.Controles.CheckBox()
      Me.lblExportarPrecioProductoUsandoMoneda = New Eniac.Controles.Label()
      Me.grbActualizarPreciosPlantillaExcel = New System.Windows.Forms.GroupBox()
      Me.rdbAPExcelCosto = New System.Windows.Forms.RadioButton()
      Me.rdbAPExcelVenta = New System.Windows.Forms.RadioButton()
      Me.rdbAPExcelActual = New System.Windows.Forms.RadioButton()
      Me.chbImportarProductosGeneraHistorialPrecios = New Eniac.Controles.CheckBox()
      Me.chbTareasPorUsuario = New Eniac.Controles.CheckBox()
      Me.cmbExportarPrecioProductoUsandoMoneda = New Eniac.Controles.ComboBox()
      Me.ofdEjecutableTareaProgramada = New System.Windows.Forms.OpenFileDialog()
      Me.grpTareasProgramadas.SuspendLayout()
      Me.GroupBox16.SuspendLayout()
      Me.grbSubirAWeb.SuspendLayout()
      Me.grbActualizarPreciosPlantillaExcel.SuspendLayout()
      Me.SuspendLayout()
      '
      'grpTareasProgramadas
      '
      Me.grpTareasProgramadas.Controls.Add(Me.btnEjecutableTareaProgramada)
      Me.grpTareasProgramadas.Controls.Add(Me.txtEjecutableTareaProgramada)
      Me.grpTareasProgramadas.Controls.Add(Me.lblEjecutableTareaProgramada)
      Me.grpTareasProgramadas.Location = New System.Drawing.Point(50, 325)
      Me.grpTareasProgramadas.Name = "grpTareasProgramadas"
      Me.grpTareasProgramadas.Size = New System.Drawing.Size(593, 50)
      Me.grpTareasProgramadas.TabIndex = 71
      Me.grpTareasProgramadas.TabStop = False
      Me.grpTareasProgramadas.Text = "Tareas Programadas"
      '
      'btnEjecutableTareaProgramada
      '
      Me.btnEjecutableTareaProgramada.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
      Me.btnEjecutableTareaProgramada.Location = New System.Drawing.Point(553, 19)
      Me.btnEjecutableTareaProgramada.Name = "btnEjecutableTareaProgramada"
      Me.btnEjecutableTareaProgramada.Size = New System.Drawing.Size(29, 23)
      Me.btnEjecutableTareaProgramada.TabIndex = 2
      Me.btnEjecutableTareaProgramada.UseVisualStyleBackColor = True
      '
      'txtEjecutableTareaProgramada
      '
      Me.txtEjecutableTareaProgramada.BindearPropiedadControl = Nothing
      Me.txtEjecutableTareaProgramada.BindearPropiedadEntidad = Nothing
      Me.txtEjecutableTareaProgramada.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEjecutableTareaProgramada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEjecutableTareaProgramada.Formato = ""
      Me.txtEjecutableTareaProgramada.IsDecimal = False
      Me.txtEjecutableTareaProgramada.IsNumber = False
      Me.txtEjecutableTareaProgramada.IsPK = False
      Me.txtEjecutableTareaProgramada.IsRequired = False
      Me.txtEjecutableTareaProgramada.Key = ""
      Me.txtEjecutableTareaProgramada.LabelAsoc = Me.lblEjecutableTareaProgramada
      Me.txtEjecutableTareaProgramada.Location = New System.Drawing.Point(182, 19)
      Me.txtEjecutableTareaProgramada.MaxLength = 80
      Me.txtEjecutableTareaProgramada.Name = "txtEjecutableTareaProgramada"
      Me.txtEjecutableTareaProgramada.Size = New System.Drawing.Size(365, 20)
      Me.txtEjecutableTareaProgramada.TabIndex = 1
      Me.txtEjecutableTareaProgramada.Tag = ""
      '
      'lblEjecutableTareaProgramada
      '
      Me.lblEjecutableTareaProgramada.AutoSize = True
      Me.lblEjecutableTareaProgramada.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblEjecutableTareaProgramada.LabelAsoc = Nothing
      Me.lblEjecutableTareaProgramada.Location = New System.Drawing.Point(13, 22)
      Me.lblEjecutableTareaProgramada.Name = "lblEjecutableTareaProgramada"
      Me.lblEjecutableTareaProgramada.Size = New System.Drawing.Size(163, 13)
      Me.lblEjecutableTareaProgramada.TabIndex = 0
      Me.lblEjecutableTareaProgramada.Text = "Ejecutable de Tarea Programada"
      '
      'GroupBox16
      '
      Me.GroupBox16.Controls.Add(Me.chbRubrosComprasBajarWeb)
      Me.GroupBox16.Controls.Add(Me.chbProveedoresBajarWeb)
      Me.GroupBox16.Controls.Add(Me.chbMarcasBajarWeb)
      Me.GroupBox16.Controls.Add(Me.chbRubrosBajarWeb)
      Me.GroupBox16.Controls.Add(Me.chbLocalidadesBajarWeb)
      Me.GroupBox16.Controls.Add(Me.chbProductosBajarWeb)
      Me.GroupBox16.Controls.Add(Me.chbClientesBajarWeb)
      Me.GroupBox16.Location = New System.Drawing.Point(50, 252)
      Me.GroupBox16.Name = "GroupBox16"
      Me.GroupBox16.Size = New System.Drawing.Size(593, 67)
      Me.GroupBox16.TabIndex = 70
      Me.GroupBox16.TabStop = False
      Me.GroupBox16.Tag = ""
      Me.GroupBox16.Text = "Sincronización - Bajar de la Web Según Parametros"
      '
      'chbRubrosComprasBajarWeb
      '
      Me.chbRubrosComprasBajarWeb.AutoSize = True
      Me.chbRubrosComprasBajarWeb.BindearPropiedadControl = Nothing
      Me.chbRubrosComprasBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbRubrosComprasBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubrosComprasBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubrosComprasBajarWeb.IsPK = False
      Me.chbRubrosComprasBajarWeb.IsRequired = False
      Me.chbRubrosComprasBajarWeb.Key = Nothing
      Me.chbRubrosComprasBajarWeb.LabelAsoc = Nothing
      Me.chbRubrosComprasBajarWeb.Location = New System.Drawing.Point(478, 30)
      Me.chbRubrosComprasBajarWeb.Name = "chbRubrosComprasBajarWeb"
      Me.chbRubrosComprasBajarWeb.Size = New System.Drawing.Size(104, 17)
      Me.chbRubrosComprasBajarWeb.TabIndex = 28
      Me.chbRubrosComprasBajarWeb.Text = "Rubros Compras"
      Me.chbRubrosComprasBajarWeb.UseVisualStyleBackColor = True
      '
      'chbProveedoresBajarWeb
      '
      Me.chbProveedoresBajarWeb.AutoSize = True
      Me.chbProveedoresBajarWeb.BindearPropiedadControl = Nothing
      Me.chbProveedoresBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbProveedoresBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProveedoresBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProveedoresBajarWeb.IsPK = False
      Me.chbProveedoresBajarWeb.IsRequired = False
      Me.chbProveedoresBajarWeb.Key = Nothing
      Me.chbProveedoresBajarWeb.LabelAsoc = Nothing
      Me.chbProveedoresBajarWeb.Location = New System.Drawing.Point(386, 30)
      Me.chbProveedoresBajarWeb.Name = "chbProveedoresBajarWeb"
      Me.chbProveedoresBajarWeb.Size = New System.Drawing.Size(86, 17)
      Me.chbProveedoresBajarWeb.TabIndex = 27
      Me.chbProveedoresBajarWeb.Text = "Proveedores"
      Me.chbProveedoresBajarWeb.UseVisualStyleBackColor = True
      '
      'chbMarcasBajarWeb
      '
      Me.chbMarcasBajarWeb.AutoSize = True
      Me.chbMarcasBajarWeb.BindearPropiedadControl = Nothing
      Me.chbMarcasBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbMarcasBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMarcasBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMarcasBajarWeb.IsPK = False
      Me.chbMarcasBajarWeb.IsRequired = False
      Me.chbMarcasBajarWeb.Key = Nothing
      Me.chbMarcasBajarWeb.LabelAsoc = Nothing
      Me.chbMarcasBajarWeb.Location = New System.Drawing.Point(230, 30)
      Me.chbMarcasBajarWeb.Name = "chbMarcasBajarWeb"
      Me.chbMarcasBajarWeb.Size = New System.Drawing.Size(61, 17)
      Me.chbMarcasBajarWeb.TabIndex = 26
      Me.chbMarcasBajarWeb.Text = "Marcas"
      Me.chbMarcasBajarWeb.UseVisualStyleBackColor = True
      '
      'chbRubrosBajarWeb
      '
      Me.chbRubrosBajarWeb.AutoSize = True
      Me.chbRubrosBajarWeb.BindearPropiedadControl = Nothing
      Me.chbRubrosBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbRubrosBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubrosBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubrosBajarWeb.IsPK = False
      Me.chbRubrosBajarWeb.IsRequired = False
      Me.chbRubrosBajarWeb.Key = Nothing
      Me.chbRubrosBajarWeb.LabelAsoc = Nothing
      Me.chbRubrosBajarWeb.Location = New System.Drawing.Point(165, 30)
      Me.chbRubrosBajarWeb.Name = "chbRubrosBajarWeb"
      Me.chbRubrosBajarWeb.Size = New System.Drawing.Size(60, 17)
      Me.chbRubrosBajarWeb.TabIndex = 25
      Me.chbRubrosBajarWeb.Text = "Rubros"
      Me.chbRubrosBajarWeb.UseVisualStyleBackColor = True
      '
      'chbLocalidadesBajarWeb
      '
      Me.chbLocalidadesBajarWeb.AutoSize = True
      Me.chbLocalidadesBajarWeb.BindearPropiedadControl = Nothing
      Me.chbLocalidadesBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbLocalidadesBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLocalidadesBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLocalidadesBajarWeb.IsPK = False
      Me.chbLocalidadesBajarWeb.IsRequired = False
      Me.chbLocalidadesBajarWeb.Key = Nothing
      Me.chbLocalidadesBajarWeb.LabelAsoc = Nothing
      Me.chbLocalidadesBajarWeb.Location = New System.Drawing.Point(297, 30)
      Me.chbLocalidadesBajarWeb.Name = "chbLocalidadesBajarWeb"
      Me.chbLocalidadesBajarWeb.Size = New System.Drawing.Size(83, 17)
      Me.chbLocalidadesBajarWeb.TabIndex = 24
      Me.chbLocalidadesBajarWeb.Text = "Localidades"
      Me.chbLocalidadesBajarWeb.UseVisualStyleBackColor = True
      '
      'chbProductosBajarWeb
      '
      Me.chbProductosBajarWeb.AutoSize = True
      Me.chbProductosBajarWeb.BindearPropiedadControl = Nothing
      Me.chbProductosBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbProductosBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProductosBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProductosBajarWeb.IsPK = False
      Me.chbProductosBajarWeb.IsRequired = False
      Me.chbProductosBajarWeb.Key = Nothing
      Me.chbProductosBajarWeb.LabelAsoc = Nothing
      Me.chbProductosBajarWeb.Location = New System.Drawing.Point(85, 30)
      Me.chbProductosBajarWeb.Name = "chbProductosBajarWeb"
      Me.chbProductosBajarWeb.Size = New System.Drawing.Size(74, 17)
      Me.chbProductosBajarWeb.TabIndex = 19
      Me.chbProductosBajarWeb.Text = "Productos"
      Me.chbProductosBajarWeb.UseVisualStyleBackColor = True
      '
      'chbClientesBajarWeb
      '
      Me.chbClientesBajarWeb.AutoSize = True
      Me.chbClientesBajarWeb.BindearPropiedadControl = Nothing
      Me.chbClientesBajarWeb.BindearPropiedadEntidad = Nothing
      Me.chbClientesBajarWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbClientesBajarWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbClientesBajarWeb.IsPK = False
      Me.chbClientesBajarWeb.IsRequired = False
      Me.chbClientesBajarWeb.Key = Nothing
      Me.chbClientesBajarWeb.LabelAsoc = Nothing
      Me.chbClientesBajarWeb.Location = New System.Drawing.Point(16, 30)
      Me.chbClientesBajarWeb.Name = "chbClientesBajarWeb"
      Me.chbClientesBajarWeb.Size = New System.Drawing.Size(63, 17)
      Me.chbClientesBajarWeb.TabIndex = 18
      Me.chbClientesBajarWeb.Text = "Clientes"
      Me.chbClientesBajarWeb.UseVisualStyleBackColor = True
      '
      'grbSubirAWeb
      '
      Me.grbSubirAWeb.Controls.Add(Me.chbRubrosComprasSubirWeb)
      Me.grbSubirAWeb.Controls.Add(Me.chbProveedoresSubirWeb)
      Me.grbSubirAWeb.Controls.Add(Me.chbMarcasSubirWeb)
      Me.grbSubirAWeb.Controls.Add(Me.chbRubrosSubirWeb)
      Me.grbSubirAWeb.Controls.Add(Me.chbLocalidadesSubirWeb)
      Me.grbSubirAWeb.Controls.Add(Me.chbProductosSubirWeb)
      Me.grbSubirAWeb.Controls.Add(Me.chbClientesSubirWeb)
      Me.grbSubirAWeb.Location = New System.Drawing.Point(50, 180)
      Me.grbSubirAWeb.Name = "grbSubirAWeb"
      Me.grbSubirAWeb.Size = New System.Drawing.Size(593, 66)
      Me.grbSubirAWeb.TabIndex = 69
      Me.grbSubirAWeb.TabStop = False
      Me.grbSubirAWeb.Tag = ""
      Me.grbSubirAWeb.Text = "Sincronización - Subir a la Web Según Parametros"
      '
      'chbRubrosComprasSubirWeb
      '
      Me.chbRubrosComprasSubirWeb.AutoSize = True
      Me.chbRubrosComprasSubirWeb.BindearPropiedadControl = Nothing
      Me.chbRubrosComprasSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbRubrosComprasSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubrosComprasSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubrosComprasSubirWeb.IsPK = False
      Me.chbRubrosComprasSubirWeb.IsRequired = False
      Me.chbRubrosComprasSubirWeb.Key = Nothing
      Me.chbRubrosComprasSubirWeb.LabelAsoc = Nothing
      Me.chbRubrosComprasSubirWeb.Location = New System.Drawing.Point(478, 30)
      Me.chbRubrosComprasSubirWeb.Name = "chbRubrosComprasSubirWeb"
      Me.chbRubrosComprasSubirWeb.Size = New System.Drawing.Size(104, 17)
      Me.chbRubrosComprasSubirWeb.TabIndex = 28
      Me.chbRubrosComprasSubirWeb.Text = "Rubros Compras"
      Me.chbRubrosComprasSubirWeb.UseVisualStyleBackColor = True
      '
      'chbProveedoresSubirWeb
      '
      Me.chbProveedoresSubirWeb.AutoSize = True
      Me.chbProveedoresSubirWeb.BindearPropiedadControl = Nothing
      Me.chbProveedoresSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbProveedoresSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProveedoresSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProveedoresSubirWeb.IsPK = False
      Me.chbProveedoresSubirWeb.IsRequired = False
      Me.chbProveedoresSubirWeb.Key = Nothing
      Me.chbProveedoresSubirWeb.LabelAsoc = Nothing
      Me.chbProveedoresSubirWeb.Location = New System.Drawing.Point(386, 30)
      Me.chbProveedoresSubirWeb.Name = "chbProveedoresSubirWeb"
      Me.chbProveedoresSubirWeb.Size = New System.Drawing.Size(86, 17)
      Me.chbProveedoresSubirWeb.TabIndex = 27
      Me.chbProveedoresSubirWeb.Text = "Proveedores"
      Me.chbProveedoresSubirWeb.UseVisualStyleBackColor = True
      '
      'chbMarcasSubirWeb
      '
      Me.chbMarcasSubirWeb.AutoSize = True
      Me.chbMarcasSubirWeb.BindearPropiedadControl = Nothing
      Me.chbMarcasSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbMarcasSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMarcasSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMarcasSubirWeb.IsPK = False
      Me.chbMarcasSubirWeb.IsRequired = False
      Me.chbMarcasSubirWeb.Key = Nothing
      Me.chbMarcasSubirWeb.LabelAsoc = Nothing
      Me.chbMarcasSubirWeb.Location = New System.Drawing.Point(230, 30)
      Me.chbMarcasSubirWeb.Name = "chbMarcasSubirWeb"
      Me.chbMarcasSubirWeb.Size = New System.Drawing.Size(61, 17)
      Me.chbMarcasSubirWeb.TabIndex = 26
      Me.chbMarcasSubirWeb.Text = "Marcas"
      Me.chbMarcasSubirWeb.UseVisualStyleBackColor = True
      '
      'chbRubrosSubirWeb
      '
      Me.chbRubrosSubirWeb.AutoSize = True
      Me.chbRubrosSubirWeb.BindearPropiedadControl = Nothing
      Me.chbRubrosSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbRubrosSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRubrosSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRubrosSubirWeb.IsPK = False
      Me.chbRubrosSubirWeb.IsRequired = False
      Me.chbRubrosSubirWeb.Key = Nothing
      Me.chbRubrosSubirWeb.LabelAsoc = Nothing
      Me.chbRubrosSubirWeb.Location = New System.Drawing.Point(165, 30)
      Me.chbRubrosSubirWeb.Name = "chbRubrosSubirWeb"
      Me.chbRubrosSubirWeb.Size = New System.Drawing.Size(60, 17)
      Me.chbRubrosSubirWeb.TabIndex = 25
      Me.chbRubrosSubirWeb.Text = "Rubros"
      Me.chbRubrosSubirWeb.UseVisualStyleBackColor = True
      '
      'chbLocalidadesSubirWeb
      '
      Me.chbLocalidadesSubirWeb.AutoSize = True
      Me.chbLocalidadesSubirWeb.BindearPropiedadControl = Nothing
      Me.chbLocalidadesSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbLocalidadesSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLocalidadesSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLocalidadesSubirWeb.IsPK = False
      Me.chbLocalidadesSubirWeb.IsRequired = False
      Me.chbLocalidadesSubirWeb.Key = Nothing
      Me.chbLocalidadesSubirWeb.LabelAsoc = Nothing
      Me.chbLocalidadesSubirWeb.Location = New System.Drawing.Point(297, 30)
      Me.chbLocalidadesSubirWeb.Name = "chbLocalidadesSubirWeb"
      Me.chbLocalidadesSubirWeb.Size = New System.Drawing.Size(83, 17)
      Me.chbLocalidadesSubirWeb.TabIndex = 24
      Me.chbLocalidadesSubirWeb.Text = "Localidades"
      Me.chbLocalidadesSubirWeb.UseVisualStyleBackColor = True
      '
      'chbProductosSubirWeb
      '
      Me.chbProductosSubirWeb.AutoSize = True
      Me.chbProductosSubirWeb.BindearPropiedadControl = Nothing
      Me.chbProductosSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbProductosSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProductosSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProductosSubirWeb.IsPK = False
      Me.chbProductosSubirWeb.IsRequired = False
      Me.chbProductosSubirWeb.Key = Nothing
      Me.chbProductosSubirWeb.LabelAsoc = Nothing
      Me.chbProductosSubirWeb.Location = New System.Drawing.Point(85, 30)
      Me.chbProductosSubirWeb.Name = "chbProductosSubirWeb"
      Me.chbProductosSubirWeb.Size = New System.Drawing.Size(74, 17)
      Me.chbProductosSubirWeb.TabIndex = 19
      Me.chbProductosSubirWeb.Text = "Productos"
      Me.chbProductosSubirWeb.UseVisualStyleBackColor = True
      '
      'chbClientesSubirWeb
      '
      Me.chbClientesSubirWeb.AutoSize = True
      Me.chbClientesSubirWeb.BindearPropiedadControl = Nothing
      Me.chbClientesSubirWeb.BindearPropiedadEntidad = Nothing
      Me.chbClientesSubirWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.chbClientesSubirWeb.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbClientesSubirWeb.IsPK = False
      Me.chbClientesSubirWeb.IsRequired = False
      Me.chbClientesSubirWeb.Key = Nothing
      Me.chbClientesSubirWeb.LabelAsoc = Nothing
      Me.chbClientesSubirWeb.Location = New System.Drawing.Point(16, 30)
      Me.chbClientesSubirWeb.Name = "chbClientesSubirWeb"
      Me.chbClientesSubirWeb.Size = New System.Drawing.Size(63, 17)
      Me.chbClientesSubirWeb.TabIndex = 18
      Me.chbClientesSubirWeb.Text = "Clientes"
      Me.chbClientesSubirWeb.UseVisualStyleBackColor = True
      '
      'txtCorreoPruebaPara
      '
      Me.txtCorreoPruebaPara.BindearPropiedadControl = Nothing
      Me.txtCorreoPruebaPara.BindearPropiedadEntidad = Nothing
      Me.txtCorreoPruebaPara.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCorreoPruebaPara.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCorreoPruebaPara.Formato = ""
      Me.txtCorreoPruebaPara.IsDecimal = False
      Me.txtCorreoPruebaPara.IsNumber = False
      Me.txtCorreoPruebaPara.IsPK = False
      Me.txtCorreoPruebaPara.IsRequired = False
      Me.txtCorreoPruebaPara.Key = ""
      Me.txtCorreoPruebaPara.LabelAsoc = Me.lblCorreoPruebaPara
      Me.txtCorreoPruebaPara.Location = New System.Drawing.Point(267, 154)
      Me.txtCorreoPruebaPara.MaxLength = 80
      Me.txtCorreoPruebaPara.Name = "txtCorreoPruebaPara"
      Me.txtCorreoPruebaPara.Size = New System.Drawing.Size(220, 20)
      Me.txtCorreoPruebaPara.TabIndex = 68
      Me.txtCorreoPruebaPara.Tag = ""
      '
      'lblCorreoPruebaPara
      '
      Me.lblCorreoPruebaPara.AutoSize = True
      Me.lblCorreoPruebaPara.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCorreoPruebaPara.LabelAsoc = Nothing
      Me.lblCorreoPruebaPara.Location = New System.Drawing.Point(54, 157)
      Me.lblCorreoPruebaPara.Name = "lblCorreoPruebaPara"
      Me.lblCorreoPruebaPara.Size = New System.Drawing.Size(207, 13)
      Me.lblCorreoPruebaPara.TabIndex = 67
      Me.lblCorreoPruebaPara.Text = "Correo Electrónico para correos de prueba"
      '
      'txtExportarProductosDecimalesRedondeoEnPrecio
      '
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.BindearPropiedadControl = Nothing
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.BindearPropiedadEntidad = Nothing
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Formato = ""
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.IsDecimal = False
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.IsNumber = True
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.IsPK = False
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.IsRequired = False
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Key = ""
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.LabelAsoc = Me.lblExportarProductosDecimalesRedondeoEnPrecio
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Location = New System.Drawing.Point(480, 89)
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.MaxLength = 3
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Name = "txtExportarProductosDecimalesRedondeoEnPrecio"
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Size = New System.Drawing.Size(35, 20)
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.TabIndex = 65
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Tag = ""
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.Text = "4"
      Me.txtExportarProductosDecimalesRedondeoEnPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblExportarProductosDecimalesRedondeoEnPrecio
      '
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.AutoSize = True
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.LabelAsoc = Nothing
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.Location = New System.Drawing.Point(518, 93)
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.Name = "lblExportarProductosDecimalesRedondeoEnPrecio"
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.Size = New System.Drawing.Size(105, 13)
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.TabIndex = 66
      Me.lblExportarProductosDecimalesRedondeoEnPrecio.Text = "Redondeo en Precio"
      '
      'chbExportarPreciosConIVA
      '
      Me.chbExportarPreciosConIVA.BindearPropiedadControl = Nothing
      Me.chbExportarPreciosConIVA.BindearPropiedadEntidad = Nothing
      Me.chbExportarPreciosConIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbExportarPreciosConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbExportarPreciosConIVA.IsPK = False
      Me.chbExportarPreciosConIVA.IsRequired = False
      Me.chbExportarPreciosConIVA.Key = Nothing
      Me.chbExportarPreciosConIVA.LabelAsoc = Nothing
      Me.chbExportarPreciosConIVA.Location = New System.Drawing.Point(480, 57)
      Me.chbExportarPreciosConIVA.Name = "chbExportarPreciosConIVA"
      Me.chbExportarPreciosConIVA.Size = New System.Drawing.Size(264, 26)
      Me.chbExportarPreciosConIVA.TabIndex = 64
      Me.chbExportarPreciosConIVA.Tag = ""
      Me.chbExportarPreciosConIVA.Text = "Exportar los Precios de productos Con IVA"
      Me.chbExportarPreciosConIVA.UseVisualStyleBackColor = True
      '
      'lblExportarPrecioProductoUsandoMoneda
      '
      Me.lblExportarPrecioProductoUsandoMoneda.AutoSize = True
      Me.lblExportarPrecioProductoUsandoMoneda.LabelAsoc = Nothing
      Me.lblExportarPrecioProductoUsandoMoneda.Location = New System.Drawing.Point(477, 28)
      Me.lblExportarPrecioProductoUsandoMoneda.Name = "lblExportarPrecioProductoUsandoMoneda"
      Me.lblExportarPrecioProductoUsandoMoneda.Size = New System.Drawing.Size(267, 13)
      Me.lblExportarPrecioProductoUsandoMoneda.TabIndex = 62
      Me.lblExportarPrecioProductoUsandoMoneda.Text = "Exportar los Precios de productos Utilizando la Moneda"
      '
      'grbActualizarPreciosPlantillaExcel
      '
      Me.grbActualizarPreciosPlantillaExcel.Controls.Add(Me.rdbAPExcelCosto)
      Me.grbActualizarPreciosPlantillaExcel.Controls.Add(Me.rdbAPExcelVenta)
      Me.grbActualizarPreciosPlantillaExcel.Controls.Add(Me.rdbAPExcelActual)
      Me.grbActualizarPreciosPlantillaExcel.Location = New System.Drawing.Point(50, 98)
      Me.grbActualizarPreciosPlantillaExcel.Name = "grbActualizarPreciosPlantillaExcel"
      Me.grbActualizarPreciosPlantillaExcel.Size = New System.Drawing.Size(291, 50)
      Me.grbActualizarPreciosPlantillaExcel.TabIndex = 61
      Me.grbActualizarPreciosPlantillaExcel.TabStop = False
      Me.grbActualizarPreciosPlantillaExcel.Tag = "ACTUALIZARPRECIOSEXCEL"
      Me.grbActualizarPreciosPlantillaExcel.Text = "Actualizar precios desde plantilla excel"
      '
      'rdbAPExcelCosto
      '
      Me.rdbAPExcelCosto.AutoSize = True
      Me.rdbAPExcelCosto.Location = New System.Drawing.Point(198, 22)
      Me.rdbAPExcelCosto.Name = "rdbAPExcelCosto"
      Me.rdbAPExcelCosto.Size = New System.Drawing.Size(83, 17)
      Me.rdbAPExcelCosto.TabIndex = 2
      Me.rdbAPExcelCosto.Tag = "COSTO"
      Me.rdbAPExcelCosto.Text = "Sobre Costo"
      Me.rdbAPExcelCosto.UseVisualStyleBackColor = True
      '
      'rdbAPExcelVenta
      '
      Me.rdbAPExcelVenta.AutoSize = True
      Me.rdbAPExcelVenta.Location = New System.Drawing.Point(106, 22)
      Me.rdbAPExcelVenta.Name = "rdbAPExcelVenta"
      Me.rdbAPExcelVenta.Size = New System.Drawing.Size(84, 17)
      Me.rdbAPExcelVenta.TabIndex = 1
      Me.rdbAPExcelVenta.Tag = "VENTA"
      Me.rdbAPExcelVenta.Text = "Sobre Venta"
      Me.rdbAPExcelVenta.UseVisualStyleBackColor = True
      '
      'rdbAPExcelActual
      '
      Me.rdbAPExcelActual.AutoSize = True
      Me.rdbAPExcelActual.Checked = True
      Me.rdbAPExcelActual.Location = New System.Drawing.Point(16, 22)
      Me.rdbAPExcelActual.Name = "rdbAPExcelActual"
      Me.rdbAPExcelActual.Size = New System.Drawing.Size(83, 17)
      Me.rdbAPExcelActual.TabIndex = 0
      Me.rdbAPExcelActual.TabStop = True
      Me.rdbAPExcelActual.Tag = "ACTUAL"
      Me.rdbAPExcelActual.Text = "Porc. Actual"
      Me.rdbAPExcelActual.UseVisualStyleBackColor = True
      '
      'chbImportarProductosGeneraHistorialPrecios
      '
      Me.chbImportarProductosGeneraHistorialPrecios.BindearPropiedadControl = Nothing
      Me.chbImportarProductosGeneraHistorialPrecios.BindearPropiedadEntidad = Nothing
      Me.chbImportarProductosGeneraHistorialPrecios.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImportarProductosGeneraHistorialPrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImportarProductosGeneraHistorialPrecios.IsPK = False
      Me.chbImportarProductosGeneraHistorialPrecios.IsRequired = False
      Me.chbImportarProductosGeneraHistorialPrecios.Key = Nothing
      Me.chbImportarProductosGeneraHistorialPrecios.LabelAsoc = Nothing
      Me.chbImportarProductosGeneraHistorialPrecios.Location = New System.Drawing.Point(50, 57)
      Me.chbImportarProductosGeneraHistorialPrecios.Name = "chbImportarProductosGeneraHistorialPrecios"
      Me.chbImportarProductosGeneraHistorialPrecios.Size = New System.Drawing.Size(253, 26)
      Me.chbImportarProductosGeneraHistorialPrecios.TabIndex = 60
      Me.chbImportarProductosGeneraHistorialPrecios.Tag = "IMPORTARPRODUCTOSGENERAHISTORIALPRECIOS"
      Me.chbImportarProductosGeneraHistorialPrecios.Text = "Importar Productos Genera Historial de Precios"
      Me.chbImportarProductosGeneraHistorialPrecios.UseVisualStyleBackColor = True
      '
      'chbTareasPorUsuario
      '
      Me.chbTareasPorUsuario.BindearPropiedadControl = Nothing
      Me.chbTareasPorUsuario.BindearPropiedadEntidad = Nothing
      Me.chbTareasPorUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTareasPorUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTareasPorUsuario.IsPK = False
      Me.chbTareasPorUsuario.IsRequired = False
      Me.chbTareasPorUsuario.Key = Nothing
      Me.chbTareasPorUsuario.LabelAsoc = Nothing
      Me.chbTareasPorUsuario.Location = New System.Drawing.Point(50, 25)
      Me.chbTareasPorUsuario.Name = "chbTareasPorUsuario"
      Me.chbTareasPorUsuario.Size = New System.Drawing.Size(143, 26)
      Me.chbTareasPorUsuario.TabIndex = 59
      Me.chbTareasPorUsuario.Tag = "TAREASPORUSUARIO"
      Me.chbTareasPorUsuario.Text = "Tareas por Usuarios"
      Me.chbTareasPorUsuario.UseVisualStyleBackColor = True
      '
      'cmbExportarPrecioProductoUsandoMoneda
      '
      Me.cmbExportarPrecioProductoUsandoMoneda.BindearPropiedadControl = Nothing
      Me.cmbExportarPrecioProductoUsandoMoneda.BindearPropiedadEntidad = Nothing
      Me.cmbExportarPrecioProductoUsandoMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbExportarPrecioProductoUsandoMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbExportarPrecioProductoUsandoMoneda.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbExportarPrecioProductoUsandoMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbExportarPrecioProductoUsandoMoneda.FormattingEnabled = True
      Me.cmbExportarPrecioProductoUsandoMoneda.IsPK = False
      Me.cmbExportarPrecioProductoUsandoMoneda.IsRequired = False
      Me.cmbExportarPrecioProductoUsandoMoneda.Items.AddRange(New Object() {"del producto"})
      Me.cmbExportarPrecioProductoUsandoMoneda.Key = Nothing
      Me.cmbExportarPrecioProductoUsandoMoneda.LabelAsoc = Me.lblExportarPrecioProductoUsandoMoneda
      Me.cmbExportarPrecioProductoUsandoMoneda.Location = New System.Drawing.Point(750, 25)
      Me.cmbExportarPrecioProductoUsandoMoneda.Name = "cmbExportarPrecioProductoUsandoMoneda"
      Me.cmbExportarPrecioProductoUsandoMoneda.Size = New System.Drawing.Size(100, 21)
      Me.cmbExportarPrecioProductoUsandoMoneda.TabIndex = 63
      '
      'ofdEjecutableTareaProgramada
      '
      Me.ofdEjecutableTareaProgramada.Filter = "Ejecutables Sinergia|Eniac*.exe"
      Me.ofdEjecutableTareaProgramada.InitialDirectory = "c:\Eniac"
      '
      'ucConfigProcesos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grpTareasProgramadas)
      Me.Controls.Add(Me.GroupBox16)
      Me.Controls.Add(Me.grbSubirAWeb)
      Me.Controls.Add(Me.txtCorreoPruebaPara)
      Me.Controls.Add(Me.lblCorreoPruebaPara)
      Me.Controls.Add(Me.txtExportarProductosDecimalesRedondeoEnPrecio)
      Me.Controls.Add(Me.lblExportarProductosDecimalesRedondeoEnPrecio)
      Me.Controls.Add(Me.chbExportarPreciosConIVA)
      Me.Controls.Add(Me.lblExportarPrecioProductoUsandoMoneda)
      Me.Controls.Add(Me.grbActualizarPreciosPlantillaExcel)
      Me.Controls.Add(Me.chbImportarProductosGeneraHistorialPrecios)
      Me.Controls.Add(Me.chbTareasPorUsuario)
      Me.Controls.Add(Me.cmbExportarPrecioProductoUsandoMoneda)
      Me.Name = "ucConfigProcesos"
      Me.Controls.SetChildIndex(Me.cmbExportarPrecioProductoUsandoMoneda, 0)
      Me.Controls.SetChildIndex(Me.chbTareasPorUsuario, 0)
      Me.Controls.SetChildIndex(Me.chbImportarProductosGeneraHistorialPrecios, 0)
      Me.Controls.SetChildIndex(Me.grbActualizarPreciosPlantillaExcel, 0)
      Me.Controls.SetChildIndex(Me.lblExportarPrecioProductoUsandoMoneda, 0)
      Me.Controls.SetChildIndex(Me.chbExportarPreciosConIVA, 0)
      Me.Controls.SetChildIndex(Me.lblExportarProductosDecimalesRedondeoEnPrecio, 0)
      Me.Controls.SetChildIndex(Me.txtExportarProductosDecimalesRedondeoEnPrecio, 0)
      Me.Controls.SetChildIndex(Me.lblCorreoPruebaPara, 0)
      Me.Controls.SetChildIndex(Me.txtCorreoPruebaPara, 0)
      Me.Controls.SetChildIndex(Me.grbSubirAWeb, 0)
      Me.Controls.SetChildIndex(Me.GroupBox16, 0)
      Me.Controls.SetChildIndex(Me.grpTareasProgramadas, 0)
      Me.grpTareasProgramadas.ResumeLayout(False)
      Me.grpTareasProgramadas.PerformLayout()
      Me.GroupBox16.ResumeLayout(False)
      Me.GroupBox16.PerformLayout()
      Me.grbSubirAWeb.ResumeLayout(False)
      Me.grbSubirAWeb.PerformLayout()
      Me.grbActualizarPreciosPlantillaExcel.ResumeLayout(False)
      Me.grbActualizarPreciosPlantillaExcel.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents grpTareasProgramadas As GroupBox
   Friend WithEvents btnEjecutableTareaProgramada As Button
   Friend WithEvents txtEjecutableTareaProgramada As Controles.TextBox
   Friend WithEvents lblEjecutableTareaProgramada As Controles.Label
   Friend WithEvents GroupBox16 As GroupBox
   Friend WithEvents chbRubrosComprasBajarWeb As Controles.CheckBox
   Friend WithEvents chbProveedoresBajarWeb As Controles.CheckBox
   Friend WithEvents chbMarcasBajarWeb As Controles.CheckBox
   Friend WithEvents chbRubrosBajarWeb As Controles.CheckBox
   Friend WithEvents chbLocalidadesBajarWeb As Controles.CheckBox
   Friend WithEvents chbProductosBajarWeb As Controles.CheckBox
   Friend WithEvents chbClientesBajarWeb As Controles.CheckBox
   Friend WithEvents grbSubirAWeb As GroupBox
   Friend WithEvents chbRubrosComprasSubirWeb As Controles.CheckBox
   Friend WithEvents chbProveedoresSubirWeb As Controles.CheckBox
   Friend WithEvents chbMarcasSubirWeb As Controles.CheckBox
   Friend WithEvents chbRubrosSubirWeb As Controles.CheckBox
   Friend WithEvents chbLocalidadesSubirWeb As Controles.CheckBox
   Friend WithEvents chbProductosSubirWeb As Controles.CheckBox
   Friend WithEvents chbClientesSubirWeb As Controles.CheckBox
   Friend WithEvents txtCorreoPruebaPara As Controles.TextBox
   Friend WithEvents lblCorreoPruebaPara As Controles.Label
   Friend WithEvents txtExportarProductosDecimalesRedondeoEnPrecio As Controles.TextBox
   Friend WithEvents lblExportarProductosDecimalesRedondeoEnPrecio As Controles.Label
   Friend WithEvents chbExportarPreciosConIVA As Controles.CheckBox
   Friend WithEvents lblExportarPrecioProductoUsandoMoneda As Controles.Label
   Friend WithEvents grbActualizarPreciosPlantillaExcel As GroupBox
   Friend WithEvents rdbAPExcelCosto As RadioButton
   Friend WithEvents rdbAPExcelVenta As RadioButton
   Friend WithEvents rdbAPExcelActual As RadioButton
   Friend WithEvents chbImportarProductosGeneraHistorialPrecios As Controles.CheckBox
   Friend WithEvents chbTareasPorUsuario As Controles.CheckBox
   Friend WithEvents cmbExportarPrecioProductoUsandoMoneda As Controles.ComboBox
   Friend WithEvents ofdEjecutableTareaProgramada As OpenFileDialog
End Class
