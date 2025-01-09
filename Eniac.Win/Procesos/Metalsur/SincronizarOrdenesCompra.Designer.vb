<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SincronizarOrdenesCompra
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SincronizarOrdenesCompra))
      Me.bkgSincronizar = New System.ComponentModel.BackgroundWorker()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.btnSincronizar = New System.Windows.Forms.Button()
      Me.btnEnivarWeb = New System.Windows.Forms.Button()
      Me.btnDescargarRespuestas = New System.Windows.Forms.Button()
      Me.btnImportarDesdeBejerman = New System.Windows.Forms.Button()
      Me.chbReimportar = New Eniac.Controles.CheckBox()
      Me.chbReenviar = New Eniac.Controles.CheckBox()
      Me.chbDescargarTodo = New Eniac.Controles.CheckBox()
      Me.chbEnviarWebProveedores = New Eniac.Controles.CheckBox()
      Me.chbExportarProveedores = New Eniac.Controles.CheckBox()
      Me.chbEnviarWebOrdenCompra = New Eniac.Controles.CheckBox()
      Me.chbExportarOrdenCompra = New Eniac.Controles.CheckBox()
      Me.btnFE = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpFechaOCN = New Eniac.Controles.DateTimePicker()
      Me.dtpFE = New Eniac.Controles.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.btnOCN = New System.Windows.Forms.Button()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'bkgSincronizar
        '
        Me.bkgSincronizar.WorkerReportsProgress = True
        Me.bkgSincronizar.WorkerSupportsCancellation = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(788, 29)
        Me.tstBarra.TabIndex = 11
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 358)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(788, 22)
        Me.stsStado.TabIndex = 10
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(709, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSincronizar.Image = Global.Eniac.Win.My.Resources.Resources.exchange
        Me.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSincronizar.Location = New System.Drawing.Point(12, 32)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnSincronizar.Size = New System.Drawing.Size(378, 99)
        Me.btnSincronizar.TabIndex = 12
        Me.btnSincronizar.Text = "Sincronizar completo"
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'btnEnivarWeb
        '
        Me.btnEnivarWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnivarWeb.Image = Global.Eniac.Win.My.Resources.Resources.world_up_64
        Me.btnEnivarWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnivarWeb.Location = New System.Drawing.Point(398, 137)
        Me.btnEnivarWeb.Name = "btnEnivarWeb"
        Me.btnEnivarWeb.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnEnivarWeb.Size = New System.Drawing.Size(378, 99)
        Me.btnEnivarWeb.TabIndex = 13
        Me.btnEnivarWeb.Text = "Enviar a la Web"
        Me.btnEnivarWeb.UseVisualStyleBackColor = True
        '
        'btnDescargarRespuestas
        '
        Me.btnDescargarRespuestas.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescargarRespuestas.Image = Global.Eniac.Win.My.Resources.Resources.world_down_64
        Me.btnDescargarRespuestas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescargarRespuestas.Location = New System.Drawing.Point(398, 242)
        Me.btnDescargarRespuestas.Name = "btnDescargarRespuestas"
        Me.btnDescargarRespuestas.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnDescargarRespuestas.Size = New System.Drawing.Size(378, 99)
        Me.btnDescargarRespuestas.TabIndex = 13
        Me.btnDescargarRespuestas.Text = "Descargar respuestas"
        Me.btnDescargarRespuestas.UseVisualStyleBackColor = True
        '
        'btnImportarDesdeBejerman
        '
        Me.btnImportarDesdeBejerman.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportarDesdeBejerman.Image = Global.Eniac.Win.My.Resources.Resources.database_save_32
        Me.btnImportarDesdeBejerman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarDesdeBejerman.Location = New System.Drawing.Point(398, 32)
        Me.btnImportarDesdeBejerman.Name = "btnImportarDesdeBejerman"
        Me.btnImportarDesdeBejerman.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnImportarDesdeBejerman.Size = New System.Drawing.Size(378, 99)
        Me.btnImportarDesdeBejerman.TabIndex = 14
        Me.btnImportarDesdeBejerman.Text = "Importar desde Bejerman"
        Me.btnImportarDesdeBejerman.UseVisualStyleBackColor = True
        '
        'chbReimportar
        '
        Me.chbReimportar.AutoSize = True
        Me.chbReimportar.BindearPropiedadControl = Nothing
        Me.chbReimportar.BindearPropiedadEntidad = Nothing
        Me.chbReimportar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReimportar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReimportar.IsPK = False
        Me.chbReimportar.IsRequired = False
        Me.chbReimportar.Key = Nothing
        Me.chbReimportar.LabelAsoc = Nothing
        Me.chbReimportar.Location = New System.Drawing.Point(47, 150)
        Me.chbReimportar.Name = "chbReimportar"
        Me.chbReimportar.Size = New System.Drawing.Size(77, 17)
        Me.chbReimportar.TabIndex = 15
        Me.chbReimportar.Text = "Reimportar"
        Me.chbReimportar.UseVisualStyleBackColor = True
        '
        'chbReenviar
        '
        Me.chbReenviar.AutoSize = True
        Me.chbReenviar.BindearPropiedadControl = Nothing
        Me.chbReenviar.BindearPropiedadEntidad = Nothing
        Me.chbReenviar.Checked = True
        Me.chbReenviar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbReenviar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReenviar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReenviar.IsPK = False
        Me.chbReenviar.IsRequired = False
        Me.chbReenviar.Key = Nothing
        Me.chbReenviar.LabelAsoc = Nothing
        Me.chbReenviar.Location = New System.Drawing.Point(47, 173)
        Me.chbReenviar.Name = "chbReenviar"
        Me.chbReenviar.Size = New System.Drawing.Size(69, 17)
        Me.chbReenviar.TabIndex = 15
        Me.chbReenviar.Text = "Reenviar"
        Me.chbReenviar.UseVisualStyleBackColor = True
        '
        'chbDescargarTodo
        '
        Me.chbDescargarTodo.AutoSize = True
        Me.chbDescargarTodo.BindearPropiedadControl = Nothing
        Me.chbDescargarTodo.BindearPropiedadEntidad = Nothing
        Me.chbDescargarTodo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDescargarTodo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDescargarTodo.IsPK = False
        Me.chbDescargarTodo.IsRequired = False
        Me.chbDescargarTodo.Key = Nothing
        Me.chbDescargarTodo.LabelAsoc = Nothing
        Me.chbDescargarTodo.Location = New System.Drawing.Point(47, 219)
        Me.chbDescargarTodo.Name = "chbDescargarTodo"
        Me.chbDescargarTodo.Size = New System.Drawing.Size(103, 17)
        Me.chbDescargarTodo.TabIndex = 15
        Me.chbDescargarTodo.Text = "Descargar Todo"
        Me.chbDescargarTodo.UseVisualStyleBackColor = True
        '
        'chbEnviarWebProveedores
        '
        Me.chbEnviarWebProveedores.AutoSize = True
        Me.chbEnviarWebProveedores.BindearPropiedadControl = Nothing
        Me.chbEnviarWebProveedores.BindearPropiedadEntidad = Nothing
        Me.chbEnviarWebProveedores.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEnviarWebProveedores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEnviarWebProveedores.IsPK = False
        Me.chbEnviarWebProveedores.IsRequired = False
        Me.chbEnviarWebProveedores.Key = Nothing
        Me.chbEnviarWebProveedores.LabelAsoc = Nothing
        Me.chbEnviarWebProveedores.Location = New System.Drawing.Point(122, 173)
        Me.chbEnviarWebProveedores.Name = "chbEnviarWebProveedores"
        Me.chbEnviarWebProveedores.Size = New System.Drawing.Size(119, 17)
        Me.chbEnviarWebProveedores.TabIndex = 15
        Me.chbEnviarWebProveedores.Text = "Enviar Proveedores"
        Me.chbEnviarWebProveedores.UseVisualStyleBackColor = True
        '
        'chbExportarProveedores
        '
        Me.chbExportarProveedores.AutoSize = True
        Me.chbExportarProveedores.BindearPropiedadControl = Nothing
        Me.chbExportarProveedores.BindearPropiedadEntidad = Nothing
        Me.chbExportarProveedores.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExportarProveedores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExportarProveedores.IsPK = False
        Me.chbExportarProveedores.IsRequired = False
        Me.chbExportarProveedores.Key = Nothing
        Me.chbExportarProveedores.LabelAsoc = Nothing
        Me.chbExportarProveedores.Location = New System.Drawing.Point(255, 173)
        Me.chbExportarProveedores.Name = "chbExportarProveedores"
        Me.chbExportarProveedores.Size = New System.Drawing.Size(128, 17)
        Me.chbExportarProveedores.TabIndex = 15
        Me.chbExportarProveedores.Text = "Exportar Proveedores"
        Me.chbExportarProveedores.UseVisualStyleBackColor = True
        '
        'chbEnviarWebOrdenCompra
        '
        Me.chbEnviarWebOrdenCompra.AutoSize = True
        Me.chbEnviarWebOrdenCompra.BindearPropiedadControl = Nothing
        Me.chbEnviarWebOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.chbEnviarWebOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEnviarWebOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEnviarWebOrdenCompra.IsPK = False
        Me.chbEnviarWebOrdenCompra.IsRequired = False
        Me.chbEnviarWebOrdenCompra.Key = Nothing
        Me.chbEnviarWebOrdenCompra.LabelAsoc = Nothing
        Me.chbEnviarWebOrdenCompra.Location = New System.Drawing.Point(122, 196)
        Me.chbEnviarWebOrdenCompra.Name = "chbEnviarWebOrdenCompra"
        Me.chbEnviarWebOrdenCompra.Size = New System.Drawing.Size(127, 17)
        Me.chbEnviarWebOrdenCompra.TabIndex = 15
        Me.chbEnviarWebOrdenCompra.Text = "Enviar Orden Compra"
        Me.chbEnviarWebOrdenCompra.UseVisualStyleBackColor = True
        '
        'chbExportarOrdenCompra
        '
        Me.chbExportarOrdenCompra.AutoSize = True
        Me.chbExportarOrdenCompra.BindearPropiedadControl = Nothing
        Me.chbExportarOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.chbExportarOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExportarOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExportarOrdenCompra.IsPK = False
        Me.chbExportarOrdenCompra.IsRequired = False
        Me.chbExportarOrdenCompra.Key = Nothing
        Me.chbExportarOrdenCompra.LabelAsoc = Nothing
        Me.chbExportarOrdenCompra.Location = New System.Drawing.Point(255, 196)
        Me.chbExportarOrdenCompra.Name = "chbExportarOrdenCompra"
        Me.chbExportarOrdenCompra.Size = New System.Drawing.Size(136, 17)
        Me.chbExportarOrdenCompra.TabIndex = 15
        Me.chbExportarOrdenCompra.Text = "Exportar Orden Compra"
        Me.chbExportarOrdenCompra.UseVisualStyleBackColor = True
        '
        'btnFE
        '
        Me.btnFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFE.Image = Global.Eniac.Win.My.Resources.Resources.database_save_32
        Me.btnFE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFE.Location = New System.Drawing.Point(186, 247)
        Me.btnFE.Name = "btnFE"
        Me.btnFE.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnFE.Size = New System.Drawing.Size(148, 51)
        Me.btnFE.TabIndex = 16
        Me.btnFE.Text = "Mod. FEnt./Cant./Imp."
        Me.btnFE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Fecha OCN"
        Me.Label1.Visible = False
        '
        'dtpFechaOCN
        '
        Me.dtpFechaOCN.BindearPropiedadControl = Nothing
        Me.dtpFechaOCN.BindearPropiedadEntidad = Nothing
        Me.dtpFechaOCN.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaOCN.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaOCN.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaOCN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOCN.IsPK = False
        Me.dtpFechaOCN.IsRequired = False
        Me.dtpFechaOCN.Key = ""
        Me.dtpFechaOCN.LabelAsoc = Nothing
        Me.dtpFechaOCN.Location = New System.Drawing.Point(49, 320)
        Me.dtpFechaOCN.Name = "dtpFechaOCN"
        Me.dtpFechaOCN.Size = New System.Drawing.Size(131, 20)
        Me.dtpFechaOCN.TabIndex = 19
        Me.dtpFechaOCN.Visible = False
        '
        'dtpFE
        '
        Me.dtpFE.BindearPropiedadControl = Nothing
        Me.dtpFE.BindearPropiedadEntidad = Nothing
        Me.dtpFE.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFE.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFE.IsPK = False
        Me.dtpFE.IsRequired = False
        Me.dtpFE.Key = ""
        Me.dtpFE.LabelAsoc = Nothing
        Me.dtpFE.Location = New System.Drawing.Point(186, 320)
        Me.dtpFE.Name = "dtpFE"
        Me.dtpFE.Size = New System.Drawing.Size(127, 20)
        Me.dtpFE.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 304)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Fecha Mod "
        '
        'btnOCN
        '
        Me.btnOCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOCN.Image = Global.Eniac.Win.My.Resources.Resources.database_save_32
        Me.btnOCN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOCN.Location = New System.Drawing.Point(49, 247)
        Me.btnOCN.Name = "btnOCN"
        Me.btnOCN.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnOCN.Size = New System.Drawing.Size(118, 51)
        Me.btnOCN.TabIndex = 22
        Me.btnOCN.Text = "OCN"
        Me.btnOCN.UseVisualStyleBackColor = True
        Me.btnOCN.Visible = False
        '
        'SincronizarOrdenesCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 380)
        Me.Controls.Add(Me.btnOCN)
        Me.Controls.Add(Me.dtpFE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFechaOCN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFE)
        Me.Controls.Add(Me.chbDescargarTodo)
        Me.Controls.Add(Me.chbExportarOrdenCompra)
        Me.Controls.Add(Me.chbExportarProveedores)
        Me.Controls.Add(Me.chbEnviarWebOrdenCompra)
        Me.Controls.Add(Me.chbEnviarWebProveedores)
        Me.Controls.Add(Me.chbReenviar)
        Me.Controls.Add(Me.chbReimportar)
        Me.Controls.Add(Me.btnImportarDesdeBejerman)
        Me.Controls.Add(Me.btnDescargarRespuestas)
        Me.Controls.Add(Me.btnEnivarWeb)
        Me.Controls.Add(Me.btnSincronizar)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Name = "SincronizarOrdenesCompra"
        Me.Text = "Sincronizar"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bkgSincronizar As System.ComponentModel.BackgroundWorker
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnSincronizar As System.Windows.Forms.Button
   Friend WithEvents btnEnivarWeb As System.Windows.Forms.Button
   Friend WithEvents btnDescargarRespuestas As System.Windows.Forms.Button
   Friend WithEvents btnImportarDesdeBejerman As System.Windows.Forms.Button
   Friend WithEvents chbReimportar As Eniac.Controles.CheckBox
   Friend WithEvents chbReenviar As Eniac.Controles.CheckBox
   Friend WithEvents chbDescargarTodo As Eniac.Controles.CheckBox
   Friend WithEvents chbEnviarWebProveedores As Eniac.Controles.CheckBox
   Friend WithEvents chbExportarProveedores As Eniac.Controles.CheckBox
   Friend WithEvents chbEnviarWebOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents chbExportarOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents btnFE As Button
   Friend WithEvents Label1 As Label
   Friend WithEvents dtpFechaOCN As Controles.DateTimePicker
   Friend WithEvents dtpFE As Controles.DateTimePicker
   Friend WithEvents Label2 As Label
   Friend WithEvents btnOCN As Button
End Class
