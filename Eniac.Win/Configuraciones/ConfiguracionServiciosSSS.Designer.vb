<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionServiciosSSS
   Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionServiciosSSS))
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tbpDBConfig = New System.Windows.Forms.TabPage()
      Me.txtCopiarEnDirectorio = New System.Windows.Forms.TextBox()
      Me.lblCopiarEnDire = New System.Windows.Forms.Label()
      Me.txtBDDirectorioDestino = New System.Windows.Forms.TextBox()
      Me.lblBDDirectorioDestino = New System.Windows.Forms.Label()
      Me.txtBDBaseDatos = New System.Windows.Forms.TextBox()
      Me.txtBDUsuario = New System.Windows.Forms.TextBox()
      Me.txtBDContrasena = New System.Windows.Forms.TextBox()
      Me.lblBDBaseDatos = New System.Windows.Forms.Label()
      Me.lblBDUsuario = New System.Windows.Forms.Label()
      Me.lblBDContrasena = New System.Windows.Forms.Label()
      Me.lblBDServidor = New System.Windows.Forms.Label()
      Me.txtBDServidor = New System.Windows.Forms.TextBox()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.tsbObtenerBD = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabarBD = New System.Windows.Forms.ToolStripButton()
      Me.tbpSchedule = New System.Windows.Forms.TabPage()
      Me.lblSegundos = New System.Windows.Forms.Label()
      Me.lblMinutos = New System.Windows.Forms.Label()
      Me.mtbProHoraHasta = New System.Windows.Forms.MaskedTextBox()
      Me.mtbProHoraDesde = New System.Windows.Forms.MaskedTextBox()
      Me.chbProSabado = New System.Windows.Forms.CheckBox()
      Me.chbProDomingo = New System.Windows.Forms.CheckBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.chbProMartes = New System.Windows.Forms.CheckBox()
      Me.chbProMiercoles = New System.Windows.Forms.CheckBox()
      Me.chbProJueves = New System.Windows.Forms.CheckBox()
      Me.chbProViernes = New System.Windows.Forms.CheckBox()
      Me.chbProLunes = New System.Windows.Forms.CheckBox()
      Me.txtProTiempoEspera = New System.Windows.Forms.TextBox()
      Me.lblProTiempoEspera = New System.Windows.Forms.Label()
      Me.txtProFrecuencia = New System.Windows.Forms.TextBox()
      Me.lblProFrecuencia = New System.Windows.Forms.Label()
      Me.lblProHoraDesde = New System.Windows.Forms.Label()
      Me.lblProHoraHasta = New System.Windows.Forms.Label()
      Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
      Me.tsbObtenerProgramacion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabarProgramacion = New System.Windows.Forms.ToolStripButton()
      Me.tbpMailConfig = New System.Windows.Forms.TabPage()
      Me.grbDestinatarios = New System.Windows.Forms.GroupBox()
      Me.txtDestinatarios = New System.Windows.Forms.TextBox()
      Me.grbEMail = New System.Windows.Forms.GroupBox()
      Me.chbMailRequiereSSL = New Eniac.Controles.CheckBox()
      Me.chbMailRequiereAutenticacion = New Eniac.Controles.CheckBox()
      Me.txtMailPuertoSalida = New Eniac.Controles.TextBox()
      Me.lblMailServidor = New Eniac.Controles.Label()
      Me.txtMailDireccion = New Eniac.Controles.TextBox()
      Me.lblMailDireccion = New Eniac.Controles.Label()
      Me.txtMailPassword = New Eniac.Controles.TextBox()
      Me.lblMailPassword = New Eniac.Controles.Label()
      Me.txtMailUsuario = New Eniac.Controles.TextBox()
      Me.lblMailUsuario = New Eniac.Controles.Label()
      Me.txtMailServidor = New Eniac.Controles.TextBox()
      Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
      Me.tsbObtenerMail = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabarMail = New System.Windows.Forms.ToolStripButton()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tslEstadoServicio = New System.Windows.Forms.ToolStripLabel()
      Me.tsbCorrerServicio = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.TabControl1.SuspendLayout()
      Me.tbpDBConfig.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      Me.tbpSchedule.SuspendLayout()
      Me.ToolStrip2.SuspendLayout()
      Me.tbpMailConfig.SuspendLayout()
      Me.grbDestinatarios.SuspendLayout()
      Me.grbEMail.SuspendLayout()
      Me.ToolStrip3.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.tbpDBConfig)
      Me.TabControl1.Controls.Add(Me.tbpSchedule)
      Me.TabControl1.Controls.Add(Me.tbpMailConfig)
      Me.TabControl1.Location = New System.Drawing.Point(13, 42)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(761, 273)
      Me.TabControl1.TabIndex = 0
      '
      'tbpDBConfig
      '
      Me.tbpDBConfig.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDBConfig.Controls.Add(Me.txtCopiarEnDirectorio)
      Me.tbpDBConfig.Controls.Add(Me.lblCopiarEnDire)
      Me.tbpDBConfig.Controls.Add(Me.txtBDDirectorioDestino)
      Me.tbpDBConfig.Controls.Add(Me.lblBDDirectorioDestino)
      Me.tbpDBConfig.Controls.Add(Me.txtBDBaseDatos)
      Me.tbpDBConfig.Controls.Add(Me.txtBDUsuario)
      Me.tbpDBConfig.Controls.Add(Me.txtBDContrasena)
      Me.tbpDBConfig.Controls.Add(Me.lblBDBaseDatos)
      Me.tbpDBConfig.Controls.Add(Me.lblBDUsuario)
      Me.tbpDBConfig.Controls.Add(Me.lblBDContrasena)
      Me.tbpDBConfig.Controls.Add(Me.lblBDServidor)
      Me.tbpDBConfig.Controls.Add(Me.txtBDServidor)
      Me.tbpDBConfig.Controls.Add(Me.ToolStrip1)
      Me.tbpDBConfig.Location = New System.Drawing.Point(4, 22)
      Me.tbpDBConfig.Name = "tbpDBConfig"
      Me.tbpDBConfig.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDBConfig.Size = New System.Drawing.Size(753, 247)
      Me.tbpDBConfig.TabIndex = 0
      Me.tbpDBConfig.Text = "Base de Datos"
      '
      'txtCopiarEnDirectorio
      '
      Me.txtCopiarEnDirectorio.Location = New System.Drawing.Point(119, 183)
      Me.txtCopiarEnDirectorio.Name = "txtCopiarEnDirectorio"
      Me.txtCopiarEnDirectorio.Size = New System.Drawing.Size(220, 20)
      Me.txtCopiarEnDirectorio.TabIndex = 5
      Me.txtCopiarEnDirectorio.Text = "c:\Eniac\"
      '
      'lblCopiarEnDire
      '
      Me.lblCopiarEnDire.AutoSize = True
      Me.lblCopiarEnDire.Location = New System.Drawing.Point(20, 186)
      Me.lblCopiarEnDire.Name = "lblCopiarEnDire"
      Me.lblCopiarEnDire.Size = New System.Drawing.Size(98, 13)
      Me.lblCopiarEnDire.TabIndex = 12
      Me.lblCopiarEnDire.Text = "Copiar en directorio"
      '
      'txtBDDirectorioDestino
      '
      Me.txtBDDirectorioDestino.Location = New System.Drawing.Point(119, 157)
      Me.txtBDDirectorioDestino.Name = "txtBDDirectorioDestino"
      Me.txtBDDirectorioDestino.Size = New System.Drawing.Size(220, 20)
      Me.txtBDDirectorioDestino.TabIndex = 4
      Me.txtBDDirectorioDestino.Text = "c:\Eniac\"
      '
      'lblBDDirectorioDestino
      '
      Me.lblBDDirectorioDestino.AutoSize = True
      Me.lblBDDirectorioDestino.Location = New System.Drawing.Point(20, 160)
      Me.lblBDDirectorioDestino.Name = "lblBDDirectorioDestino"
      Me.lblBDDirectorioDestino.Size = New System.Drawing.Size(91, 13)
      Me.lblBDDirectorioDestino.TabIndex = 11
      Me.lblBDDirectorioDestino.Text = "Directorio Destino"
      '
      'txtBDBaseDatos
      '
      Me.txtBDBaseDatos.Location = New System.Drawing.Point(119, 79)
      Me.txtBDBaseDatos.Name = "txtBDBaseDatos"
      Me.txtBDBaseDatos.Size = New System.Drawing.Size(220, 20)
      Me.txtBDBaseDatos.TabIndex = 1
      '
      'txtBDUsuario
      '
      Me.txtBDUsuario.Location = New System.Drawing.Point(119, 105)
      Me.txtBDUsuario.Name = "txtBDUsuario"
      Me.txtBDUsuario.Size = New System.Drawing.Size(220, 20)
      Me.txtBDUsuario.TabIndex = 2
      '
      'txtBDContrasena
      '
      Me.txtBDContrasena.Location = New System.Drawing.Point(119, 131)
      Me.txtBDContrasena.Name = "txtBDContrasena"
      Me.txtBDContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtBDContrasena.Size = New System.Drawing.Size(220, 20)
      Me.txtBDContrasena.TabIndex = 3
      '
      'lblBDBaseDatos
      '
      Me.lblBDBaseDatos.AutoSize = True
      Me.lblBDBaseDatos.Location = New System.Drawing.Point(20, 82)
      Me.lblBDBaseDatos.Name = "lblBDBaseDatos"
      Me.lblBDBaseDatos.Size = New System.Drawing.Size(77, 13)
      Me.lblBDBaseDatos.TabIndex = 8
      Me.lblBDBaseDatos.Text = "Base de Datos"
      '
      'lblBDUsuario
      '
      Me.lblBDUsuario.AutoSize = True
      Me.lblBDUsuario.Location = New System.Drawing.Point(20, 108)
      Me.lblBDUsuario.Name = "lblBDUsuario"
      Me.lblBDUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblBDUsuario.TabIndex = 9
      Me.lblBDUsuario.Text = "Usuario"
      '
      'lblBDContrasena
      '
      Me.lblBDContrasena.AutoSize = True
      Me.lblBDContrasena.Location = New System.Drawing.Point(20, 134)
      Me.lblBDContrasena.Name = "lblBDContrasena"
      Me.lblBDContrasena.Size = New System.Drawing.Size(61, 13)
      Me.lblBDContrasena.TabIndex = 10
      Me.lblBDContrasena.Text = "Contraseña"
      '
      'lblBDServidor
      '
      Me.lblBDServidor.AutoSize = True
      Me.lblBDServidor.Location = New System.Drawing.Point(20, 56)
      Me.lblBDServidor.Name = "lblBDServidor"
      Me.lblBDServidor.Size = New System.Drawing.Size(46, 13)
      Me.lblBDServidor.TabIndex = 7
      Me.lblBDServidor.Text = "Servidor"
      '
      'txtBDServidor
      '
      Me.txtBDServidor.Location = New System.Drawing.Point(119, 53)
      Me.txtBDServidor.Name = "txtBDServidor"
      Me.txtBDServidor.Size = New System.Drawing.Size(220, 20)
      Me.txtBDServidor.TabIndex = 0
      '
      'ToolStrip1
      '
      Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbObtenerBD, Me.ToolStripSeparator1, Me.tsbGrabarBD})
      Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(747, 29)
      Me.ToolStrip1.TabIndex = 6
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'tsbObtenerBD
      '
      Me.tsbObtenerBD.Image = Global.Eniac.Win.My.Resources.Resources.database_zoom_32
      Me.tsbObtenerBD.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbObtenerBD.Name = "tsbObtenerBD"
      Me.tsbObtenerBD.Size = New System.Drawing.Size(109, 26)
      Me.tsbObtenerBD.Text = "&Obtener Datos"
      Me.tsbObtenerBD.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabarBD
      '
      Me.tsbGrabarBD.Enabled = False
      Me.tsbGrabarBD.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabarBD.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabarBD.Name = "tsbGrabarBD"
      Me.tsbGrabarBD.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabarBD.Text = "&Grabar"
      Me.tsbGrabarBD.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'tbpSchedule
      '
      Me.tbpSchedule.BackColor = System.Drawing.SystemColors.Control
      Me.tbpSchedule.Controls.Add(Me.lblSegundos)
      Me.tbpSchedule.Controls.Add(Me.lblMinutos)
      Me.tbpSchedule.Controls.Add(Me.mtbProHoraHasta)
      Me.tbpSchedule.Controls.Add(Me.mtbProHoraDesde)
      Me.tbpSchedule.Controls.Add(Me.chbProSabado)
      Me.tbpSchedule.Controls.Add(Me.chbProDomingo)
      Me.tbpSchedule.Controls.Add(Me.Label10)
      Me.tbpSchedule.Controls.Add(Me.chbProMartes)
      Me.tbpSchedule.Controls.Add(Me.chbProMiercoles)
      Me.tbpSchedule.Controls.Add(Me.chbProJueves)
      Me.tbpSchedule.Controls.Add(Me.chbProViernes)
      Me.tbpSchedule.Controls.Add(Me.chbProLunes)
      Me.tbpSchedule.Controls.Add(Me.txtProTiempoEspera)
      Me.tbpSchedule.Controls.Add(Me.lblProTiempoEspera)
      Me.tbpSchedule.Controls.Add(Me.txtProFrecuencia)
      Me.tbpSchedule.Controls.Add(Me.lblProFrecuencia)
      Me.tbpSchedule.Controls.Add(Me.lblProHoraDesde)
      Me.tbpSchedule.Controls.Add(Me.lblProHoraHasta)
      Me.tbpSchedule.Controls.Add(Me.ToolStrip2)
      Me.tbpSchedule.Location = New System.Drawing.Point(4, 22)
      Me.tbpSchedule.Name = "tbpSchedule"
      Me.tbpSchedule.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpSchedule.Size = New System.Drawing.Size(753, 247)
      Me.tbpSchedule.TabIndex = 1
      Me.tbpSchedule.Text = "Programación"
      '
      'lblSegundos
      '
      Me.lblSegundos.AutoSize = True
      Me.lblSegundos.Location = New System.Drawing.Point(154, 133)
      Me.lblSegundos.Name = "lblSegundos"
      Me.lblSegundos.Size = New System.Drawing.Size(53, 13)
      Me.lblSegundos.TabIndex = 26
      Me.lblSegundos.Text = "segundos"
      '
      'lblMinutos
      '
      Me.lblMinutos.AutoSize = True
      Me.lblMinutos.Location = New System.Drawing.Point(154, 106)
      Me.lblMinutos.Name = "lblMinutos"
      Me.lblMinutos.Size = New System.Drawing.Size(43, 13)
      Me.lblMinutos.TabIndex = 25
      Me.lblMinutos.Text = "minutos"
      '
      'mtbProHoraHasta
      '
      Me.mtbProHoraHasta.Location = New System.Drawing.Point(110, 76)
      Me.mtbProHoraHasta.Mask = "00:00"
      Me.mtbProHoraHasta.Name = "mtbProHoraHasta"
      Me.mtbProHoraHasta.Size = New System.Drawing.Size(42, 20)
      Me.mtbProHoraHasta.TabIndex = 1
      Me.mtbProHoraHasta.ValidatingType = GetType(Date)
      '
      'mtbProHoraDesde
      '
      Me.mtbProHoraDesde.Location = New System.Drawing.Point(110, 47)
      Me.mtbProHoraDesde.Mask = "00:00"
      Me.mtbProHoraDesde.Name = "mtbProHoraDesde"
      Me.mtbProHoraDesde.Size = New System.Drawing.Size(42, 20)
      Me.mtbProHoraDesde.TabIndex = 0
      Me.mtbProHoraDesde.ValidatingType = GetType(Date)
      '
      'chbProSabado
      '
      Me.chbProSabado.AutoSize = True
      Me.chbProSabado.Location = New System.Drawing.Point(366, 161)
      Me.chbProSabado.Name = "chbProSabado"
      Me.chbProSabado.Size = New System.Drawing.Size(63, 17)
      Me.chbProSabado.TabIndex = 9
      Me.chbProSabado.Text = "Sábado"
      Me.chbProSabado.UseVisualStyleBackColor = True
      '
      'chbProDomingo
      '
      Me.chbProDomingo.AutoSize = True
      Me.chbProDomingo.Location = New System.Drawing.Point(366, 182)
      Me.chbProDomingo.Name = "chbProDomingo"
      Me.chbProDomingo.Size = New System.Drawing.Size(68, 17)
      Me.chbProDomingo.TabIndex = 10
      Me.chbProDomingo.Text = "Domingo"
      Me.chbProDomingo.UseVisualStyleBackColor = True
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(265, 49)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(92, 13)
      Me.Label10.TabIndex = 20
      Me.Label10.Text = "Dias de ejecución"
      '
      'chbProMartes
      '
      Me.chbProMartes.AutoSize = True
      Me.chbProMartes.Location = New System.Drawing.Point(366, 69)
      Me.chbProMartes.Name = "chbProMartes"
      Me.chbProMartes.Size = New System.Drawing.Size(58, 17)
      Me.chbProMartes.TabIndex = 5
      Me.chbProMartes.Text = "Martes"
      Me.chbProMartes.UseVisualStyleBackColor = True
      '
      'chbProMiercoles
      '
      Me.chbProMiercoles.AutoSize = True
      Me.chbProMiercoles.Location = New System.Drawing.Point(366, 92)
      Me.chbProMiercoles.Name = "chbProMiercoles"
      Me.chbProMiercoles.Size = New System.Drawing.Size(71, 17)
      Me.chbProMiercoles.TabIndex = 6
      Me.chbProMiercoles.Text = "Miércoles"
      Me.chbProMiercoles.UseVisualStyleBackColor = True
      '
      'chbProJueves
      '
      Me.chbProJueves.AutoSize = True
      Me.chbProJueves.Location = New System.Drawing.Point(366, 115)
      Me.chbProJueves.Name = "chbProJueves"
      Me.chbProJueves.Size = New System.Drawing.Size(60, 17)
      Me.chbProJueves.TabIndex = 7
      Me.chbProJueves.Text = "Jueves"
      Me.chbProJueves.UseVisualStyleBackColor = True
      '
      'chbProViernes
      '
      Me.chbProViernes.AutoSize = True
      Me.chbProViernes.Location = New System.Drawing.Point(366, 138)
      Me.chbProViernes.Name = "chbProViernes"
      Me.chbProViernes.Size = New System.Drawing.Size(61, 17)
      Me.chbProViernes.TabIndex = 8
      Me.chbProViernes.Text = "Viernes"
      Me.chbProViernes.UseVisualStyleBackColor = True
      '
      'chbProLunes
      '
      Me.chbProLunes.AutoSize = True
      Me.chbProLunes.Location = New System.Drawing.Point(366, 47)
      Me.chbProLunes.Name = "chbProLunes"
      Me.chbProLunes.Size = New System.Drawing.Size(55, 17)
      Me.chbProLunes.TabIndex = 4
      Me.chbProLunes.Text = "Lunes"
      Me.chbProLunes.UseVisualStyleBackColor = True
      '
      'txtProTiempoEspera
      '
      Me.txtProTiempoEspera.Location = New System.Drawing.Point(110, 130)
      Me.txtProTiempoEspera.Name = "txtProTiempoEspera"
      Me.txtProTiempoEspera.Size = New System.Drawing.Size(42, 20)
      Me.txtProTiempoEspera.TabIndex = 3
      '
      'lblProTiempoEspera
      '
      Me.lblProTiempoEspera.AutoSize = True
      Me.lblProTiempoEspera.Location = New System.Drawing.Point(14, 133)
      Me.lblProTiempoEspera.Name = "lblProTiempoEspera"
      Me.lblProTiempoEspera.Size = New System.Drawing.Size(93, 13)
      Me.lblProTiempoEspera.TabIndex = 13
      Me.lblProTiempoEspera.Text = "Tiempo de Espera"
      '
      'txtProFrecuencia
      '
      Me.txtProFrecuencia.Location = New System.Drawing.Point(110, 103)
      Me.txtProFrecuencia.Name = "txtProFrecuencia"
      Me.txtProFrecuencia.Size = New System.Drawing.Size(42, 20)
      Me.txtProFrecuencia.TabIndex = 2
      '
      'lblProFrecuencia
      '
      Me.lblProFrecuencia.AutoSize = True
      Me.lblProFrecuencia.Location = New System.Drawing.Point(14, 106)
      Me.lblProFrecuencia.Name = "lblProFrecuencia"
      Me.lblProFrecuencia.Size = New System.Drawing.Size(60, 13)
      Me.lblProFrecuencia.TabIndex = 11
      Me.lblProFrecuencia.Text = "Frecuencia"
      '
      'lblProHoraDesde
      '
      Me.lblProHoraDesde.AutoSize = True
      Me.lblProHoraDesde.Location = New System.Drawing.Point(13, 53)
      Me.lblProHoraDesde.Name = "lblProHoraDesde"
      Me.lblProHoraDesde.Size = New System.Drawing.Size(64, 13)
      Me.lblProHoraDesde.TabIndex = 8
      Me.lblProHoraDesde.Text = "Hora Desde"
      '
      'lblProHoraHasta
      '
      Me.lblProHoraHasta.AutoSize = True
      Me.lblProHoraHasta.Location = New System.Drawing.Point(13, 79)
      Me.lblProHoraHasta.Name = "lblProHoraHasta"
      Me.lblProHoraHasta.Size = New System.Drawing.Size(61, 13)
      Me.lblProHoraHasta.TabIndex = 7
      Me.lblProHoraHasta.Text = "Hora Hasta"
      '
      'ToolStrip2
      '
      Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbObtenerProgramacion, Me.ToolStripSeparator2, Me.tsbGrabarProgramacion})
      Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
      Me.ToolStrip2.Name = "ToolStrip2"
      Me.ToolStrip2.Size = New System.Drawing.Size(747, 29)
      Me.ToolStrip2.TabIndex = 5
      Me.ToolStrip2.Text = "ToolStrip2"
      '
      'tsbObtenerProgramacion
      '
      Me.tsbObtenerProgramacion.Image = Global.Eniac.Win.My.Resources.Resources.database_zoom_32
      Me.tsbObtenerProgramacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbObtenerProgramacion.Name = "tsbObtenerProgramacion"
      Me.tsbObtenerProgramacion.Size = New System.Drawing.Size(154, 26)
      Me.tsbObtenerProgramacion.Text = "&Obtener Programación"
      Me.tsbObtenerProgramacion.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabarProgramacion
      '
      Me.tsbGrabarProgramacion.Enabled = False
      Me.tsbGrabarProgramacion.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabarProgramacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabarProgramacion.Name = "tsbGrabarProgramacion"
      Me.tsbGrabarProgramacion.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabarProgramacion.Text = "&Grabar"
      Me.tsbGrabarProgramacion.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'tbpMailConfig
      '
      Me.tbpMailConfig.BackColor = System.Drawing.SystemColors.Control
      Me.tbpMailConfig.Controls.Add(Me.grbDestinatarios)
      Me.tbpMailConfig.Controls.Add(Me.grbEMail)
      Me.tbpMailConfig.Controls.Add(Me.ToolStrip3)
      Me.tbpMailConfig.Location = New System.Drawing.Point(4, 22)
      Me.tbpMailConfig.Name = "tbpMailConfig"
      Me.tbpMailConfig.Size = New System.Drawing.Size(753, 247)
      Me.tbpMailConfig.TabIndex = 2
      Me.tbpMailConfig.Text = "Mail"
      '
      'grbDestinatarios
      '
      Me.grbDestinatarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDestinatarios.Controls.Add(Me.txtDestinatarios)
      Me.grbDestinatarios.Location = New System.Drawing.Point(352, 40)
      Me.grbDestinatarios.Name = "grbDestinatarios"
      Me.grbDestinatarios.Size = New System.Drawing.Size(390, 196)
      Me.grbDestinatarios.TabIndex = 1
      Me.grbDestinatarios.TabStop = False
      Me.grbDestinatarios.Text = "Destinatarios"
      '
      'txtDestinatarios
      '
      Me.txtDestinatarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDestinatarios.Location = New System.Drawing.Point(6, 19)
      Me.txtDestinatarios.Multiline = True
      Me.txtDestinatarios.Name = "txtDestinatarios"
      Me.txtDestinatarios.Size = New System.Drawing.Size(378, 168)
      Me.txtDestinatarios.TabIndex = 0
      '
      'grbEMail
      '
      Me.grbEMail.Controls.Add(Me.chbMailRequiereSSL)
      Me.grbEMail.Controls.Add(Me.chbMailRequiereAutenticacion)
      Me.grbEMail.Controls.Add(Me.txtMailPuertoSalida)
      Me.grbEMail.Controls.Add(Me.txtMailDireccion)
      Me.grbEMail.Controls.Add(Me.lblMailDireccion)
      Me.grbEMail.Controls.Add(Me.txtMailPassword)
      Me.grbEMail.Controls.Add(Me.lblMailPassword)
      Me.grbEMail.Controls.Add(Me.txtMailUsuario)
      Me.grbEMail.Controls.Add(Me.lblMailUsuario)
      Me.grbEMail.Controls.Add(Me.txtMailServidor)
      Me.grbEMail.Controls.Add(Me.lblMailServidor)
      Me.grbEMail.Location = New System.Drawing.Point(10, 40)
      Me.grbEMail.Name = "grbEMail"
      Me.grbEMail.Size = New System.Drawing.Size(336, 196)
      Me.grbEMail.TabIndex = 0
      Me.grbEMail.TabStop = False
      Me.grbEMail.Text = "eMail"
      '
      'chbMailRequiereSSL
      '
      Me.chbMailRequiereSSL.BindearPropiedadControl = Nothing
      Me.chbMailRequiereSSL.BindearPropiedadEntidad = Nothing
      Me.chbMailRequiereSSL.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMailRequiereSSL.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMailRequiereSSL.IsPK = False
      Me.chbMailRequiereSSL.IsRequired = False
      Me.chbMailRequiereSSL.Key = Nothing
      Me.chbMailRequiereSSL.LabelAsoc = Nothing
      Me.chbMailRequiereSSL.Location = New System.Drawing.Point(99, 132)
      Me.chbMailRequiereSSL.Name = "chbMailRequiereSSL"
      Me.chbMailRequiereSSL.Size = New System.Drawing.Size(228, 27)
      Me.chbMailRequiereSSL.TabIndex = 5
      Me.chbMailRequiereSSL.Tag = "MAILREQUIERESSL"
      Me.chbMailRequiereSSL.Text = "Requiere una conexión segura (SSL)"
      Me.chbMailRequiereSSL.UseVisualStyleBackColor = True
      '
      'chbMailRequiereAutenticacion
      '
      Me.chbMailRequiereAutenticacion.BindearPropiedadControl = Nothing
      Me.chbMailRequiereAutenticacion.BindearPropiedadEntidad = Nothing
      Me.chbMailRequiereAutenticacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMailRequiereAutenticacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMailRequiereAutenticacion.IsPK = False
      Me.chbMailRequiereAutenticacion.IsRequired = False
      Me.chbMailRequiereAutenticacion.Key = Nothing
      Me.chbMailRequiereAutenticacion.LabelAsoc = Nothing
      Me.chbMailRequiereAutenticacion.Location = New System.Drawing.Point(99, 161)
      Me.chbMailRequiereAutenticacion.Name = "chbMailRequiereAutenticacion"
      Me.chbMailRequiereAutenticacion.Size = New System.Drawing.Size(201, 23)
      Me.chbMailRequiereAutenticacion.TabIndex = 6
      Me.chbMailRequiereAutenticacion.Tag = "MAILREQUIEREAUTENTICACION"
      Me.chbMailRequiereAutenticacion.Text = "El Servidor Requiere autenticación"
      Me.chbMailRequiereAutenticacion.UseVisualStyleBackColor = True
      '
      'txtMailPuertoSalida
      '
      Me.txtMailPuertoSalida.BindearPropiedadControl = Nothing
      Me.txtMailPuertoSalida.BindearPropiedadEntidad = Nothing
      Me.txtMailPuertoSalida.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailPuertoSalida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailPuertoSalida.Formato = ""
      Me.txtMailPuertoSalida.IsDecimal = False
      Me.txtMailPuertoSalida.IsNumber = True
      Me.txtMailPuertoSalida.IsPK = False
      Me.txtMailPuertoSalida.IsRequired = False
      Me.txtMailPuertoSalida.Key = ""
      Me.txtMailPuertoSalida.LabelAsoc = Me.lblMailServidor
      Me.txtMailPuertoSalida.Location = New System.Drawing.Point(290, 26)
      Me.txtMailPuertoSalida.MaxLength = 5
      Me.txtMailPuertoSalida.Name = "txtMailPuertoSalida"
      Me.txtMailPuertoSalida.Size = New System.Drawing.Size(30, 20)
      Me.txtMailPuertoSalida.TabIndex = 1
      Me.txtMailPuertoSalida.Tag = "MAILPUERTOSALIDA"
      Me.txtMailPuertoSalida.Text = "25"
      '
      'lblMailServidor
      '
      Me.lblMailServidor.AutoSize = True
      Me.lblMailServidor.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailServidor.Location = New System.Drawing.Point(14, 30)
      Me.lblMailServidor.Name = "lblMailServidor"
      Me.lblMailServidor.Size = New System.Drawing.Size(79, 13)
      Me.lblMailServidor.TabIndex = 0
      Me.lblMailServidor.Text = "Servidor SMTP"
      '
      'txtMailDireccion
      '
      Me.txtMailDireccion.BindearPropiedadControl = Nothing
      Me.txtMailDireccion.BindearPropiedadEntidad = Nothing
      Me.txtMailDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailDireccion.Formato = ""
      Me.txtMailDireccion.IsDecimal = False
      Me.txtMailDireccion.IsNumber = False
      Me.txtMailDireccion.IsPK = False
      Me.txtMailDireccion.IsRequired = False
      Me.txtMailDireccion.Key = ""
      Me.txtMailDireccion.LabelAsoc = Me.lblMailDireccion
      Me.txtMailDireccion.Location = New System.Drawing.Point(99, 53)
      Me.txtMailDireccion.MaxLength = 80
      Me.txtMailDireccion.Name = "txtMailDireccion"
      Me.txtMailDireccion.Size = New System.Drawing.Size(220, 20)
      Me.txtMailDireccion.TabIndex = 2
      Me.txtMailDireccion.Tag = "MAILDIRECCION"
      '
      'lblMailDireccion
      '
      Me.lblMailDireccion.AutoSize = True
      Me.lblMailDireccion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailDireccion.Location = New System.Drawing.Point(14, 57)
      Me.lblMailDireccion.Name = "lblMailDireccion"
      Me.lblMailDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblMailDireccion.TabIndex = 3
      Me.lblMailDireccion.Text = "Dirección"
      '
      'txtMailPassword
      '
      Me.txtMailPassword.BindearPropiedadControl = Nothing
      Me.txtMailPassword.BindearPropiedadEntidad = Nothing
      Me.txtMailPassword.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailPassword.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailPassword.Formato = ""
      Me.txtMailPassword.IsDecimal = False
      Me.txtMailPassword.IsNumber = False
      Me.txtMailPassword.IsPK = False
      Me.txtMailPassword.IsRequired = False
      Me.txtMailPassword.Key = ""
      Me.txtMailPassword.LabelAsoc = Me.lblMailPassword
      Me.txtMailPassword.Location = New System.Drawing.Point(99, 103)
      Me.txtMailPassword.MaxLength = 80
      Me.txtMailPassword.Name = "txtMailPassword"
      Me.txtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.txtMailPassword.Size = New System.Drawing.Size(220, 20)
      Me.txtMailPassword.TabIndex = 4
      Me.txtMailPassword.Tag = "MAILPASSWORD"
      '
      'lblMailPassword
      '
      Me.lblMailPassword.AutoSize = True
      Me.lblMailPassword.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailPassword.Location = New System.Drawing.Point(14, 107)
      Me.lblMailPassword.Name = "lblMailPassword"
      Me.lblMailPassword.Size = New System.Drawing.Size(53, 13)
      Me.lblMailPassword.TabIndex = 7
      Me.lblMailPassword.Text = "Password"
      '
      'txtMailUsuario
      '
      Me.txtMailUsuario.BindearPropiedadControl = Nothing
      Me.txtMailUsuario.BindearPropiedadEntidad = Nothing
      Me.txtMailUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailUsuario.Formato = ""
      Me.txtMailUsuario.IsDecimal = False
      Me.txtMailUsuario.IsNumber = False
      Me.txtMailUsuario.IsPK = False
      Me.txtMailUsuario.IsRequired = False
      Me.txtMailUsuario.Key = ""
      Me.txtMailUsuario.LabelAsoc = Me.lblMailUsuario
      Me.txtMailUsuario.Location = New System.Drawing.Point(99, 77)
      Me.txtMailUsuario.MaxLength = 80
      Me.txtMailUsuario.Name = "txtMailUsuario"
      Me.txtMailUsuario.Size = New System.Drawing.Size(220, 20)
      Me.txtMailUsuario.TabIndex = 3
      Me.txtMailUsuario.Tag = "MAILUSUARIO"
      '
      'lblMailUsuario
      '
      Me.lblMailUsuario.AutoSize = True
      Me.lblMailUsuario.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMailUsuario.Location = New System.Drawing.Point(14, 81)
      Me.lblMailUsuario.Name = "lblMailUsuario"
      Me.lblMailUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblMailUsuario.TabIndex = 5
      Me.lblMailUsuario.Text = "Usuario"
      '
      'txtMailServidor
      '
      Me.txtMailServidor.BindearPropiedadControl = Nothing
      Me.txtMailServidor.BindearPropiedadEntidad = Nothing
      Me.txtMailServidor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailServidor.Formato = ""
      Me.txtMailServidor.IsDecimal = False
      Me.txtMailServidor.IsNumber = False
      Me.txtMailServidor.IsPK = False
      Me.txtMailServidor.IsRequired = False
      Me.txtMailServidor.Key = ""
      Me.txtMailServidor.LabelAsoc = Me.lblMailServidor
      Me.txtMailServidor.Location = New System.Drawing.Point(99, 26)
      Me.txtMailServidor.MaxLength = 80
      Me.txtMailServidor.Name = "txtMailServidor"
      Me.txtMailServidor.Size = New System.Drawing.Size(185, 20)
      Me.txtMailServidor.TabIndex = 0
      Me.txtMailServidor.Tag = "MAILSERVIDOR"
      '
      'ToolStrip3
      '
      Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbObtenerMail, Me.ToolStripSeparator3, Me.tsbGrabarMail})
      Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip3.Name = "ToolStrip3"
      Me.ToolStrip3.Size = New System.Drawing.Size(753, 29)
      Me.ToolStrip3.TabIndex = 6
      Me.ToolStrip3.Text = "ToolStrip3"
      '
      'tsbObtenerMail
      '
      Me.tsbObtenerMail.Image = Global.Eniac.Win.My.Resources.Resources.database_zoom_32
      Me.tsbObtenerMail.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbObtenerMail.Name = "tsbObtenerMail"
      Me.tsbObtenerMail.Size = New System.Drawing.Size(102, 26)
      Me.tsbObtenerMail.Text = "&Obtener Mail"
      Me.tsbObtenerMail.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabarMail
      '
      Me.tsbGrabarMail.Enabled = False
      Me.tsbGrabarMail.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabarMail.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabarMail.Name = "tsbGrabarMail"
      Me.tsbGrabarMail.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabarMail.Text = "&Grabar"
      Me.tsbGrabarMail.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslEstadoServicio, Me.tsbCorrerServicio, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(783, 29)
      Me.tstBarra.TabIndex = 1
      Me.tstBarra.Text = "ToolStrip1"
      '
      'tslEstadoServicio
      '
      Me.tslEstadoServicio.Name = "tslEstadoServicio"
      Me.tslEstadoServicio.Size = New System.Drawing.Size(0, 26)
      '
      'tsbCorrerServicio
      '
      Me.tsbCorrerServicio.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
      Me.tsbCorrerServicio.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCorrerServicio.Name = "tsbCorrerServicio"
      Me.tsbCorrerServicio.Size = New System.Drawing.Size(110, 26)
      Me.tsbCorrerServicio.Text = "Correr Servicio"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario de Tareas"
      '
      'ConfiguracionServiciosSSS
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(783, 327)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.TabControl1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ConfiguracionServiciosSSS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Configuracion de Backup Automático"
      Me.TabControl1.ResumeLayout(False)
      Me.tbpDBConfig.ResumeLayout(False)
      Me.tbpDBConfig.PerformLayout()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.tbpSchedule.ResumeLayout(False)
      Me.tbpSchedule.PerformLayout()
      Me.ToolStrip2.ResumeLayout(False)
      Me.ToolStrip2.PerformLayout()
      Me.tbpMailConfig.ResumeLayout(False)
      Me.tbpMailConfig.PerformLayout()
      Me.grbDestinatarios.ResumeLayout(False)
      Me.grbDestinatarios.PerformLayout()
      Me.grbEMail.ResumeLayout(False)
      Me.grbEMail.PerformLayout()
      Me.ToolStrip3.ResumeLayout(False)
      Me.ToolStrip3.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpDBConfig As System.Windows.Forms.TabPage
   Friend WithEvents tbpSchedule As System.Windows.Forms.TabPage
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tbpMailConfig As System.Windows.Forms.TabPage
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbObtenerBD As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabarBD As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbObtenerProgramacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabarProgramacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbObtenerMail As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabarMail As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtBDBaseDatos As System.Windows.Forms.TextBox
   Friend WithEvents txtBDUsuario As System.Windows.Forms.TextBox
   Friend WithEvents txtBDContrasena As System.Windows.Forms.TextBox
   Friend WithEvents lblBDBaseDatos As System.Windows.Forms.Label
   Friend WithEvents lblBDUsuario As System.Windows.Forms.Label
   Friend WithEvents lblBDContrasena As System.Windows.Forms.Label
   Friend WithEvents lblBDServidor As System.Windows.Forms.Label
   Friend WithEvents txtBDServidor As System.Windows.Forms.TextBox
   Friend WithEvents txtBDDirectorioDestino As System.Windows.Forms.TextBox
   Friend WithEvents lblBDDirectorioDestino As System.Windows.Forms.Label
   Friend WithEvents chbProSabado As System.Windows.Forms.CheckBox
   Friend WithEvents chbProDomingo As System.Windows.Forms.CheckBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents chbProMartes As System.Windows.Forms.CheckBox
   Friend WithEvents chbProMiercoles As System.Windows.Forms.CheckBox
   Friend WithEvents chbProJueves As System.Windows.Forms.CheckBox
   Friend WithEvents chbProViernes As System.Windows.Forms.CheckBox
   Friend WithEvents chbProLunes As System.Windows.Forms.CheckBox
   Friend WithEvents txtProTiempoEspera As System.Windows.Forms.TextBox
   Friend WithEvents lblProTiempoEspera As System.Windows.Forms.Label
   Friend WithEvents txtProFrecuencia As System.Windows.Forms.TextBox
   Friend WithEvents lblProFrecuencia As System.Windows.Forms.Label
   Friend WithEvents lblProHoraDesde As System.Windows.Forms.Label
   Friend WithEvents lblProHoraHasta As System.Windows.Forms.Label
   Friend WithEvents grbEMail As System.Windows.Forms.GroupBox
   Friend WithEvents chbMailRequiereSSL As Eniac.Controles.CheckBox
   Friend WithEvents chbMailRequiereAutenticacion As Eniac.Controles.CheckBox
   Friend WithEvents txtMailPuertoSalida As Eniac.Controles.TextBox
   Friend WithEvents lblMailServidor As Eniac.Controles.Label
   Friend WithEvents txtMailDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblMailDireccion As Eniac.Controles.Label
   Friend WithEvents txtMailPassword As Eniac.Controles.TextBox
   Friend WithEvents lblMailPassword As Eniac.Controles.Label
   Friend WithEvents txtMailUsuario As Eniac.Controles.TextBox
   Friend WithEvents lblMailUsuario As Eniac.Controles.Label
   Friend WithEvents txtMailServidor As Eniac.Controles.TextBox
   Friend WithEvents grbDestinatarios As System.Windows.Forms.GroupBox
   Friend WithEvents txtDestinatarios As System.Windows.Forms.TextBox
   Friend WithEvents mtbProHoraHasta As System.Windows.Forms.MaskedTextBox
   Friend WithEvents mtbProHoraDesde As System.Windows.Forms.MaskedTextBox
   Friend WithEvents tslEstadoServicio As System.Windows.Forms.ToolStripLabel
   Friend WithEvents tsbCorrerServicio As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblMinutos As System.Windows.Forms.Label
   Friend WithEvents lblSegundos As System.Windows.Forms.Label
   Friend WithEvents txtCopiarEnDirectorio As System.Windows.Forms.TextBox
   Friend WithEvents lblCopiarEnDire As System.Windows.Forms.Label
End Class
