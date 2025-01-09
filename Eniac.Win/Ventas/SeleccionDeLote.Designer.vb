<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionDeLote
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.dtpFechaVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaVencimiento = New Eniac.Controles.Label()
      Me.lblIdLote = New Eniac.Controles.Label()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.bscLote = New Eniac.Controles.Buscador2()
      Me.grpOrigen = New System.Windows.Forms.GroupBox()
      Me.radNacional = New System.Windows.Forms.RadioButton()
      Me.radImprotacion = New System.Windows.Forms.RadioButton()
        Me.pnlInformeCalidad = New System.Windows.Forms.Panel()
        Me.txtLinkdoc = New Eniac.Controles.TextBox()
        Me.txtInformeCalidad = New Eniac.Controles.TextBox()
        Me.btnExaminar = New Eniac.Controles.Button()
        Me.lblInformeCalidad = New Eniac.Controles.Label()
        Me.lblLinkDoc = New Eniac.Controles.Label()
        Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.grpOrigen.SuspendLayout()
        Me.pnlInformeCalidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.BindearPropiedadControl = Nothing
        Me.dtpFechaVencimiento.BindearPropiedadEntidad = Nothing
        Me.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaVencimiento.Enabled = False
        Me.dtpFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaVencimiento.IsPK = False
        Me.dtpFechaVencimiento.IsRequired = False
        Me.dtpFechaVencimiento.Key = ""
        Me.dtpFechaVencimiento.LabelAsoc = Me.lblFechaVencimiento
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(83, 64)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaVencimiento.TabIndex = 4
        '
        'lblFechaVencimiento
        '
        Me.lblFechaVencimiento.AutoSize = True
        Me.lblFechaVencimiento.LabelAsoc = Nothing
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(12, 68)
        Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
        Me.lblFechaVencimiento.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaVencimiento.TabIndex = 3
        Me.lblFechaVencimiento.Text = "Vencimiento"
        '
        'lblIdLote
        '
        Me.lblIdLote.AutoSize = True
        Me.lblIdLote.LabelAsoc = Nothing
        Me.lblIdLote.Location = New System.Drawing.Point(12, 45)
        Me.lblIdLote.Name = "lblIdLote"
        Me.lblIdLote.Size = New System.Drawing.Size(28, 13)
        Me.lblIdLote.TabIndex = 1
        Me.lblIdLote.Text = "Lote"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(152, 164)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 35)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'bscLote
        '
        Me.bscLote.ActivarFiltroEnGrilla = True
        Me.bscLote.AutoSize = True
        Me.bscLote.BindearPropiedadControl = Nothing
        Me.bscLote.BindearPropiedadEntidad = Nothing
        Me.bscLote.ConfigBuscador = Nothing
        Me.bscLote.Datos = Nothing
        Me.bscLote.FilaDevuelta = Nothing
        Me.bscLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscLote.ForeColorFocus = System.Drawing.Color.Red
        Me.bscLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscLote.IsDecimal = False
        Me.bscLote.IsNumber = False
        Me.bscLote.IsPK = False
        Me.bscLote.IsRequired = False
        Me.bscLote.Key = ""
        Me.bscLote.LabelAsoc = Nothing
        Me.bscLote.Location = New System.Drawing.Point(47, 40)
        Me.bscLote.Margin = New System.Windows.Forms.Padding(4)
        Me.bscLote.MaxLengh = "30"
        Me.bscLote.Name = "bscLote"
        Me.bscLote.Permitido = True
        Me.bscLote.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscLote.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscLote.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscLote.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscLote.Selecciono = False
        Me.bscLote.Size = New System.Drawing.Size(197, 23)
        Me.bscLote.TabIndex = 2
        '
        'grpOrigen
        '
        Me.grpOrigen.Controls.Add(Me.radNacional)
        Me.grpOrigen.Controls.Add(Me.radImprotacion)
        Me.grpOrigen.Location = New System.Drawing.Point(15, -1)
        Me.grpOrigen.Name = "grpOrigen"
        Me.grpOrigen.Size = New System.Drawing.Size(215, 38)
        Me.grpOrigen.TabIndex = 0
        Me.grpOrigen.TabStop = False
        Me.grpOrigen.Text = "Origen de la compra"
        Me.grpOrigen.Visible = False
        '
        'radNacional
        '
        Me.radNacional.AutoSize = True
        Me.radNacional.Location = New System.Drawing.Point(129, 16)
        Me.radNacional.Name = "radNacional"
        Me.radNacional.Size = New System.Drawing.Size(67, 17)
        Me.radNacional.TabIndex = 1
        Me.radNacional.Text = "Nacional"
        Me.radNacional.UseVisualStyleBackColor = True
        '
        'radImprotacion
        '
        Me.radImprotacion.AutoSize = True
        Me.radImprotacion.Checked = True
        Me.radImprotacion.Location = New System.Drawing.Point(24, 15)
        Me.radImprotacion.Name = "radImprotacion"
        Me.radImprotacion.Size = New System.Drawing.Size(80, 17)
        Me.radImprotacion.TabIndex = 0
        Me.radImprotacion.TabStop = True
        Me.radImprotacion.Text = "Importación"
        Me.radImprotacion.UseVisualStyleBackColor = True
        '
        'pnlInformeCalidad
        '
        Me.pnlInformeCalidad.Controls.Add(Me.txtLinkdoc)
        Me.pnlInformeCalidad.Controls.Add(Me.txtInformeCalidad)
        Me.pnlInformeCalidad.Controls.Add(Me.btnExaminar)
        Me.pnlInformeCalidad.Controls.Add(Me.lblInformeCalidad)
        Me.pnlInformeCalidad.Controls.Add(Me.lblLinkDoc)
        Me.pnlInformeCalidad.Location = New System.Drawing.Point(8, 91)
        Me.pnlInformeCalidad.Name = "pnlInformeCalidad"
        Me.pnlInformeCalidad.Size = New System.Drawing.Size(236, 65)
        Me.pnlInformeCalidad.TabIndex = 5
        Me.pnlInformeCalidad.Visible = False
        '
        'txtLinkdoc
        '
        Me.txtLinkdoc.BindearPropiedadControl = ""
        Me.txtLinkdoc.BindearPropiedadEntidad = ""
        Me.txtLinkdoc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLinkdoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLinkdoc.Formato = ""
        Me.txtLinkdoc.IsDecimal = False
        Me.txtLinkdoc.IsNumber = False
        Me.txtLinkdoc.IsPK = False
        Me.txtLinkdoc.IsRequired = False
        Me.txtLinkdoc.Key = ""
        Me.txtLinkdoc.LabelAsoc = Nothing
        Me.txtLinkdoc.Location = New System.Drawing.Point(64, 31)
        Me.txtLinkdoc.MaxLength = 60
        Me.txtLinkdoc.Name = "txtLinkdoc"
        Me.txtLinkdoc.Size = New System.Drawing.Size(129, 20)
        Me.txtLinkdoc.TabIndex = 3
        '
        'txtInformeCalidad
        '
        Me.txtInformeCalidad.BindearPropiedadControl = ""
        Me.txtInformeCalidad.BindearPropiedadEntidad = ""
        Me.txtInformeCalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtInformeCalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtInformeCalidad.Formato = ""
        Me.txtInformeCalidad.IsDecimal = False
        Me.txtInformeCalidad.IsNumber = False
        Me.txtInformeCalidad.IsPK = False
        Me.txtInformeCalidad.IsRequired = False
        Me.txtInformeCalidad.Key = ""
        Me.txtInformeCalidad.LabelAsoc = Nothing
        Me.txtInformeCalidad.Location = New System.Drawing.Point(90, 3)
        Me.txtInformeCalidad.MaxLength = 60
        Me.txtInformeCalidad.Name = "txtInformeCalidad"
        Me.txtInformeCalidad.Size = New System.Drawing.Size(103, 20)
        Me.txtInformeCalidad.TabIndex = 1
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
        Me.btnExaminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExaminar.Location = New System.Drawing.Point(199, 31)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(30, 21)
        Me.btnExaminar.TabIndex = 4
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'lblInformeCalidad
        '
        Me.lblInformeCalidad.AutoSize = True
        Me.lblInformeCalidad.LabelAsoc = Nothing
        Me.lblInformeCalidad.Location = New System.Drawing.Point(4, 7)
        Me.lblInformeCalidad.Name = "lblInformeCalidad"
        Me.lblInformeCalidad.Size = New System.Drawing.Size(80, 13)
        Me.lblInformeCalidad.TabIndex = 0
        Me.lblInformeCalidad.Text = "Informe Calidad"
        '
        'lblLinkDoc
        '
        Me.lblLinkDoc.AutoSize = True
        Me.lblLinkDoc.LabelAsoc = Nothing
        Me.lblLinkDoc.Location = New System.Drawing.Point(3, 34)
        Me.lblLinkDoc.Name = "lblLinkDoc"
        Me.lblLinkDoc.Size = New System.Drawing.Size(53, 13)
        Me.lblLinkDoc.TabIndex = 2
        Me.lblLinkDoc.Text = "Link Doc."
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'SeleccionDeLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 207)
        Me.Controls.Add(Me.pnlInformeCalidad)
        Me.Controls.Add(Me.bscLote)
        Me.Controls.Add(Me.lblIdLote)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dtpFechaVencimiento)
        Me.Controls.Add(Me.lblFechaVencimiento)
        Me.Controls.Add(Me.grpOrigen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SeleccionDeLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione un Lote"
        Me.grpOrigen.ResumeLayout(False)
        Me.grpOrigen.PerformLayout()
        Me.pnlInformeCalidad.ResumeLayout(False)
        Me.pnlInformeCalidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaVencimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaVencimiento As Eniac.Controles.Label
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents lblIdLote As Eniac.Controles.Label
   Friend WithEvents bscLote As Eniac.Controles.Buscador2
   Friend WithEvents grpOrigen As System.Windows.Forms.GroupBox
   Friend WithEvents radNacional As System.Windows.Forms.RadioButton
   Friend WithEvents radImprotacion As System.Windows.Forms.RadioButton
    Friend WithEvents pnlInformeCalidad As Panel
    Friend WithEvents txtLinkdoc As Controles.TextBox
    Friend WithEvents txtInformeCalidad As Controles.TextBox
    Friend WithEvents btnExaminar As Controles.Button
    Friend WithEvents lblInformeCalidad As Controles.Label
    Friend WithEvents lblLinkDoc As Controles.Label
    Friend WithEvents DialogoAbrirArchivo As OpenFileDialog
End Class
