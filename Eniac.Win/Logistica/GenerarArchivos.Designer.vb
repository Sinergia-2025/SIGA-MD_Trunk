<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarArchivos
    Inherits Eniac.Win.BaseForm


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
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.grpListas = New System.Windows.Forms.GroupBox()
      Me.clbListaDePrecios = New System.Windows.Forms.CheckedListBox()
      Me.chbTodasListas = New Eniac.Controles.CheckBox()
      Me.grpArchivos = New System.Windows.Forms.GroupBox()
      Me.clbArchivos = New System.Windows.Forms.CheckedListBox()
      Me.chbConIVA = New Eniac.Controles.CheckBox()
      Me.chbTodosArchivos = New Eniac.Controles.CheckBox()
      Me.cmbFormatoArchivo = New Eniac.Controles.ComboBox()
      Me.lblFormatoArchivo = New Eniac.Controles.Label()
      Me.cmbRutas = New Eniac.Controles.ComboBox()
      Me.lblruta = New Eniac.Controles.Label()
      Me.btnSalir = New Eniac.Controles.Button()
      Me.lblVendedor = New Eniac.Controles.Label()
      Me.btnGenerar = New Eniac.Controles.Button()
      Me.cmdExaminar = New Eniac.Controles.Button()
      Me.lblDestino = New Eniac.Controles.Label()
      Me.txtdestino = New Eniac.Controles.TextBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.grpListas.SuspendLayout()
      Me.grpArchivos.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Location = New System.Drawing.Point(12, 12)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(509, 352)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.Controls.Add(Me.grpListas)
      Me.TabPage1.Controls.Add(Me.grpArchivos)
      Me.TabPage1.Controls.Add(Me.cmbFormatoArchivo)
      Me.TabPage1.Controls.Add(Me.cmbRutas)
      Me.TabPage1.Controls.Add(Me.btnSalir)
      Me.TabPage1.Controls.Add(Me.lblFormatoArchivo)
      Me.TabPage1.Controls.Add(Me.lblVendedor)
      Me.TabPage1.Controls.Add(Me.lblruta)
      Me.TabPage1.Controls.Add(Me.btnGenerar)
      Me.TabPage1.Controls.Add(Me.cmdExaminar)
      Me.TabPage1.Controls.Add(Me.lblDestino)
      Me.TabPage1.Controls.Add(Me.txtdestino)
      Me.TabPage1.Controls.Add(Me.cmbVendedor)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(501, 326)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Exportar"
      Me.TabPage1.UseVisualStyleBackColor = True
      '
      'grpListas
      '
      Me.grpListas.Controls.Add(Me.clbListaDePrecios)
      Me.grpListas.Controls.Add(Me.chbTodasListas)
      Me.grpListas.Location = New System.Drawing.Point(302, 40)
      Me.grpListas.Name = "grpListas"
      Me.grpListas.Size = New System.Drawing.Size(170, 162)
      Me.grpListas.TabIndex = 7
      Me.grpListas.TabStop = False
      Me.grpListas.Text = " Listas de Precios "
      '
      'clbListaDePrecios
      '
      Me.clbListaDePrecios.CheckOnClick = True
      Me.clbListaDePrecios.FormattingEnabled = True
      Me.clbListaDePrecios.Location = New System.Drawing.Point(6, 19)
      Me.clbListaDePrecios.Name = "clbListaDePrecios"
      Me.clbListaDePrecios.Size = New System.Drawing.Size(158, 109)
      Me.clbListaDePrecios.TabIndex = 0
      '
      'chbTodasListas
      '
      Me.chbTodasListas.AutoSize = True
      Me.chbTodasListas.BindearPropiedadControl = Nothing
      Me.chbTodasListas.BindearPropiedadEntidad = Nothing
      Me.chbTodasListas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodasListas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodasListas.IsPK = False
      Me.chbTodasListas.IsRequired = False
      Me.chbTodasListas.Key = Nothing
      Me.chbTodasListas.LabelAsoc = Nothing
      Me.chbTodasListas.Location = New System.Drawing.Point(9, 134)
      Me.chbTodasListas.Name = "chbTodasListas"
      Me.chbTodasListas.Size = New System.Drawing.Size(115, 17)
      Me.chbTodasListas.TabIndex = 1
      Me.chbTodasListas.Text = "Seleccionar Todas"
      Me.chbTodasListas.UseVisualStyleBackColor = True
      '
      'grpArchivos
      '
      Me.grpArchivos.Controls.Add(Me.clbArchivos)
      Me.grpArchivos.Controls.Add(Me.chbConIVA)
      Me.grpArchivos.Controls.Add(Me.chbTodosArchivos)
      Me.grpArchivos.Location = New System.Drawing.Point(24, 40)
      Me.grpArchivos.Name = "grpArchivos"
      Me.grpArchivos.Size = New System.Drawing.Size(269, 162)
      Me.grpArchivos.TabIndex = 6
      Me.grpArchivos.TabStop = False
      Me.grpArchivos.Text = " Archivos a generar "
      '
      'clbArchivos
      '
      Me.clbArchivos.CheckOnClick = True
      Me.clbArchivos.FormattingEnabled = True
      Me.clbArchivos.Items.AddRange(New Object() {"RUTAS", "CLIENTES", "PRODUCTOS", "LISTAS DE PRECIOS", "RUBROS", "HISTÓRICOS", "CONFIGURACIONES"})
      Me.clbArchivos.Location = New System.Drawing.Point(6, 17)
      Me.clbArchivos.Name = "clbArchivos"
      Me.clbArchivos.Size = New System.Drawing.Size(158, 109)
      Me.clbArchivos.TabIndex = 0
      '
      'chbConIVA
      '
      Me.chbConIVA.AutoSize = True
      Me.chbConIVA.BindearPropiedadControl = Nothing
      Me.chbConIVA.BindearPropiedadEntidad = Nothing
      Me.chbConIVA.Enabled = False
      Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConIVA.IsPK = False
      Me.chbConIVA.IsRequired = False
      Me.chbConIVA.Key = Nothing
      Me.chbConIVA.LabelAsoc = Nothing
      Me.chbConIVA.Location = New System.Drawing.Point(168, 54)
      Me.chbConIVA.Name = "chbConIVA"
      Me.chbConIVA.Size = New System.Drawing.Size(97, 17)
      Me.chbConIVA.TabIndex = 1
      Me.chbConIVA.Text = "Precio con IVA"
      Me.chbConIVA.UseVisualStyleBackColor = True
      '
      'chbTodosArchivos
      '
      Me.chbTodosArchivos.AutoSize = True
      Me.chbTodosArchivos.BindearPropiedadControl = Nothing
      Me.chbTodosArchivos.BindearPropiedadEntidad = Nothing
      Me.chbTodosArchivos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodosArchivos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodosArchivos.IsPK = False
      Me.chbTodosArchivos.IsRequired = False
      Me.chbTodosArchivos.Key = Nothing
      Me.chbTodosArchivos.LabelAsoc = Nothing
      Me.chbTodosArchivos.Location = New System.Drawing.Point(9, 132)
      Me.chbTodosArchivos.Name = "chbTodosArchivos"
      Me.chbTodosArchivos.Size = New System.Drawing.Size(115, 17)
      Me.chbTodosArchivos.TabIndex = 2
      Me.chbTodosArchivos.Text = "Seleccionar Todos"
      Me.chbTodosArchivos.UseVisualStyleBackColor = True
      '
      'cmbFormatoArchivo
      '
      Me.cmbFormatoArchivo.BindearPropiedadControl = Nothing
      Me.cmbFormatoArchivo.BindearPropiedadEntidad = Nothing
      Me.cmbFormatoArchivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormatoArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormatoArchivo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormatoArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormatoArchivo.FormattingEnabled = True
      Me.cmbFormatoArchivo.IsPK = False
      Me.cmbFormatoArchivo.IsRequired = False
      Me.cmbFormatoArchivo.Key = Nothing
      Me.cmbFormatoArchivo.LabelAsoc = Me.lblFormatoArchivo
      Me.cmbFormatoArchivo.Location = New System.Drawing.Point(112, 208)
      Me.cmbFormatoArchivo.Name = "cmbFormatoArchivo"
      Me.cmbFormatoArchivo.Size = New System.Drawing.Size(122, 21)
      Me.cmbFormatoArchivo.TabIndex = 9
      '
      'lblFormatoArchivo
      '
      Me.lblFormatoArchivo.AutoSize = True
      Me.lblFormatoArchivo.Location = New System.Drawing.Point(21, 211)
      Me.lblFormatoArchivo.Name = "lblFormatoArchivo"
      Me.lblFormatoArchivo.Size = New System.Drawing.Size(86, 13)
      Me.lblFormatoArchivo.TabIndex = 8
      Me.lblFormatoArchivo.Text = "Formato archivo:"
      '
      'cmbRutas
      '
      Me.cmbRutas.BindearPropiedadControl = Nothing
      Me.cmbRutas.BindearPropiedadEntidad = Nothing
      Me.cmbRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRutas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbRutas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRutas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRutas.FormattingEnabled = True
      Me.cmbRutas.IsPK = False
      Me.cmbRutas.IsRequired = False
      Me.cmbRutas.Key = Nothing
      Me.cmbRutas.LabelAsoc = Me.lblruta
      Me.cmbRutas.Location = New System.Drawing.Point(345, 13)
      Me.cmbRutas.Name = "cmbRutas"
      Me.cmbRutas.Size = New System.Drawing.Size(122, 21)
      Me.cmbRutas.TabIndex = 5
      '
      'lblruta
      '
      Me.lblruta.AutoSize = True
      Me.lblruta.Location = New System.Drawing.Point(309, 17)
      Me.lblruta.Name = "lblruta"
      Me.lblruta.Size = New System.Drawing.Size(30, 13)
      Me.lblruta.TabIndex = 4
      Me.lblruta.Text = "Ruta"
      '
      'btnSalir
      '
      Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnSalir.Location = New System.Drawing.Point(390, 275)
      Me.btnSalir.Name = "btnSalir"
      Me.btnSalir.Size = New System.Drawing.Size(105, 45)
      Me.btnSalir.TabIndex = 14
      Me.btnSalir.Text = "Salir"
      Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnSalir.UseVisualStyleBackColor = True
      '
      'lblVendedor
      '
      Me.lblVendedor.AutoSize = True
      Me.lblVendedor.Location = New System.Drawing.Point(36, 17)
      Me.lblVendedor.Name = "lblVendedor"
      Me.lblVendedor.Size = New System.Drawing.Size(60, 13)
      Me.lblVendedor.TabIndex = 2
      Me.lblVendedor.Text = "Preventista"
      '
      'btnGenerar
      '
      Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGenerar.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
      Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGenerar.Location = New System.Drawing.Point(279, 275)
      Me.btnGenerar.Name = "btnGenerar"
      Me.btnGenerar.Size = New System.Drawing.Size(105, 45)
      Me.btnGenerar.TabIndex = 13
      Me.btnGenerar.Text = "Generar (F4)"
      Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGenerar.UseVisualStyleBackColor = True
      '
      'cmdExaminar
      '
      Me.cmdExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
      Me.cmdExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.cmdExaminar.Location = New System.Drawing.Point(427, 233)
      Me.cmdExaminar.Name = "cmdExaminar"
      Me.cmdExaminar.Size = New System.Drawing.Size(45, 23)
      Me.cmdExaminar.TabIndex = 12
      Me.cmdExaminar.Text = "..."
      Me.cmdExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdExaminar.UseVisualStyleBackColor = True
      '
      'lblDestino
      '
      Me.lblDestino.AutoSize = True
      Me.lblDestino.Location = New System.Drawing.Point(21, 238)
      Me.lblDestino.Name = "lblDestino"
      Me.lblDestino.Size = New System.Drawing.Size(85, 13)
      Me.lblDestino.TabIndex = 10
      Me.lblDestino.Text = "Destino Archivo:"
      '
      'txtdestino
      '
      Me.txtdestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtdestino.BindearPropiedadControl = Nothing
      Me.txtdestino.BindearPropiedadEntidad = Nothing
      Me.txtdestino.ForeColorFocus = System.Drawing.Color.Red
      Me.txtdestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtdestino.Formato = ""
      Me.txtdestino.IsDecimal = False
      Me.txtdestino.IsNumber = False
      Me.txtdestino.IsPK = False
      Me.txtdestino.IsRequired = False
      Me.txtdestino.Key = ""
      Me.txtdestino.LabelAsoc = Me.lblDestino
      Me.txtdestino.Location = New System.Drawing.Point(112, 235)
      Me.txtdestino.Name = "txtdestino"
      Me.txtdestino.Size = New System.Drawing.Size(309, 20)
      Me.txtdestino.TabIndex = 11
      '
      'cmbVendedor
      '
      Me.cmbVendedor.BindearPropiedadControl = ""
      Me.cmbVendedor.BindearPropiedadEntidad = ""
      Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVendedor.FormattingEnabled = True
      Me.cmbVendedor.IsPK = False
      Me.cmbVendedor.IsRequired = True
      Me.cmbVendedor.Key = Nothing
      Me.cmbVendedor.LabelAsoc = Me.lblVendedor
      Me.cmbVendedor.Location = New System.Drawing.Point(102, 13)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(181, 21)
      Me.cmbVendedor.TabIndex = 3
      '
      'GenerarArchivos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(533, 376)
      Me.Controls.Add(Me.TabControl1)
      Me.Name = "GenerarArchivos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Generar Archivos"
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.grpListas.ResumeLayout(False)
      Me.grpListas.PerformLayout()
      Me.grpArchivos.ResumeLayout(False)
      Me.grpArchivos.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents lblDestino As Eniac.Controles.Label
   Friend WithEvents txtdestino As Eniac.Controles.TextBox
   Friend WithEvents btnGenerar As Eniac.Controles.Button
   Friend WithEvents cmdExaminar As Eniac.Controles.Button
   Friend WithEvents clbArchivos As System.Windows.Forms.CheckedListBox
   Friend WithEvents lblruta As Eniac.Controles.Label
   Friend WithEvents btnSalir As Eniac.Controles.Button
   Friend WithEvents cmbRutas As Eniac.Controles.ComboBox
   Friend WithEvents lblVendedor As Eniac.Controles.Label
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormatoArchivo As Eniac.Controles.ComboBox
   Friend WithEvents lblFormatoArchivo As Eniac.Controles.Label
   Friend WithEvents clbListaDePrecios As System.Windows.Forms.CheckedListBox
   Friend WithEvents chbTodasListas As Eniac.Controles.CheckBox
   Friend WithEvents chbTodosArchivos As Eniac.Controles.CheckBox
   Friend WithEvents grpListas As System.Windows.Forms.GroupBox
   Friend WithEvents grpArchivos As System.Windows.Forms.GroupBox
End Class
