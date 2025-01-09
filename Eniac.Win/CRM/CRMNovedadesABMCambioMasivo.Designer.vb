<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRMNovedadesABMCambioMasivo
   Inherits System.Windows.Forms.Form

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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMNovedadesABMCambioMasivo))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.txtCantidadRegistros = New Eniac.Controles.TextBox()
      Me.lblCantidadRegistros = New Eniac.Controles.Label()
      Me.lblTitulo = New Eniac.Controles.Label()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblPrioridad = New Eniac.Controles.Label()
      Me.txtPrioridad = New Eniac.Controles.TextBox()
      Me.lblEtiquetas = New Eniac.Controles.Label()
      Me.lblRequiereTest = New Eniac.Controles.Label()
      Me.lblUsuarioAsignado = New Eniac.Controles.Label()
      Me.lblMedio = New Eniac.Controles.Label()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.txtEtiquetas = New Eniac.Controles.TextBox()
      Me.txtPriorizado = New Eniac.Controles.TextBox()
      Me.txtUsuarioAsignado = New Eniac.Controles.TextBox()
      Me.txtMedio = New Eniac.Controles.TextBox()
      Me.txtEstado = New Eniac.Controles.TextBox()
        Me.lblColor = New Eniac.Controles.Label()
        Me.chbComentario = New Eniac.Controles.CheckBox()
        Me.pnlComentarios = New System.Windows.Forms.Panel()
        Me.lblComentarioPrincipal = New Eniac.Controles.Label()
        Me.cmbComentarioPrincipal = New Eniac.Controles.ComboBox()
        Me.cmbNuevoIdTipoComentarioNovedad = New Eniac.Controles.ComboBox()
        Me.txtComentarios = New Eniac.Controles.TextBox()
        Me.txtNombreAdjunto = New Eniac.Controles.TextBox()
        Me.lblNombreAdjunto = New Eniac.Controles.Label()
        Me.lblCuentaCaracteres = New Eniac.Controles.Label()
        Me.btnExaminar = New Eniac.Controles.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.lblPriorizado = New Eniac.Controles.Label()
        Me.txtRequiereTest = New Eniac.Controles.TextBox()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlComentarios.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(706, 0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(792, 0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 299)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(884, 33)
        Me.Panel1.TabIndex = 2
        '
        'txtCantidadRegistros
        '
        Me.txtCantidadRegistros.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCantidadRegistros.BindearPropiedadControl = Nothing
        Me.txtCantidadRegistros.BindearPropiedadEntidad = Nothing
        Me.txtCantidadRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadRegistros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadRegistros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadRegistros.Formato = "N0"
        Me.txtCantidadRegistros.IsDecimal = False
        Me.txtCantidadRegistros.IsNumber = True
        Me.txtCantidadRegistros.IsPK = False
        Me.txtCantidadRegistros.IsRequired = False
        Me.txtCantidadRegistros.Key = ""
        Me.txtCantidadRegistros.LabelAsoc = Me.lblCantidadRegistros
        Me.txtCantidadRegistros.Location = New System.Drawing.Point(473, 48)
        Me.txtCantidadRegistros.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtCantidadRegistros.MaxLength = 8
        Me.txtCantidadRegistros.Name = "txtCantidadRegistros"
        Me.txtCantidadRegistros.ReadOnly = True
        Me.txtCantidadRegistros.Size = New System.Drawing.Size(59, 23)
        Me.txtCantidadRegistros.TabIndex = 2
        Me.txtCantidadRegistros.Text = "0"
        Me.txtCantidadRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadRegistros
        '
        Me.lblCantidadRegistros.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCantidadRegistros.AutoSize = True
        Me.lblCantidadRegistros.LabelAsoc = Nothing
        Me.lblCantidadRegistros.Location = New System.Drawing.Point(356, 53)
        Me.lblCantidadRegistros.Name = "lblCantidadRegistros"
        Me.lblCantidadRegistros.Size = New System.Drawing.Size(111, 13)
        Me.lblCantidadRegistros.TabIndex = 1
        Me.lblCantidadRegistros.Text = "Cantidad de Registros"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.LabelAsoc = Nothing
        Me.lblTitulo.Location = New System.Drawing.Point(329, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(231, 30)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Por favor confirme que desea cambiar la " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "información detallada"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblPrioridad, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPrioridad, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEtiquetas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRequiereTest, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUsuarioAsignado, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMedio, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEstado, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEtiquetas, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUsuarioAsignado, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMedio, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEstado, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblColor, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtColor, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPriorizado, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPriorizado, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRequiereTest, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 81)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(224, 218)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblPrioridad
        '
        Me.lblPrioridad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPrioridad.AutoSize = True
        Me.lblPrioridad.LabelAsoc = Nothing
        Me.lblPrioridad.Location = New System.Drawing.Point(3, 6)
        Me.lblPrioridad.Name = "lblPrioridad"
        Me.lblPrioridad.Size = New System.Drawing.Size(48, 13)
        Me.lblPrioridad.TabIndex = 0
        Me.lblPrioridad.Text = "Prioridad"
        '
        'txtPrioridad
        '
        Me.txtPrioridad.BindearPropiedadControl = Nothing
        Me.txtPrioridad.BindearPropiedadEntidad = Nothing
        Me.txtPrioridad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrioridad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrioridad.Formato = ""
        Me.txtPrioridad.IsDecimal = False
        Me.txtPrioridad.IsNumber = False
        Me.txtPrioridad.IsPK = False
        Me.txtPrioridad.IsRequired = False
        Me.txtPrioridad.Key = ""
        Me.txtPrioridad.LabelAsoc = Me.lblPrioridad
        Me.txtPrioridad.Location = New System.Drawing.Point(99, 3)
        Me.txtPrioridad.MaxLength = 8
        Me.txtPrioridad.Name = "txtPrioridad"
        Me.txtPrioridad.ReadOnly = True
        Me.txtPrioridad.Size = New System.Drawing.Size(115, 20)
        Me.txtPrioridad.TabIndex = 1
        Me.txtPrioridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEtiquetas
        '
        Me.lblEtiquetas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblEtiquetas.AutoSize = True
        Me.lblEtiquetas.LabelAsoc = Nothing
        Me.lblEtiquetas.Location = New System.Drawing.Point(3, 32)
        Me.lblEtiquetas.Name = "lblEtiquetas"
        Me.lblEtiquetas.Size = New System.Drawing.Size(51, 13)
        Me.lblEtiquetas.TabIndex = 2
        Me.lblEtiquetas.Text = "Etiquetas"
        '
        'lblRequiereTest
        '
        Me.lblRequiereTest.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRequiereTest.AutoSize = True
        Me.lblRequiereTest.LabelAsoc = Nothing
        Me.lblRequiereTest.Location = New System.Drawing.Point(3, 58)
        Me.lblRequiereTest.Name = "lblRequiereTest"
        Me.lblRequiereTest.Size = New System.Drawing.Size(74, 13)
        Me.lblRequiereTest.TabIndex = 4
        Me.lblRequiereTest.Text = "Requiere Test"
        '
        'lblUsuarioAsignado
        '
        Me.lblUsuarioAsignado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUsuarioAsignado.AutoSize = True
        Me.lblUsuarioAsignado.LabelAsoc = Nothing
        Me.lblUsuarioAsignado.Location = New System.Drawing.Point(3, 84)
        Me.lblUsuarioAsignado.Name = "lblUsuarioAsignado"
        Me.lblUsuarioAsignado.Size = New System.Drawing.Size(90, 13)
        Me.lblUsuarioAsignado.TabIndex = 6
        Me.lblUsuarioAsignado.Text = "Usuario Asignado"
        '
        'lblMedio
        '
        Me.lblMedio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMedio.AutoSize = True
        Me.lblMedio.LabelAsoc = Nothing
        Me.lblMedio.Location = New System.Drawing.Point(3, 110)
        Me.lblMedio.Name = "lblMedio"
        Me.lblMedio.Size = New System.Drawing.Size(36, 13)
        Me.lblMedio.TabIndex = 8
        Me.lblMedio.Text = "Medio"
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(3, 136)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Estado"
        '
        'txtEtiquetas
        '
        Me.txtEtiquetas.BindearPropiedadControl = Nothing
        Me.txtEtiquetas.BindearPropiedadEntidad = Nothing
        Me.txtEtiquetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEtiquetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEtiquetas.Formato = ""
        Me.txtEtiquetas.IsDecimal = False
        Me.txtEtiquetas.IsNumber = False
        Me.txtEtiquetas.IsPK = False
        Me.txtEtiquetas.IsRequired = False
        Me.txtEtiquetas.Key = ""
        Me.txtEtiquetas.LabelAsoc = Me.lblEtiquetas
        Me.txtEtiquetas.Location = New System.Drawing.Point(99, 29)
        Me.txtEtiquetas.MaxLength = 8
        Me.txtEtiquetas.Name = "txtEtiquetas"
        Me.txtEtiquetas.ReadOnly = True
        Me.txtEtiquetas.Size = New System.Drawing.Size(115, 20)
        Me.txtEtiquetas.TabIndex = 3
        Me.txtEtiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPriorizado
        '
        Me.txtPriorizado.BindearPropiedadControl = Nothing
        Me.txtPriorizado.BindearPropiedadEntidad = Nothing
        Me.txtPriorizado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPriorizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPriorizado.Formato = ""
        Me.txtPriorizado.IsDecimal = False
        Me.txtPriorizado.IsNumber = False
        Me.txtPriorizado.IsPK = False
        Me.txtPriorizado.IsRequired = False
        Me.txtPriorizado.Key = ""
        Me.txtPriorizado.LabelAsoc = Me.lblPriorizado
        Me.txtPriorizado.Location = New System.Drawing.Point(99, 185)
        Me.txtPriorizado.MaxLength = 8
        Me.txtPriorizado.Name = "txtPriorizado"
        Me.txtPriorizado.ReadOnly = True
        Me.txtPriorizado.Size = New System.Drawing.Size(115, 20)
        Me.txtPriorizado.TabIndex = 5
        Me.txtPriorizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUsuarioAsignado
        '
        Me.txtUsuarioAsignado.BindearPropiedadControl = Nothing
        Me.txtUsuarioAsignado.BindearPropiedadEntidad = Nothing
        Me.txtUsuarioAsignado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUsuarioAsignado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUsuarioAsignado.Formato = ""
        Me.txtUsuarioAsignado.IsDecimal = False
        Me.txtUsuarioAsignado.IsNumber = False
        Me.txtUsuarioAsignado.IsPK = False
        Me.txtUsuarioAsignado.IsRequired = False
        Me.txtUsuarioAsignado.Key = ""
        Me.txtUsuarioAsignado.LabelAsoc = Me.lblUsuarioAsignado
        Me.txtUsuarioAsignado.Location = New System.Drawing.Point(99, 81)
        Me.txtUsuarioAsignado.MaxLength = 8
        Me.txtUsuarioAsignado.Name = "txtUsuarioAsignado"
        Me.txtUsuarioAsignado.ReadOnly = True
        Me.txtUsuarioAsignado.Size = New System.Drawing.Size(115, 20)
        Me.txtUsuarioAsignado.TabIndex = 7
        Me.txtUsuarioAsignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMedio
        '
        Me.txtMedio.BindearPropiedadControl = Nothing
        Me.txtMedio.BindearPropiedadEntidad = Nothing
        Me.txtMedio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMedio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMedio.Formato = ""
        Me.txtMedio.IsDecimal = False
        Me.txtMedio.IsNumber = False
        Me.txtMedio.IsPK = False
        Me.txtMedio.IsRequired = False
        Me.txtMedio.Key = ""
        Me.txtMedio.LabelAsoc = Me.lblMedio
        Me.txtMedio.Location = New System.Drawing.Point(99, 107)
        Me.txtMedio.MaxLength = 8
        Me.txtMedio.Name = "txtMedio"
        Me.txtMedio.ReadOnly = True
        Me.txtMedio.Size = New System.Drawing.Size(115, 20)
        Me.txtMedio.TabIndex = 9
        Me.txtMedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEstado
        '
        Me.txtEstado.BindearPropiedadControl = Nothing
        Me.txtEstado.BindearPropiedadEntidad = Nothing
        Me.txtEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstado.Formato = ""
        Me.txtEstado.IsDecimal = False
        Me.txtEstado.IsNumber = False
        Me.txtEstado.IsPK = False
        Me.txtEstado.IsRequired = False
        Me.txtEstado.Key = ""
        Me.txtEstado.LabelAsoc = Me.lblEstado
        Me.txtEstado.Location = New System.Drawing.Point(99, 133)
        Me.txtEstado.MaxLength = 8
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(115, 20)
        Me.txtEstado.TabIndex = 11
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblColor
        '
        Me.lblColor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblColor.AutoSize = True
        Me.lblColor.LabelAsoc = Nothing
        Me.lblColor.Location = New System.Drawing.Point(3, 162)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 10
        Me.lblColor.Text = "Color"
        '
        'chbComentario
        '
        Me.chbComentario.AutoSize = True
        Me.chbComentario.BindearPropiedadControl = Nothing
        Me.chbComentario.BindearPropiedadEntidad = Nothing
        Me.chbComentario.Checked = True
        Me.chbComentario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbComentario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComentario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComentario.IsPK = False
        Me.chbComentario.IsRequired = False
        Me.chbComentario.Key = Nothing
        Me.chbComentario.LabelAsoc = Nothing
        Me.chbComentario.Location = New System.Drawing.Point(3, 3)
        Me.chbComentario.Name = "chbComentario"
        Me.chbComentario.Size = New System.Drawing.Size(79, 17)
        Me.chbComentario.TabIndex = 12
        Me.chbComentario.Text = "Comentario"
        '
        'pnlComentarios
        '
        Me.pnlComentarios.Controls.Add(Me.lblComentarioPrincipal)
        Me.pnlComentarios.Controls.Add(Me.cmbComentarioPrincipal)
        Me.pnlComentarios.Controls.Add(Me.cmbNuevoIdTipoComentarioNovedad)
        Me.pnlComentarios.Controls.Add(Me.txtComentarios)
        Me.pnlComentarios.Controls.Add(Me.txtNombreAdjunto)
        Me.pnlComentarios.Controls.Add(Me.lblNombreAdjunto)
        Me.pnlComentarios.Controls.Add(Me.lblCuentaCaracteres)
        Me.pnlComentarios.Controls.Add(Me.btnExaminar)
        Me.pnlComentarios.Location = New System.Drawing.Point(3, 23)
        Me.pnlComentarios.Name = "pnlComentarios"
        Me.pnlComentarios.Size = New System.Drawing.Size(654, 124)
        Me.pnlComentarios.TabIndex = 13
        '
        'lblComentarioPrincipal
        '
        Me.lblComentarioPrincipal.AutoSize = True
        Me.lblComentarioPrincipal.LabelAsoc = Nothing
        Me.lblComentarioPrincipal.Location = New System.Drawing.Point(547, 78)
        Me.lblComentarioPrincipal.Name = "lblComentarioPrincipal"
        Me.lblComentarioPrincipal.Size = New System.Drawing.Size(102, 13)
        Me.lblComentarioPrincipal.TabIndex = 99
        Me.lblComentarioPrincipal.Text = "Comentario principal"
        '
        'cmbComentarioPrincipal
        '
        Me.cmbComentarioPrincipal.BindearPropiedadControl = "SelectedValue"
        Me.cmbComentarioPrincipal.BindearPropiedadEntidad = "ComentarioPrincipal"
        Me.cmbComentarioPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComentarioPrincipal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbComentarioPrincipal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbComentarioPrincipal.FormattingEnabled = True
        Me.cmbComentarioPrincipal.IsPK = False
        Me.cmbComentarioPrincipal.IsRequired = True
        Me.cmbComentarioPrincipal.Key = Nothing
        Me.cmbComentarioPrincipal.LabelAsoc = Me.lblComentarioPrincipal
        Me.cmbComentarioPrincipal.Location = New System.Drawing.Point(547, 91)
        Me.cmbComentarioPrincipal.Name = "cmbComentarioPrincipal"
        Me.cmbComentarioPrincipal.Size = New System.Drawing.Size(100, 21)
        Me.cmbComentarioPrincipal.TabIndex = 100
        '
        'cmbNuevoIdTipoComentarioNovedad
        '
        Me.cmbNuevoIdTipoComentarioNovedad.BindearPropiedadControl = "SelectedValue"
        Me.cmbNuevoIdTipoComentarioNovedad.BindearPropiedadEntidad = "NuevoIdTipoComentarioNovedad"
        Me.cmbNuevoIdTipoComentarioNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNuevoIdTipoComentarioNovedad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNuevoIdTipoComentarioNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNuevoIdTipoComentarioNovedad.FormattingEnabled = True
        Me.cmbNuevoIdTipoComentarioNovedad.IsPK = False
        Me.cmbNuevoIdTipoComentarioNovedad.IsRequired = False
        Me.cmbNuevoIdTipoComentarioNovedad.Key = Nothing
        Me.cmbNuevoIdTipoComentarioNovedad.LabelAsoc = Nothing
        Me.cmbNuevoIdTipoComentarioNovedad.Location = New System.Drawing.Point(1, 93)
        Me.cmbNuevoIdTipoComentarioNovedad.Name = "cmbNuevoIdTipoComentarioNovedad"
        Me.cmbNuevoIdTipoComentarioNovedad.Size = New System.Drawing.Size(121, 21)
        Me.cmbNuevoIdTipoComentarioNovedad.TabIndex = 98
        '
        'txtComentarios
        '
        Me.txtComentarios.BindearPropiedadControl = "Text"
        Me.txtComentarios.BindearPropiedadEntidad = "NuevoComentario"
        Me.txtComentarios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComentarios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComentarios.Formato = ""
        Me.txtComentarios.IsDecimal = False
        Me.txtComentarios.IsNumber = False
        Me.txtComentarios.IsPK = False
        Me.txtComentarios.IsRequired = False
        Me.txtComentarios.Key = ""
        Me.txtComentarios.LabelAsoc = Nothing
        Me.txtComentarios.Location = New System.Drawing.Point(3, 3)
        Me.txtComentarios.MaxLength = 2000
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentarios.Size = New System.Drawing.Size(644, 75)
        Me.txtComentarios.TabIndex = 96
        '
        'txtNombreAdjunto
        '
        Me.txtNombreAdjunto.BindearPropiedadControl = "Text"
        Me.txtNombreAdjunto.BindearPropiedadEntidad = "NuevoAdjunto"
        Me.txtNombreAdjunto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreAdjunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreAdjunto.Formato = ""
        Me.txtNombreAdjunto.IsDecimal = False
        Me.txtNombreAdjunto.IsNumber = False
        Me.txtNombreAdjunto.IsPK = False
        Me.txtNombreAdjunto.IsRequired = False
        Me.txtNombreAdjunto.Key = ""
        Me.txtNombreAdjunto.LabelAsoc = Me.lblNombreAdjunto
        Me.txtNombreAdjunto.Location = New System.Drawing.Point(177, 92)
        Me.txtNombreAdjunto.MaxLength = 200
        Me.txtNombreAdjunto.Name = "txtNombreAdjunto"
        Me.txtNombreAdjunto.Size = New System.Drawing.Size(288, 20)
        Me.txtNombreAdjunto.TabIndex = 94
        '
        'lblNombreAdjunto
        '
        Me.lblNombreAdjunto.AutoSize = True
        Me.lblNombreAdjunto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreAdjunto.LabelAsoc = Nothing
        Me.lblNombreAdjunto.Location = New System.Drawing.Point(128, 98)
        Me.lblNombreAdjunto.Name = "lblNombreAdjunto"
        Me.lblNombreAdjunto.Size = New System.Drawing.Size(43, 13)
        Me.lblNombreAdjunto.TabIndex = 93
        Me.lblNombreAdjunto.Text = "Adjunto"
        '
        'lblCuentaCaracteres
        '
        Me.lblCuentaCaracteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCuentaCaracteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentaCaracteres.LabelAsoc = Nothing
        Me.lblCuentaCaracteres.Location = New System.Drawing.Point(0, 77)
        Me.lblCuentaCaracteres.Name = "lblCuentaCaracteres"
        Me.lblCuentaCaracteres.Size = New System.Drawing.Size(72, 14)
        Me.lblCuentaCaracteres.TabIndex = 95
        Me.lblCuentaCaracteres.Text = "{0} / 2000"
        Me.lblCuentaCaracteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(471, 92)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar.TabIndex = 97
        Me.btnExaminar.Text = "Exam..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.txtCantidadRegistros)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Controls.Add(Me.lblCantidadRegistros)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(884, 81)
        Me.Panel2.TabIndex = 0
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.chbComentario)
        Me.Panel3.Controls.Add(Me.pnlComentarios)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(224, 81)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(660, 218)
        Me.Panel3.TabIndex = 3
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = Nothing
        Me.txtColor.BindearPropiedadEntidad = Nothing
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.lblColor
        Me.txtColor.Location = New System.Drawing.Point(99, 159)
        Me.txtColor.MaxLength = 8
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(115, 20)
        Me.txtColor.TabIndex = 11
        Me.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPriorizado
        '
        Me.lblPriorizado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPriorizado.AutoSize = True
        Me.lblPriorizado.LabelAsoc = Nothing
        Me.lblPriorizado.Location = New System.Drawing.Point(3, 188)
        Me.lblPriorizado.Name = "lblPriorizado"
        Me.lblPriorizado.Size = New System.Drawing.Size(53, 13)
        Me.lblPriorizado.TabIndex = 4
        Me.lblPriorizado.Text = "Priorizado"
        '
        'txtRequiereTest
        '
        Me.txtRequiereTest.BindearPropiedadControl = Nothing
        Me.txtRequiereTest.BindearPropiedadEntidad = Nothing
        Me.txtRequiereTest.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRequiereTest.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRequiereTest.Formato = ""
        Me.txtRequiereTest.IsDecimal = False
        Me.txtRequiereTest.IsNumber = False
        Me.txtRequiereTest.IsPK = False
        Me.txtRequiereTest.IsRequired = False
        Me.txtRequiereTest.Key = ""
        Me.txtRequiereTest.LabelAsoc = Me.lblRequiereTest
        Me.txtRequiereTest.Location = New System.Drawing.Point(99, 55)
        Me.txtRequiereTest.MaxLength = 8
        Me.txtRequiereTest.Name = "txtRequiereTest"
        Me.txtRequiereTest.ReadOnly = True
        Me.txtRequiereTest.Size = New System.Drawing.Size(115, 20)
        Me.txtRequiereTest.TabIndex = 5
        Me.txtRequiereTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CRMNovedadesABMCambioMasivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(884, 332)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CRMNovedadesABMCambioMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmación de cambio masivo"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlComentarios.ResumeLayout(False)
        Me.pnlComentarios.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents Panel1 As Panel
   Friend WithEvents txtCantidadRegistros As Controles.TextBox
   Friend WithEvents lblCantidadRegistros As Controles.Label
   Friend WithEvents lblTitulo As Controles.Label
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents lblPrioridad As Controles.Label
   Friend WithEvents lblEtiquetas As Controles.Label
   Friend WithEvents lblRequiereTest As Controles.Label
   Friend WithEvents lblUsuarioAsignado As Controles.Label
   Friend WithEvents lblMedio As Controles.Label
   Friend WithEvents lblEstado As Controles.Label
   Friend WithEvents txtPrioridad As Controles.TextBox
   Friend WithEvents txtEtiquetas As Controles.TextBox
   Friend WithEvents txtPriorizado As Controles.TextBox
   Friend WithEvents txtUsuarioAsignado As Controles.TextBox
   Friend WithEvents txtMedio As Controles.TextBox
   Friend WithEvents txtEstado As Controles.TextBox
   Friend WithEvents Panel2 As Panel
   Friend WithEvents chbComentario As Controles.CheckBox
   Friend WithEvents pnlComentarios As Panel
   Friend WithEvents lblComentarioPrincipal As Controles.Label
   Friend WithEvents cmbComentarioPrincipal As Controles.ComboBox
   Friend WithEvents cmbNuevoIdTipoComentarioNovedad As Controles.ComboBox
   Friend WithEvents txtComentarios As Controles.TextBox
   Friend WithEvents txtNombreAdjunto As Controles.TextBox
   Friend WithEvents lblNombreAdjunto As Controles.Label
   Friend WithEvents lblCuentaCaracteres As Controles.Label
   Friend WithEvents btnExaminar As Controles.Button
   Friend WithEvents DialogoAbrirArchivo As OpenFileDialog
   Friend WithEvents Panel3 As Panel
    Friend WithEvents lblColor As Controles.Label
    Friend WithEvents txtColor As Controles.TextBox
    Friend WithEvents lblPriorizado As Controles.Label
    Friend WithEvents txtRequiereTest As Controles.TextBox
End Class
