<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccesoRelojes
   Inherits System.Windows.Forms.Form

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
      Me.txtBaseFinal = New System.Windows.Forms.TextBox()
      Me.lblBaseFinal = New System.Windows.Forms.Label()
      Me.txtClave = New System.Windows.Forms.TextBox()
      Me.lblClave = New System.Windows.Forms.Label()
      Me.txtUsuario = New System.Windows.Forms.TextBox()
      Me.lblUsuario = New System.Windows.Forms.Label()
      Me.txtServidor = New System.Windows.Forms.TextBox()
      Me.lblServidor = New System.Windows.Forms.Label()
      Me.btnCargarInfo = New System.Windows.Forms.Button()
      Me.btnMigrarDatos = New System.Windows.Forms.Button()
      Me.txtCarpeta = New System.Windows.Forms.TextBox()
      Me.pgb = New System.Windows.Forms.ProgressBar()
      Me.tbcPrincipal = New System.Windows.Forms.TabControl()
      Me.tbpFichadas = New System.Windows.Forms.TabPage()
      Me.stsEstadoRubros = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssFichadas = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvFichadas = New System.Windows.Forms.DataGridView()
      Me.tbpLegajos = New System.Windows.Forms.TabPage()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar2 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssLegajos = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvLegajos = New System.Windows.Forms.DataGridView()
      Me.tbpSectores = New System.Windows.Forms.TabPage()
      Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar3 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssSectores = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvSectores = New System.Windows.Forms.DataGridView()
      Me.tbpCategorias = New System.Windows.Forms.TabPage()
      Me.StatusStrip3 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar4 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssCategorias = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvCategorias = New System.Windows.Forms.DataGridView()
      Me.tbpNodos = New System.Windows.Forms.TabPage()
      Me.StatusStrip4 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar5 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssNodos = New System.Windows.Forms.ToolStripStatusLabel()
      Me.dgvNodos = New System.Windows.Forms.DataGridView()
      Me.fbdCarpeta = New System.Windows.Forms.FolderBrowserDialog()
      Me.txtContraseña = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.btnBuscarBase = New System.Windows.Forms.Button()
      Me.txtTablasMigradas = New System.Windows.Forms.Label()
      Me.tbcPrincipal.SuspendLayout()
      Me.tbpFichadas.SuspendLayout()
      Me.stsEstadoRubros.SuspendLayout()
      CType(Me.dgvFichadas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpLegajos.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      CType(Me.dgvLegajos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpSectores.SuspendLayout()
      Me.StatusStrip2.SuspendLayout()
      CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpCategorias.SuspendLayout()
      Me.StatusStrip3.SuspendLayout()
      CType(Me.dgvCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpNodos.SuspendLayout()
      Me.StatusStrip4.SuspendLayout()
      CType(Me.dgvNodos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtBaseFinal
      '
      Me.txtBaseFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBaseFinal.Location = New System.Drawing.Point(434, 114)
      Me.txtBaseFinal.Name = "txtBaseFinal"
      Me.txtBaseFinal.Size = New System.Drawing.Size(191, 22)
      Me.txtBaseFinal.TabIndex = 47
      Me.txtBaseFinal.Text = "SIGA"
      '
      'lblBaseFinal
      '
      Me.lblBaseFinal.BackColor = System.Drawing.SystemColors.Control
      Me.lblBaseFinal.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblBaseFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblBaseFinal.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBaseFinal.Location = New System.Drawing.Point(333, 117)
      Me.lblBaseFinal.Name = "lblBaseFinal"
      Me.lblBaseFinal.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblBaseFinal.Size = New System.Drawing.Size(100, 19)
      Me.lblBaseFinal.TabIndex = 46
      Me.lblBaseFinal.Text = "Base Destino :"
      '
      'txtClave
      '
      Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtClave.Location = New System.Drawing.Point(234, 113)
      Me.txtClave.Name = "txtClave"
      Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtClave.Size = New System.Drawing.Size(95, 22)
      Me.txtClave.TabIndex = 45
      Me.txtClave.TabStop = False
      Me.txtClave.Text = "Eniac2010"
      '
      'lblClave
      '
      Me.lblClave.BackColor = System.Drawing.SystemColors.Control
      Me.lblClave.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblClave.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblClave.Location = New System.Drawing.Point(179, 115)
      Me.lblClave.Name = "lblClave"
      Me.lblClave.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblClave.Size = New System.Drawing.Size(50, 19)
      Me.lblClave.TabIndex = 44
      Me.lblClave.Text = "Clave :"
      '
      'txtUsuario
      '
      Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtUsuario.Location = New System.Drawing.Point(124, 113)
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.Size = New System.Drawing.Size(46, 22)
      Me.txtUsuario.TabIndex = 43
      Me.txtUsuario.TabStop = False
      Me.txtUsuario.Text = "Eniac"
      '
      'lblUsuario
      '
      Me.lblUsuario.BackColor = System.Drawing.SystemColors.Control
      Me.lblUsuario.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblUsuario.Location = New System.Drawing.Point(47, 115)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblUsuario.Size = New System.Drawing.Size(65, 19)
      Me.lblUsuario.TabIndex = 42
      Me.lblUsuario.Text = "Usuario :"
      '
      'txtServidor
      '
      Me.txtServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtServidor.Location = New System.Drawing.Point(124, 86)
      Me.txtServidor.Name = "txtServidor"
      Me.txtServidor.Size = New System.Drawing.Size(205, 22)
      Me.txtServidor.TabIndex = 41
      Me.txtServidor.TabStop = False
      Me.txtServidor.Text = ".\SQLEXPRESS"
      '
      'lblServidor
      '
      Me.lblServidor.BackColor = System.Drawing.SystemColors.Control
      Me.lblServidor.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblServidor.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblServidor.Location = New System.Drawing.Point(45, 88)
      Me.lblServidor.Name = "lblServidor"
      Me.lblServidor.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblServidor.Size = New System.Drawing.Size(66, 19)
      Me.lblServidor.TabIndex = 40
      Me.lblServidor.Text = "Servidor :"
      '
      'btnCargarInfo
      '
      Me.btnCargarInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCargarInfo.Image = Global.Eniac.Win.My.Resources.Resources.play_24
      Me.btnCargarInfo.Location = New System.Drawing.Point(630, 12)
      Me.btnCargarInfo.Name = "btnCargarInfo"
      Me.btnCargarInfo.Size = New System.Drawing.Size(111, 54)
      Me.btnCargarInfo.TabIndex = 39
      Me.btnCargarInfo.Text = "Cargar Información"
      Me.btnCargarInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnCargarInfo.UseVisualStyleBackColor = True
      '
      'btnMigrarDatos
      '
      Me.btnMigrarDatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnMigrarDatos.Enabled = False
      Me.btnMigrarDatos.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
      Me.btnMigrarDatos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.btnMigrarDatos.Location = New System.Drawing.Point(43, 396)
      Me.btnMigrarDatos.Name = "btnMigrarDatos"
      Me.btnMigrarDatos.Size = New System.Drawing.Size(97, 56)
      Me.btnMigrarDatos.TabIndex = 35
      Me.btnMigrarDatos.Text = "Migrar datos"
      Me.btnMigrarDatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnMigrarDatos.UseVisualStyleBackColor = True
      '
      'txtCarpeta
      '
      Me.txtCarpeta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCarpeta.Location = New System.Drawing.Point(230, 14)
      Me.txtCarpeta.Name = "txtCarpeta"
      Me.txtCarpeta.Size = New System.Drawing.Size(384, 20)
      Me.txtCarpeta.TabIndex = 38
      '
      'pgb
      '
      Me.pgb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pgb.Location = New System.Drawing.Point(142, 428)
      Me.pgb.Name = "pgb"
      Me.pgb.Size = New System.Drawing.Size(615, 23)
      Me.pgb.TabIndex = 37
      '
      'tbcPrincipal
      '
      Me.tbcPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcPrincipal.Controls.Add(Me.tbpFichadas)
      Me.tbcPrincipal.Controls.Add(Me.tbpLegajos)
      Me.tbcPrincipal.Controls.Add(Me.tbpSectores)
      Me.tbcPrincipal.Controls.Add(Me.tbpCategorias)
      Me.tbcPrincipal.Controls.Add(Me.tbpNodos)
      Me.tbcPrincipal.Location = New System.Drawing.Point(46, 137)
      Me.tbcPrincipal.Name = "tbcPrincipal"
      Me.tbcPrincipal.SelectedIndex = 0
      Me.tbcPrincipal.Size = New System.Drawing.Size(718, 253)
      Me.tbcPrincipal.TabIndex = 36
      '
      'tbpFichadas
      '
      Me.tbpFichadas.Controls.Add(Me.stsEstadoRubros)
      Me.tbpFichadas.Controls.Add(Me.dgvFichadas)
      Me.tbpFichadas.Location = New System.Drawing.Point(4, 22)
      Me.tbpFichadas.Name = "tbpFichadas"
      Me.tbpFichadas.Size = New System.Drawing.Size(710, 227)
      Me.tbpFichadas.TabIndex = 8
      Me.tbpFichadas.Text = "Fichadas"
      Me.tbpFichadas.UseVisualStyleBackColor = True
      '
      'stsEstadoRubros
      '
      Me.stsEstadoRubros.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1, Me.tssFichadas})
      Me.stsEstadoRubros.Location = New System.Drawing.Point(0, 205)
      Me.stsEstadoRubros.Name = "stsEstadoRubros"
      Me.stsEstadoRubros.Size = New System.Drawing.Size(710, 22)
      Me.stsEstadoRubros.TabIndex = 10
      '
      'ToolStripStatusLabel2
      '
      Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
      Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(631, 17)
      Me.ToolStripStatusLabel2.Spring = True
      '
      'ToolStripProgressBar1
      '
      Me.ToolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
      Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 24)
      Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar1.Visible = False
      '
      'tssFichadas
      '
      Me.tssFichadas.Name = "tssFichadas"
      Me.tssFichadas.Size = New System.Drawing.Size(64, 17)
      Me.tssFichadas.Text = "0 Registros"
      '
      'dgvFichadas
      '
      Me.dgvFichadas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvFichadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvFichadas.Location = New System.Drawing.Point(0, 0)
      Me.dgvFichadas.Name = "dgvFichadas"
      Me.dgvFichadas.ReadOnly = True
      Me.dgvFichadas.Size = New System.Drawing.Size(710, 202)
      Me.dgvFichadas.TabIndex = 4
      '
      'tbpLegajos
      '
      Me.tbpLegajos.Controls.Add(Me.StatusStrip1)
      Me.tbpLegajos.Controls.Add(Me.dgvLegajos)
      Me.tbpLegajos.Location = New System.Drawing.Point(4, 22)
      Me.tbpLegajos.Name = "tbpLegajos"
      Me.tbpLegajos.Size = New System.Drawing.Size(710, 227)
      Me.tbpLegajos.TabIndex = 9
      Me.tbpLegajos.Text = "Legajos"
      Me.tbpLegajos.UseVisualStyleBackColor = True
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar2, Me.tssLegajos})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 205)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(710, 22)
      Me.StatusStrip1.TabIndex = 11
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(631, 17)
      Me.ToolStripStatusLabel1.Spring = True
      '
      'ToolStripProgressBar2
      '
      Me.ToolStripProgressBar2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripProgressBar2.Name = "ToolStripProgressBar2"
      Me.ToolStripProgressBar2.Size = New System.Drawing.Size(100, 24)
      Me.ToolStripProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar2.Visible = False
      '
      'tssLegajos
      '
      Me.tssLegajos.Name = "tssLegajos"
      Me.tssLegajos.Size = New System.Drawing.Size(64, 17)
      Me.tssLegajos.Text = "0 Registros"
      '
      'dgvLegajos
      '
      Me.dgvLegajos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvLegajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvLegajos.Location = New System.Drawing.Point(0, 0)
      Me.dgvLegajos.Name = "dgvLegajos"
      Me.dgvLegajos.ReadOnly = True
      Me.dgvLegajos.Size = New System.Drawing.Size(710, 202)
      Me.dgvLegajos.TabIndex = 5
      '
      'tbpSectores
      '
      Me.tbpSectores.Controls.Add(Me.StatusStrip2)
      Me.tbpSectores.Controls.Add(Me.dgvSectores)
      Me.tbpSectores.Location = New System.Drawing.Point(4, 22)
      Me.tbpSectores.Name = "tbpSectores"
      Me.tbpSectores.Size = New System.Drawing.Size(710, 227)
      Me.tbpSectores.TabIndex = 10
      Me.tbpSectores.Text = "Sectores"
      Me.tbpSectores.UseVisualStyleBackColor = True
      '
      'StatusStrip2
      '
      Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripProgressBar3, Me.tssSectores})
      Me.StatusStrip2.Location = New System.Drawing.Point(0, 205)
      Me.StatusStrip2.Name = "StatusStrip2"
      Me.StatusStrip2.Size = New System.Drawing.Size(710, 22)
      Me.StatusStrip2.TabIndex = 13
      '
      'ToolStripStatusLabel3
      '
      Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
      Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(631, 17)
      Me.ToolStripStatusLabel3.Spring = True
      '
      'ToolStripProgressBar3
      '
      Me.ToolStripProgressBar3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripProgressBar3.Name = "ToolStripProgressBar3"
      Me.ToolStripProgressBar3.Size = New System.Drawing.Size(100, 24)
      Me.ToolStripProgressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar3.Visible = False
      '
      'tssSectores
      '
      Me.tssSectores.Name = "tssSectores"
      Me.tssSectores.Size = New System.Drawing.Size(64, 17)
      Me.tssSectores.Text = "0 Registros"
      '
      'dgvSectores
      '
      Me.dgvSectores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvSectores.Location = New System.Drawing.Point(0, 0)
      Me.dgvSectores.Name = "dgvSectores"
      Me.dgvSectores.ReadOnly = True
      Me.dgvSectores.Size = New System.Drawing.Size(710, 202)
      Me.dgvSectores.TabIndex = 12
      '
      'tbpCategorias
      '
      Me.tbpCategorias.Controls.Add(Me.StatusStrip3)
      Me.tbpCategorias.Controls.Add(Me.dgvCategorias)
      Me.tbpCategorias.Location = New System.Drawing.Point(4, 22)
      Me.tbpCategorias.Name = "tbpCategorias"
      Me.tbpCategorias.Size = New System.Drawing.Size(710, 227)
      Me.tbpCategorias.TabIndex = 11
      Me.tbpCategorias.Text = "Categorias"
      Me.tbpCategorias.UseVisualStyleBackColor = True
      '
      'StatusStrip3
      '
      Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel5, Me.ToolStripProgressBar4, Me.tssCategorias})
      Me.StatusStrip3.Location = New System.Drawing.Point(0, 205)
      Me.StatusStrip3.Name = "StatusStrip3"
      Me.StatusStrip3.Size = New System.Drawing.Size(710, 22)
      Me.StatusStrip3.TabIndex = 13
      '
      'ToolStripStatusLabel5
      '
      Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
      Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(631, 17)
      Me.ToolStripStatusLabel5.Spring = True
      '
      'ToolStripProgressBar4
      '
      Me.ToolStripProgressBar4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripProgressBar4.Name = "ToolStripProgressBar4"
      Me.ToolStripProgressBar4.Size = New System.Drawing.Size(100, 24)
      Me.ToolStripProgressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar4.Visible = False
      '
      'tssCategorias
      '
      Me.tssCategorias.Name = "tssCategorias"
      Me.tssCategorias.Size = New System.Drawing.Size(64, 17)
      Me.tssCategorias.Text = "0 Registros"
      '
      'dgvCategorias
      '
      Me.dgvCategorias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvCategorias.Location = New System.Drawing.Point(0, 0)
      Me.dgvCategorias.Name = "dgvCategorias"
      Me.dgvCategorias.ReadOnly = True
      Me.dgvCategorias.Size = New System.Drawing.Size(710, 202)
      Me.dgvCategorias.TabIndex = 12
      '
      'tbpNodos
      '
      Me.tbpNodos.Controls.Add(Me.StatusStrip4)
      Me.tbpNodos.Controls.Add(Me.dgvNodos)
      Me.tbpNodos.Location = New System.Drawing.Point(4, 22)
      Me.tbpNodos.Name = "tbpNodos"
      Me.tbpNodos.Size = New System.Drawing.Size(710, 227)
      Me.tbpNodos.TabIndex = 12
      Me.tbpNodos.Text = "Nodos"
      Me.tbpNodos.UseVisualStyleBackColor = True
      '
      'StatusStrip4
      '
      Me.StatusStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel7, Me.ToolStripProgressBar5, Me.tssNodos})
      Me.StatusStrip4.Location = New System.Drawing.Point(0, 205)
      Me.StatusStrip4.Name = "StatusStrip4"
      Me.StatusStrip4.Size = New System.Drawing.Size(710, 22)
      Me.StatusStrip4.TabIndex = 13
      '
      'ToolStripStatusLabel7
      '
      Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
      Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(631, 17)
      Me.ToolStripStatusLabel7.Spring = True
      '
      'ToolStripProgressBar5
      '
      Me.ToolStripProgressBar5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.ToolStripProgressBar5.Name = "ToolStripProgressBar5"
      Me.ToolStripProgressBar5.Size = New System.Drawing.Size(100, 24)
      Me.ToolStripProgressBar5.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar5.Visible = False
      '
      'tssNodos
      '
      Me.tssNodos.Name = "tssNodos"
      Me.tssNodos.Size = New System.Drawing.Size(64, 17)
      Me.tssNodos.Text = "0 Registros"
      '
      'dgvNodos
      '
      Me.dgvNodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvNodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvNodos.Location = New System.Drawing.Point(0, 0)
      Me.dgvNodos.Name = "dgvNodos"
      Me.dgvNodos.ReadOnly = True
      Me.dgvNodos.Size = New System.Drawing.Size(710, 202)
      Me.dgvNodos.TabIndex = 12
      '
      'txtContraseña
      '
      Me.txtContraseña.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtContraseña.Location = New System.Drawing.Point(230, 45)
      Me.txtContraseña.Name = "txtContraseña"
      Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtContraseña.Size = New System.Drawing.Size(384, 20)
      Me.txtContraseña.TabIndex = 48
      Me.txtContraseña.Text = "firtdkw2k"
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.SystemColors.Control
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label1.Location = New System.Drawing.Point(145, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(66, 19)
      Me.Label1.TabIndex = 49
      Me.Label1.Text = "Carpeta"
      '
      'Label2
      '
      Me.Label2.BackColor = System.Drawing.SystemColors.Control
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label2.Location = New System.Drawing.Point(146, 45)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(78, 19)
      Me.Label2.TabIndex = 50
      Me.Label2.Text = "Contraseña"
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.FileName = "OpenFileDialog1"
      '
      'btnBuscarBase
      '
      Me.btnBuscarBase.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnBuscarBase.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.btnBuscarBase.Location = New System.Drawing.Point(28, 8)
      Me.btnBuscarBase.Name = "btnBuscarBase"
      Me.btnBuscarBase.Size = New System.Drawing.Size(111, 65)
      Me.btnBuscarBase.TabIndex = 51
      Me.btnBuscarBase.Text = "Buscar Base de Datos"
      Me.btnBuscarBase.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.btnBuscarBase.UseVisualStyleBackColor = True
      '
      'txtTablasMigradas
      '
      Me.txtTablasMigradas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtTablasMigradas.BackColor = System.Drawing.SystemColors.Control
      Me.txtTablasMigradas.Cursor = System.Windows.Forms.Cursors.Default
      Me.txtTablasMigradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTablasMigradas.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtTablasMigradas.Location = New System.Drawing.Point(141, 406)
      Me.txtTablasMigradas.Name = "txtTablasMigradas"
      Me.txtTablasMigradas.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTablasMigradas.Size = New System.Drawing.Size(100, 19)
      Me.txtTablasMigradas.TabIndex = 52
      '
      'AccesoRelojes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(812, 461)
      Me.Controls.Add(Me.txtTablasMigradas)
      Me.Controls.Add(Me.btnBuscarBase)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtContraseña)
      Me.Controls.Add(Me.txtBaseFinal)
      Me.Controls.Add(Me.lblBaseFinal)
      Me.Controls.Add(Me.txtClave)
      Me.Controls.Add(Me.lblClave)
      Me.Controls.Add(Me.txtUsuario)
      Me.Controls.Add(Me.lblUsuario)
      Me.Controls.Add(Me.txtServidor)
      Me.Controls.Add(Me.lblServidor)
      Me.Controls.Add(Me.btnCargarInfo)
      Me.Controls.Add(Me.btnMigrarDatos)
      Me.Controls.Add(Me.txtCarpeta)
      Me.Controls.Add(Me.pgb)
      Me.Controls.Add(Me.tbcPrincipal)
      Me.Name = "AccesoRelojes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "AccesoRelojes"
      Me.tbcPrincipal.ResumeLayout(False)
      Me.tbpFichadas.ResumeLayout(False)
      Me.tbpFichadas.PerformLayout()
      Me.stsEstadoRubros.ResumeLayout(False)
      Me.stsEstadoRubros.PerformLayout()
      CType(Me.dgvFichadas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpLegajos.ResumeLayout(False)
      Me.tbpLegajos.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      CType(Me.dgvLegajos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpSectores.ResumeLayout(False)
      Me.tbpSectores.PerformLayout()
      Me.StatusStrip2.ResumeLayout(False)
      Me.StatusStrip2.PerformLayout()
      CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpCategorias.ResumeLayout(False)
      Me.tbpCategorias.PerformLayout()
      Me.StatusStrip3.ResumeLayout(False)
      Me.StatusStrip3.PerformLayout()
      CType(Me.dgvCategorias, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpNodos.ResumeLayout(False)
      Me.tbpNodos.PerformLayout()
      Me.StatusStrip4.ResumeLayout(False)
      Me.StatusStrip4.PerformLayout()
      CType(Me.dgvNodos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtBaseFinal As TextBox
   Public WithEvents lblBaseFinal As Label
   Friend WithEvents txtClave As TextBox
   Public WithEvents lblClave As Label
   Friend WithEvents txtUsuario As TextBox
   Public WithEvents lblUsuario As Label
   Friend WithEvents txtServidor As TextBox
   Public WithEvents lblServidor As Label
   Friend WithEvents btnCargarInfo As Button
   Friend WithEvents btnMigrarDatos As Button
   Friend WithEvents txtCarpeta As TextBox
   Friend WithEvents pgb As ProgressBar
   Friend WithEvents tbcPrincipal As TabControl
   Friend WithEvents tbpFichadas As TabPage
   Protected Friend WithEvents stsEstadoRubros As StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
   Protected WithEvents tssFichadas As ToolStripStatusLabel
   Friend WithEvents dgvFichadas As DataGridView
   Friend WithEvents fbdCarpeta As FolderBrowserDialog
   Friend WithEvents txtContraseña As TextBox
   Public WithEvents Label1 As Label
   Public WithEvents Label2 As Label
   Friend WithEvents tbpLegajos As TabPage
   Friend WithEvents dgvLegajos As DataGridView
   Friend WithEvents OpenFileDialog1 As OpenFileDialog
   Friend WithEvents btnBuscarBase As Button
   Protected Friend WithEvents StatusStrip1 As StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar2 As ToolStripProgressBar
   Protected WithEvents tssLegajos As ToolStripStatusLabel
   Friend WithEvents tbpSectores As TabPage
   Protected Friend WithEvents StatusStrip2 As StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar3 As ToolStripProgressBar
   Protected WithEvents tssSectores As ToolStripStatusLabel
   Friend WithEvents dgvSectores As DataGridView
   Friend WithEvents tbpCategorias As TabPage
   Protected Friend WithEvents StatusStrip3 As StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar4 As ToolStripProgressBar
   Protected WithEvents tssCategorias As ToolStripStatusLabel
   Friend WithEvents dgvCategorias As DataGridView
   Friend WithEvents tbpNodos As TabPage
   Protected Friend WithEvents StatusStrip4 As StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar5 As ToolStripProgressBar
   Protected WithEvents tssNodos As ToolStripStatusLabel
   Friend WithEvents dgvNodos As DataGridView
   Public WithEvents txtTablasMigradas As Label
End Class
