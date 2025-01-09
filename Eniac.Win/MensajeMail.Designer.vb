<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MensajeMail
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.lblAsunto = New Eniac.Controles.Label()
      Me.txtAsunto = New Eniac.Controles.TextBox()
      Me.txtCuerpo = New Eniac.Controles.TextBox()
      Me.lblCuerpo = New Eniac.Controles.Label()
      Me.btnEnviar = New Eniac.Controles.Button()
      Me.lblAdjuntos = New Eniac.Controles.Label()
      Me.sstPie = New System.Windows.Forms.StatusStrip()
      Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbCopiaASiMismo = New Eniac.Controles.CheckBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblDestinatarios = New Eniac.Controles.Label()
      Me.grpDestinatariosCC = New Infragistics.Win.Misc.UltraExpandableGroupBox()
      Me.UltraExpandableGroupBoxPanel2 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
      Me.txtDestinatariosCC = New Eniac.Controles.TextBox()
      Me.grpDestinatariosCCO = New Infragistics.Win.Misc.UltraExpandableGroupBox()
      Me.UltraExpandableGroupBoxPanel3 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
      Me.txtDestinatariosCCO = New Eniac.Controles.TextBox()
      Me.grpDestinatarios = New Infragistics.Win.Misc.UltraExpandableGroupBox()
      Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
      Me.txtDestinatarios = New Eniac.Controles.TextBox()
      Me.btnAgenda = New Eniac.Controles.Button()
        Me.btnVerAdjunto = New Eniac.Controles.Button()
        Me.sstPie.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grpDestinatariosCC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDestinatariosCC.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel2.SuspendLayout()
        CType(Me.grpDestinatariosCCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDestinatariosCCO.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel3.SuspendLayout()
        CType(Me.grpDestinatarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDestinatarios.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAsunto
        '
        Me.lblAsunto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAsunto.AutoSize = True
        Me.lblAsunto.LabelAsoc = Nothing
        Me.lblAsunto.Location = New System.Drawing.Point(3, 133)
        Me.lblAsunto.Name = "lblAsunto"
        Me.lblAsunto.Size = New System.Drawing.Size(40, 13)
        Me.lblAsunto.TabIndex = 5
        Me.lblAsunto.Text = "&Asunto"
        '
        'txtAsunto
        '
        Me.txtAsunto.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAsunto.BindearPropiedadControl = Nothing
        Me.txtAsunto.BindearPropiedadEntidad = Nothing
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtAsunto, 2)
        Me.txtAsunto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAsunto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAsunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAsunto.Formato = ""
        Me.txtAsunto.IsDecimal = False
        Me.txtAsunto.IsNumber = False
        Me.txtAsunto.IsPK = False
        Me.txtAsunto.IsRequired = False
        Me.txtAsunto.Key = ""
        Me.txtAsunto.LabelAsoc = Me.lblAsunto
        Me.txtAsunto.Location = New System.Drawing.Point(77, 130)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(604, 20)
        Me.txtAsunto.TabIndex = 6
        '
        'txtCuerpo
        '
        Me.txtCuerpo.BindearPropiedadControl = Nothing
        Me.txtCuerpo.BindearPropiedadEntidad = Nothing
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtCuerpo, 2)
        Me.txtCuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCuerpo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuerpo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuerpo.Formato = ""
        Me.txtCuerpo.IsDecimal = False
        Me.txtCuerpo.IsNumber = False
        Me.txtCuerpo.IsPK = False
        Me.txtCuerpo.IsRequired = False
        Me.txtCuerpo.Key = ""
        Me.txtCuerpo.LabelAsoc = Me.lblCuerpo
        Me.txtCuerpo.Location = New System.Drawing.Point(77, 156)
        Me.txtCuerpo.Multiline = True
        Me.txtCuerpo.Name = "txtCuerpo"
        Me.txtCuerpo.Size = New System.Drawing.Size(604, 215)
        Me.txtCuerpo.TabIndex = 8
        '
        'lblCuerpo
        '
        Me.lblCuerpo.AutoSize = True
        Me.lblCuerpo.LabelAsoc = Nothing
        Me.lblCuerpo.Location = New System.Drawing.Point(3, 153)
        Me.lblCuerpo.Name = "lblCuerpo"
        Me.lblCuerpo.Size = New System.Drawing.Size(41, 13)
        Me.lblCuerpo.TabIndex = 7
        Me.lblCuerpo.Text = "C&uerpo"
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_24
        Me.btnEnviar.Location = New System.Drawing.Point(503, 406)
        Me.btnEnviar.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(161, 30)
        Me.btnEnviar.TabIndex = 9
        Me.btnEnviar.Text = "&Enviar (F9)"
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'lblAdjuntos
        '
        Me.lblAdjuntos.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblAdjuntos, 2)
        Me.lblAdjuntos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAdjuntos.LabelAsoc = Nothing
        Me.lblAdjuntos.Location = New System.Drawing.Point(77, 374)
        Me.lblAdjuntos.Name = "lblAdjuntos"
        Me.lblAdjuntos.Size = New System.Drawing.Size(604, 29)
        Me.lblAdjuntos.TabIndex = 10
        Me.lblAdjuntos.Text = "No tiene archivos adjuntos."
        Me.lblAdjuntos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sstPie
        '
        Me.sstPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto})
        Me.sstPie.Location = New System.Drawing.Point(0, 439)
        Me.sstPie.Name = "sstPie"
        Me.sstPie.Size = New System.Drawing.Size(684, 22)
        Me.sstPie.TabIndex = 1
        Me.sstPie.Text = "StatusStrip1"
        '
        'tslTexto
        '
        Me.tslTexto.Name = "tslTexto"
        Me.tslTexto.Size = New System.Drawing.Size(669, 17)
        Me.tslTexto.Spring = True
        Me.tslTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbCopiaASiMismo
        '
        Me.chbCopiaASiMismo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbCopiaASiMismo.AutoSize = True
        Me.chbCopiaASiMismo.BindearPropiedadControl = Nothing
        Me.chbCopiaASiMismo.BindearPropiedadEntidad = Nothing
        Me.chbCopiaASiMismo.Checked = True
        Me.chbCopiaASiMismo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCopiaASiMismo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCopiaASiMismo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCopiaASiMismo.IsPK = False
        Me.chbCopiaASiMismo.IsRequired = False
        Me.chbCopiaASiMismo.Key = Nothing
        Me.chbCopiaASiMismo.LabelAsoc = Nothing
        Me.chbCopiaASiMismo.Location = New System.Drawing.Point(77, 412)
        Me.chbCopiaASiMismo.Name = "chbCopiaASiMismo"
        Me.chbCopiaASiMismo.Size = New System.Drawing.Size(137, 17)
        Me.chbCopiaASiMismo.TabIndex = 11
        Me.chbCopiaASiMismo.Text = "Enviar Copia a si &mismo"
        Me.chbCopiaASiMismo.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblDestinatarios, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbCopiaASiMismo, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEnviar, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDestinatariosCC, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAdjuntos, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDestinatariosCCO, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAsunto, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCuerpo, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAsunto, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCuerpo, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.grpDestinatarios, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAgenda, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnVerAdjunto, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(684, 439)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblDestinatarios
        '
        Me.lblDestinatarios.AutoSize = True
        Me.lblDestinatarios.LabelAsoc = Nothing
        Me.lblDestinatarios.Location = New System.Drawing.Point(3, 0)
        Me.lblDestinatarios.Name = "lblDestinatarios"
        Me.lblDestinatarios.Size = New System.Drawing.Size(68, 13)
        Me.lblDestinatarios.TabIndex = 0
        Me.lblDestinatarios.Text = "Destinatarios"
        '
        'grpDestinatariosCC
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDestinatariosCC, 2)
        Me.grpDestinatariosCC.Controls.Add(Me.UltraExpandableGroupBoxPanel2)
        Me.grpDestinatariosCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDestinatariosCC.Expanded = False
        Me.grpDestinatariosCC.ExpandedSize = New System.Drawing.Size(604, 67)
        Me.grpDestinatariosCC.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion
        Me.grpDestinatariosCC.Location = New System.Drawing.Point(77, 76)
        Me.grpDestinatariosCC.Name = "grpDestinatariosCC"
        Me.grpDestinatariosCC.Size = New System.Drawing.Size(604, 21)
        Me.grpDestinatariosCC.TabIndex = 3
        Me.grpDestinatariosCC.Text = "&CC"
        '
        'UltraExpandableGroupBoxPanel2
        '
        Me.UltraExpandableGroupBoxPanel2.Controls.Add(Me.txtDestinatariosCC)
        Me.UltraExpandableGroupBoxPanel2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraExpandableGroupBoxPanel2.Name = "UltraExpandableGroupBoxPanel2"
        Me.UltraExpandableGroupBoxPanel2.Size = New System.Drawing.Size(149, 18)
        Me.UltraExpandableGroupBoxPanel2.TabIndex = 0
        Me.UltraExpandableGroupBoxPanel2.Visible = False
        '
        'txtDestinatariosCC
        '
        Me.txtDestinatariosCC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDestinatariosCC.BindearPropiedadControl = Nothing
        Me.txtDestinatariosCC.BindearPropiedadEntidad = Nothing
        Me.txtDestinatariosCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDestinatariosCC.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDestinatariosCC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDestinatariosCC.Formato = ""
        Me.txtDestinatariosCC.IsDecimal = False
        Me.txtDestinatariosCC.IsNumber = False
        Me.txtDestinatariosCC.IsPK = False
        Me.txtDestinatariosCC.IsRequired = False
        Me.txtDestinatariosCC.Key = ""
        Me.txtDestinatariosCC.LabelAsoc = Me.lblDestinatarios
        Me.txtDestinatariosCC.Location = New System.Drawing.Point(0, 0)
        Me.txtDestinatariosCC.Multiline = True
        Me.txtDestinatariosCC.Name = "txtDestinatariosCC"
        Me.txtDestinatariosCC.Size = New System.Drawing.Size(149, 18)
        Me.txtDestinatariosCC.TabIndex = 1
        '
        'grpDestinatariosCCO
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDestinatariosCCO, 2)
        Me.grpDestinatariosCCO.Controls.Add(Me.UltraExpandableGroupBoxPanel3)
        Me.grpDestinatariosCCO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDestinatariosCCO.Expanded = False
        Me.grpDestinatariosCCO.ExpandedSize = New System.Drawing.Size(604, 67)
        Me.grpDestinatariosCCO.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion
        Me.grpDestinatariosCCO.Location = New System.Drawing.Point(77, 103)
        Me.grpDestinatariosCCO.Name = "grpDestinatariosCCO"
        Me.grpDestinatariosCCO.Size = New System.Drawing.Size(604, 21)
        Me.grpDestinatariosCCO.TabIndex = 4
        Me.grpDestinatariosCCO.Text = "CC&O"
        '
        'UltraExpandableGroupBoxPanel3
        '
        Me.UltraExpandableGroupBoxPanel3.Controls.Add(Me.txtDestinatariosCCO)
        Me.UltraExpandableGroupBoxPanel3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraExpandableGroupBoxPanel3.Name = "UltraExpandableGroupBoxPanel3"
        Me.UltraExpandableGroupBoxPanel3.Size = New System.Drawing.Size(149, 18)
        Me.UltraExpandableGroupBoxPanel3.TabIndex = 0
        Me.UltraExpandableGroupBoxPanel3.Visible = False
        '
        'txtDestinatariosCCO
        '
        Me.txtDestinatariosCCO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDestinatariosCCO.BindearPropiedadControl = Nothing
        Me.txtDestinatariosCCO.BindearPropiedadEntidad = Nothing
        Me.txtDestinatariosCCO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDestinatariosCCO.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDestinatariosCCO.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDestinatariosCCO.Formato = ""
        Me.txtDestinatariosCCO.IsDecimal = False
        Me.txtDestinatariosCCO.IsNumber = False
        Me.txtDestinatariosCCO.IsPK = False
        Me.txtDestinatariosCCO.IsRequired = False
        Me.txtDestinatariosCCO.Key = ""
        Me.txtDestinatariosCCO.LabelAsoc = Me.lblDestinatarios
        Me.txtDestinatariosCCO.Location = New System.Drawing.Point(0, 0)
        Me.txtDestinatariosCCO.Multiline = True
        Me.txtDestinatariosCCO.Name = "txtDestinatariosCCO"
        Me.txtDestinatariosCCO.Size = New System.Drawing.Size(149, 18)
        Me.txtDestinatariosCCO.TabIndex = 2
        '
        'grpDestinatarios
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.grpDestinatarios, 2)
        Me.grpDestinatarios.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.grpDestinatarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDestinatarios.ExpandedSize = New System.Drawing.Size(604, 67)
        Me.grpDestinatarios.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.None
        Me.grpDestinatarios.Location = New System.Drawing.Point(77, 3)
        Me.grpDestinatarios.Name = "grpDestinatarios"
        Me.TableLayoutPanel1.SetRowSpan(Me.grpDestinatarios, 2)
        Me.grpDestinatarios.Size = New System.Drawing.Size(604, 67)
        Me.grpDestinatarios.TabIndex = 2
        Me.grpDestinatarios.Text = "&Para"
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.txtDestinatarios)
        Me.UltraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(3, 16)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(598, 48)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        '
        'txtDestinatarios
        '
        Me.txtDestinatarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDestinatarios.BindearPropiedadControl = Nothing
        Me.txtDestinatarios.BindearPropiedadEntidad = Nothing
        Me.txtDestinatarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDestinatarios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDestinatarios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDestinatarios.Formato = ""
        Me.txtDestinatarios.IsDecimal = False
        Me.txtDestinatarios.IsNumber = False
        Me.txtDestinatarios.IsPK = False
        Me.txtDestinatarios.IsRequired = False
        Me.txtDestinatarios.Key = ""
        Me.txtDestinatarios.LabelAsoc = Me.lblDestinatarios
        Me.txtDestinatarios.Location = New System.Drawing.Point(0, 0)
        Me.txtDestinatarios.Multiline = True
        Me.txtDestinatarios.Name = "txtDestinatarios"
        Me.txtDestinatarios.Size = New System.Drawing.Size(598, 48)
        Me.txtDestinatarios.TabIndex = 0
        '
        'btnAgenda
        '
        Me.btnAgenda.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgenda.Location = New System.Drawing.Point(3, 28)
        Me.btnAgenda.Name = "btnAgenda"
        Me.btnAgenda.Size = New System.Drawing.Size(68, 29)
        Me.btnAgenda.TabIndex = 1
        Me.btnAgenda.Text = "A&genda"
        Me.btnAgenda.UseVisualStyleBackColor = True
        '
        'btnVerAdjunto
        '
        Me.btnVerAdjunto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerAdjunto.AutoSize = True
        Me.btnVerAdjunto.Location = New System.Drawing.Point(14, 377)
        Me.btnVerAdjunto.Name = "btnVerAdjunto"
        Me.btnVerAdjunto.Size = New System.Drawing.Size(57, 23)
        Me.btnVerAdjunto.TabIndex = 12
        Me.btnVerAdjunto.Text = "Ver"
        Me.btnVerAdjunto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVerAdjunto.UseVisualStyleBackColor = True
        Me.btnVerAdjunto.Visible = False
        '
        'MensajeMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.sstPie)
        Me.Name = "MensajeMail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envio de Correo Electronico"
        Me.sstPie.ResumeLayout(False)
        Me.sstPie.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.grpDestinatariosCC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDestinatariosCC.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel2.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel2.PerformLayout()
        CType(Me.grpDestinatariosCCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDestinatariosCCO.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel3.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel3.PerformLayout()
        CType(Me.grpDestinatarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDestinatarios.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAsunto As Eniac.Controles.Label
   Friend WithEvents txtAsunto As Eniac.Controles.TextBox
   Friend WithEvents txtCuerpo As Eniac.Controles.TextBox
   Friend WithEvents lblCuerpo As Eniac.Controles.Label
   Friend WithEvents btnEnviar As Eniac.Controles.Button
   Friend WithEvents lblAdjuntos As Eniac.Controles.Label
   Friend WithEvents sstPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbCopiaASiMismo As Eniac.Controles.CheckBox
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents grpDestinatarios As Misc.UltraExpandableGroupBox
   Friend WithEvents UltraExpandableGroupBoxPanel1 As Misc.UltraExpandableGroupBoxPanel
   Friend WithEvents grpDestinatariosCC As Misc.UltraExpandableGroupBox
   Friend WithEvents UltraExpandableGroupBoxPanel2 As Misc.UltraExpandableGroupBoxPanel
   Friend WithEvents grpDestinatariosCCO As Misc.UltraExpandableGroupBox
   Friend WithEvents UltraExpandableGroupBoxPanel3 As Misc.UltraExpandableGroupBoxPanel
   Friend WithEvents lblDestinatarios As Controles.Label
   Friend WithEvents txtDestinatarios As Controles.TextBox
   Friend WithEvents txtDestinatariosCC As Controles.TextBox
   Friend WithEvents txtDestinatariosCCO As Controles.TextBox
   Friend WithEvents btnAgenda As Controles.Button
    Friend WithEvents btnVerAdjunto As Controles.Button
End Class
