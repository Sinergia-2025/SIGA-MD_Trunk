<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVerificarRed
   Inherits System.Windows.Forms.Form

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
      Me.components = New System.ComponentModel.Container()
      Me.btnVerificar = New System.Windows.Forms.Button()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblPingServidorTitulo = New System.Windows.Forms.Label()
      Me.lblPingServidor = New System.Windows.Forms.Label()
      Me.lblPingSQLServerTitulo = New System.Windows.Forms.Label()
      Me.lblPingSQLServer = New System.Windows.Forms.Label()
      Me.picPingServidor = New System.Windows.Forms.PictureBox()
      Me.picPingSQLServer = New System.Windows.Forms.PictureBox()
      Me.lblPingGoogleTitulo = New System.Windows.Forms.Label()
      Me.lblPingGoogle = New System.Windows.Forms.Label()
      Me.picPingGoogle = New System.Windows.Forms.PictureBox()
      Me.lblPingAFIPTitulo = New System.Windows.Forms.Label()
      Me.lblPingAFIPWSAA = New System.Windows.Forms.Label()
      Me.picPingAFIPWSAA = New System.Windows.Forms.PictureBox()
      Me.lblPingAFIPWSFE = New System.Windows.Forms.Label()
      Me.picPingAFIPWSFE_1 = New System.Windows.Forms.PictureBox()
      Me.lblSharedFoldersTitulo = New System.Windows.Forms.Label()
      Me.lblSharedFolders = New System.Windows.Forms.Label()
      Me.picSharedFolders = New System.Windows.Forms.PictureBox()
      Me.picPingAFIPWSFE_2 = New System.Windows.Forms.PictureBox()
      Me.picPingAFIPWSFE_3 = New System.Windows.Forms.PictureBox()
      Me.lblPingAFIP1Titulo = New System.Windows.Forms.Label()
      Me.lblPingAFIP2Titulo = New System.Windows.Forms.Label()
      Me.lblPingAFIP3Titulo = New System.Windows.Forms.Label()
      Me.lblProblema1 = New System.Windows.Forms.Label()
      Me.lblProblema4 = New System.Windows.Forms.Label()
      Me.lblProblema5 = New System.Windows.Forms.Label()
      Me.lblProblema3 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.lblAccion1 = New System.Windows.Forms.Label()
      Me.lblProblema2 = New System.Windows.Forms.Label()
      Me.lblAccion2 = New System.Windows.Forms.Label()
      Me.lblAccion4 = New System.Windows.Forms.Label()
      Me.lblAccion3 = New System.Windows.Forms.Label()
      Me.lblAccion5 = New System.Windows.Forms.Label()
      Me.lblAccion6 = New System.Windows.Forms.Label()
      Me.lblAccion7 = New System.Windows.Forms.Label()
      Me.lblAccion8 = New System.Windows.Forms.Label()
      Me.lblProblema6 = New System.Windows.Forms.Label()
      Me.lblProblema7 = New System.Windows.Forms.Label()
      Me.lblProblema8 = New System.Windows.Forms.Label()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.picPingServidor, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPingSQLServer, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPingGoogle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPingAFIPWSAA, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPingAFIPWSFE_1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picSharedFolders, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPingAFIPWSFE_2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.picPingAFIPWSFE_3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnVerificar
      '
      Me.btnVerificar.AutoSize = True
      Me.btnVerificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnVerificar.Location = New System.Drawing.Point(363, 0)
      Me.btnVerificar.Name = "btnVerificar"
      Me.btnVerificar.Size = New System.Drawing.Size(147, 34)
      Me.btnVerificar.TabIndex = 0
      Me.btnVerificar.Text = "Verificar"
      Me.btnVerificar.UseVisualStyleBackColor = True
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 5
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingServidorTitulo, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingServidor, 1, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingSQLServerTitulo, 0, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingSQLServer, 1, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingServidor, 2, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingSQLServer, 2, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingGoogleTitulo, 0, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingGoogle, 1, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingGoogle, 2, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingAFIPTitulo, 0, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingAFIPWSAA, 1, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingAFIPWSAA, 2, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingAFIPWSFE, 1, 6)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingAFIPWSFE_1, 2, 6)
      Me.TableLayoutPanel1.Controls.Add(Me.lblSharedFoldersTitulo, 0, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.lblSharedFolders, 1, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.picSharedFolders, 2, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingAFIPWSFE_2, 2, 7)
      Me.TableLayoutPanel1.Controls.Add(Me.picPingAFIPWSFE_3, 2, 8)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingAFIP1Titulo, 0, 6)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingAFIP2Titulo, 0, 7)
      Me.TableLayoutPanel1.Controls.Add(Me.lblPingAFIP3Titulo, 0, 8)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema1, 3, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema4, 3, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema5, 3, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema3, 3, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.Label12, 3, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Label13, 4, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion1, 4, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema2, 3, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion2, 4, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion4, 4, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion3, 4, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion5, 4, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion6, 4, 6)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion7, 4, 7)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAccion8, 4, 8)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema6, 3, 6)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema7, 3, 7)
      Me.TableLayoutPanel1.Controls.Add(Me.lblProblema8, 3, 8)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 10
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(872, 327)
      Me.TableLayoutPanel1.TabIndex = 1
      '
      'lblPingServidorTitulo
      '
      Me.lblPingServidorTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingServidorTitulo.AutoSize = True
      Me.lblPingServidorTitulo.Location = New System.Drawing.Point(3, 20)
      Me.lblPingServidorTitulo.Name = "lblPingServidorTitulo"
      Me.lblPingServidorTitulo.Size = New System.Drawing.Size(127, 38)
      Me.lblPingServidorTitulo.TabIndex = 0
      Me.lblPingServidorTitulo.Text = "Haciendo ping al servidor"
      Me.lblPingServidorTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingServidor
      '
      Me.lblPingServidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingServidor.AutoSize = True
      Me.lblPingServidor.Location = New System.Drawing.Point(194, 20)
      Me.lblPingServidor.Name = "lblPingServidor"
      Me.lblPingServidor.Size = New System.Drawing.Size(94, 38)
      Me.lblPingServidor.TabIndex = 1
      Me.lblPingServidor.Text = "{Nombre Servidor}"
      Me.lblPingServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingSQLServerTitulo
      '
      Me.lblPingSQLServerTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingSQLServerTitulo.AutoSize = True
      Me.lblPingSQLServerTitulo.Location = New System.Drawing.Point(3, 96)
      Me.lblPingSQLServerTitulo.Name = "lblPingSQLServerTitulo"
      Me.lblPingSQLServerTitulo.Size = New System.Drawing.Size(185, 38)
      Me.lblPingSQLServerTitulo.TabIndex = 2
      Me.lblPingSQLServerTitulo.Text = "Verificando conexión con SQL Server"
      Me.lblPingSQLServerTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingSQLServer
      '
      Me.lblPingSQLServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingSQLServer.AutoSize = True
      Me.lblPingSQLServer.Location = New System.Drawing.Point(194, 96)
      Me.lblPingSQLServer.Name = "lblPingSQLServer"
      Me.lblPingSQLServer.Size = New System.Drawing.Size(98, 38)
      Me.lblPingSQLServer.TabIndex = 1
      Me.lblPingSQLServer.Text = "{Nombre Instancia}"
      Me.lblPingSQLServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'picPingServidor
      '
      Me.picPingServidor.Location = New System.Drawing.Point(307, 23)
      Me.picPingServidor.Name = "picPingServidor"
      Me.picPingServidor.Size = New System.Drawing.Size(32, 32)
      Me.picPingServidor.TabIndex = 3
      Me.picPingServidor.TabStop = False
      '
      'picPingSQLServer
      '
      Me.picPingSQLServer.Location = New System.Drawing.Point(307, 99)
      Me.picPingSQLServer.Name = "picPingSQLServer"
      Me.picPingSQLServer.Size = New System.Drawing.Size(32, 32)
      Me.picPingSQLServer.TabIndex = 3
      Me.picPingSQLServer.TabStop = False
      '
      'lblPingGoogleTitulo
      '
      Me.lblPingGoogleTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingGoogleTitulo.AutoSize = True
      Me.lblPingGoogleTitulo.Location = New System.Drawing.Point(3, 134)
      Me.lblPingGoogleTitulo.Name = "lblPingGoogleTitulo"
      Me.lblPingGoogleTitulo.Size = New System.Drawing.Size(145, 38)
      Me.lblPingGoogleTitulo.TabIndex = 0
      Me.lblPingGoogleTitulo.Text = "Haciendo ping a Google.com"
      Me.lblPingGoogleTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingGoogle
      '
      Me.lblPingGoogle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingGoogle.AutoSize = True
      Me.lblPingGoogle.Location = New System.Drawing.Point(194, 134)
      Me.lblPingGoogle.Name = "lblPingGoogle"
      Me.lblPingGoogle.Size = New System.Drawing.Size(64, 38)
      Me.lblPingGoogle.TabIndex = 1
      Me.lblPingGoogle.Text = "Google.com"
      Me.lblPingGoogle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'picPingGoogle
      '
      Me.picPingGoogle.Location = New System.Drawing.Point(307, 137)
      Me.picPingGoogle.Name = "picPingGoogle"
      Me.picPingGoogle.Size = New System.Drawing.Size(32, 32)
      Me.picPingGoogle.TabIndex = 3
      Me.picPingGoogle.TabStop = False
      '
      'lblPingAFIPTitulo
      '
      Me.lblPingAFIPTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingAFIPTitulo.AutoSize = True
      Me.lblPingAFIPTitulo.Location = New System.Drawing.Point(3, 172)
      Me.lblPingAFIPTitulo.Name = "lblPingAFIPTitulo"
      Me.lblPingAFIPTitulo.Size = New System.Drawing.Size(168, 38)
      Me.lblPingAFIPTitulo.TabIndex = 0
      Me.lblPingAFIPTitulo.Text = "Haciendo ping a Servidor de AFIP"
      Me.lblPingAFIPTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingAFIPWSAA
      '
      Me.lblPingAFIPWSAA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingAFIPWSAA.AutoSize = True
      Me.lblPingAFIPWSAA.Location = New System.Drawing.Point(194, 172)
      Me.lblPingAFIPWSAA.Name = "lblPingAFIPWSAA"
      Me.lblPingAFIPWSAA.Size = New System.Drawing.Size(85, 38)
      Me.lblPingAFIPWSAA.TabIndex = 1
      Me.lblPingAFIPWSAA.Text = "wsaa.afip.gov.ar"
      Me.lblPingAFIPWSAA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'picPingAFIPWSAA
      '
      Me.picPingAFIPWSAA.Location = New System.Drawing.Point(307, 175)
      Me.picPingAFIPWSAA.Name = "picPingAFIPWSAA"
      Me.picPingAFIPWSAA.Size = New System.Drawing.Size(32, 32)
      Me.picPingAFIPWSAA.TabIndex = 3
      Me.picPingAFIPWSAA.TabStop = False
      '
      'lblPingAFIPWSFE
      '
      Me.lblPingAFIPWSFE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblPingAFIPWSFE.AutoSize = True
      Me.lblPingAFIPWSFE.Location = New System.Drawing.Point(194, 210)
      Me.lblPingAFIPWSFE.Name = "lblPingAFIPWSFE"
      Me.lblPingAFIPWSFE.Size = New System.Drawing.Size(107, 38)
      Me.lblPingAFIPWSFE.TabIndex = 1
      Me.lblPingAFIPWSFE.Text = "servicios1.afip.gov.ar"
      Me.lblPingAFIPWSFE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'picPingAFIPWSFE_1
      '
      Me.picPingAFIPWSFE_1.Location = New System.Drawing.Point(307, 213)
      Me.picPingAFIPWSFE_1.Name = "picPingAFIPWSFE_1"
      Me.picPingAFIPWSFE_1.Size = New System.Drawing.Size(32, 32)
      Me.picPingAFIPWSFE_1.TabIndex = 3
      Me.picPingAFIPWSFE_1.TabStop = False
      '
      'lblSharedFoldersTitulo
      '
      Me.lblSharedFoldersTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblSharedFoldersTitulo.AutoSize = True
      Me.lblSharedFoldersTitulo.Location = New System.Drawing.Point(3, 58)
      Me.lblSharedFoldersTitulo.Name = "lblSharedFoldersTitulo"
      Me.lblSharedFoldersTitulo.Size = New System.Drawing.Size(166, 38)
      Me.lblSharedFoldersTitulo.TabIndex = 0
      Me.lblSharedFoldersTitulo.Text = "Carpetas compartidas del servidor"
      Me.lblSharedFoldersTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblSharedFolders
      '
      Me.lblSharedFolders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblSharedFolders.AutoSize = True
      Me.lblSharedFolders.Location = New System.Drawing.Point(194, 58)
      Me.lblSharedFolders.Name = "lblSharedFolders"
      Me.lblSharedFolders.Size = New System.Drawing.Size(94, 38)
      Me.lblSharedFolders.TabIndex = 1
      Me.lblSharedFolders.Text = "{Nombre Servidor}"
      Me.lblSharedFolders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'picSharedFolders
      '
      Me.picSharedFolders.Location = New System.Drawing.Point(307, 61)
      Me.picSharedFolders.Name = "picSharedFolders"
      Me.picSharedFolders.Size = New System.Drawing.Size(32, 32)
      Me.picSharedFolders.TabIndex = 3
      Me.picSharedFolders.TabStop = False
      '
      'picPingAFIPWSFE_2
      '
      Me.picPingAFIPWSFE_2.Location = New System.Drawing.Point(307, 251)
      Me.picPingAFIPWSFE_2.Name = "picPingAFIPWSFE_2"
      Me.picPingAFIPWSFE_2.Size = New System.Drawing.Size(32, 32)
      Me.picPingAFIPWSFE_2.TabIndex = 3
      Me.picPingAFIPWSFE_2.TabStop = False
      '
      'picPingAFIPWSFE_3
      '
      Me.picPingAFIPWSFE_3.Location = New System.Drawing.Point(307, 289)
      Me.picPingAFIPWSFE_3.Name = "picPingAFIPWSFE_3"
      Me.picPingAFIPWSFE_3.Size = New System.Drawing.Size(32, 32)
      Me.picPingAFIPWSFE_3.TabIndex = 3
      Me.picPingAFIPWSFE_3.TabStop = False
      '
      'lblPingAFIP1Titulo
      '
      Me.lblPingAFIP1Titulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPingAFIP1Titulo.AutoSize = True
      Me.lblPingAFIP1Titulo.Location = New System.Drawing.Point(123, 210)
      Me.lblPingAFIP1Titulo.Name = "lblPingAFIP1Titulo"
      Me.lblPingAFIP1Titulo.Size = New System.Drawing.Size(65, 38)
      Me.lblPingAFIP1Titulo.TabIndex = 0
      Me.lblPingAFIP1Titulo.Text = "Autorización"
      Me.lblPingAFIP1Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingAFIP2Titulo
      '
      Me.lblPingAFIP2Titulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPingAFIP2Titulo.AutoSize = True
      Me.lblPingAFIP2Titulo.Location = New System.Drawing.Point(121, 248)
      Me.lblPingAFIP2Titulo.Name = "lblPingAFIP2Titulo"
      Me.lblPingAFIP2Titulo.Size = New System.Drawing.Size(67, 38)
      Me.lblPingAFIP2Titulo.TabIndex = 0
      Me.lblPingAFIP2Titulo.Text = "Aplicaciones"
      Me.lblPingAFIP2Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPingAFIP3Titulo
      '
      Me.lblPingAFIP3Titulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPingAFIP3Titulo.AutoSize = True
      Me.lblPingAFIP3Titulo.Location = New System.Drawing.Point(113, 286)
      Me.lblPingAFIP3Titulo.Name = "lblPingAFIP3Titulo"
      Me.lblPingAFIP3Titulo.Size = New System.Drawing.Size(75, 38)
      Me.lblPingAFIP3Titulo.TabIndex = 0
      Me.lblPingAFIP3Titulo.Text = "Base de datos"
      Me.lblPingAFIP3Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema1
      '
      Me.lblProblema1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema1.AutoSize = True
      Me.lblProblema1.Location = New System.Drawing.Point(345, 20)
      Me.lblProblema1.Name = "lblProblema1"
      Me.lblProblema1.Size = New System.Drawing.Size(273, 38)
      Me.lblProblema1.TabIndex = 0
      Me.lblProblema1.Text = "El servidor no está accesible. Existe un problema de red."
      Me.lblProblema1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema4
      '
      Me.lblProblema4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema4.AutoSize = True
      Me.lblProblema4.Location = New System.Drawing.Point(345, 134)
      Me.lblProblema4.Name = "lblProblema4"
      Me.lblProblema4.Size = New System.Drawing.Size(269, 38)
      Me.lblProblema4.TabIndex = 0
      Me.lblProblema4.Text = "No tiene acceso a Internet o existe un problema de red."
      Me.lblProblema4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema5
      '
      Me.lblProblema5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema5.AutoSize = True
      Me.lblProblema5.Location = New System.Drawing.Point(345, 172)
      Me.lblProblema5.Name = "lblProblema5"
      Me.lblProblema5.Size = New System.Drawing.Size(253, 38)
      Me.lblProblema5.TabIndex = 0
      Me.lblProblema5.Text = "Los servicios de AFIP no se encuentran disponibles."
      Me.lblProblema5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema3
      '
      Me.lblProblema3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema3.AutoSize = True
      Me.lblProblema3.Location = New System.Drawing.Point(345, 96)
      Me.lblProblema3.Name = "lblProblema3"
      Me.lblProblema3.Size = New System.Drawing.Size(231, 38)
      Me.lblProblema3.TabIndex = 0
      Me.lblProblema3.Text = "La base de datos de la aplicación no responde."
      Me.lblProblema3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label12
      '
      Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
      Me.Label12.AutoSize = True
      Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label12.Location = New System.Drawing.Point(458, 0)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(59, 20)
      Me.Label12.TabIndex = 0
      Me.Label12.Text = "Problema"
      Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label13
      '
      Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
      Me.Label13.AutoSize = True
      Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label13.Location = New System.Drawing.Point(701, 0)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(102, 20)
      Me.Label13.TabIndex = 0
      Me.Label13.Text = "Acción a realizar"
      Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion1
      '
      Me.lblAccion1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion1.AutoSize = True
      Me.lblAccion1.Location = New System.Drawing.Point(636, 20)
      Me.lblAccion1.Name = "lblAccion1"
      Me.lblAccion1.Size = New System.Drawing.Size(179, 38)
      Me.lblAccion1.TabIndex = 0
      Me.lblAccion1.Text = "Comuniquese con su técnico de PC."
      Me.lblAccion1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema2
      '
      Me.lblProblema2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema2.AutoSize = True
      Me.lblProblema2.Location = New System.Drawing.Point(345, 58)
      Me.lblProblema2.Name = "lblProblema2"
      Me.lblProblema2.Size = New System.Drawing.Size(273, 38)
      Me.lblProblema2.TabIndex = 0
      Me.lblProblema2.Text = "El servidor no está accesible. Existe un problema de red."
      Me.lblProblema2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion2
      '
      Me.lblAccion2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion2.AutoSize = True
      Me.lblAccion2.Location = New System.Drawing.Point(636, 58)
      Me.lblAccion2.Name = "lblAccion2"
      Me.lblAccion2.Size = New System.Drawing.Size(179, 38)
      Me.lblAccion2.TabIndex = 0
      Me.lblAccion2.Text = "Comuniquese con su técnico de PC."
      Me.lblAccion2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion4
      '
      Me.lblAccion4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion4.AutoSize = True
      Me.lblAccion4.Location = New System.Drawing.Point(636, 134)
      Me.lblAccion4.Name = "lblAccion4"
      Me.lblAccion4.Size = New System.Drawing.Size(232, 38)
      Me.lblAccion4.TabIndex = 0
      Me.lblAccion4.Text = "Reintente en unos minutos o comuniquese con su técnico de PC."
      Me.lblAccion4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion3
      '
      Me.lblAccion3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion3.AutoSize = True
      Me.lblAccion3.Location = New System.Drawing.Point(636, 96)
      Me.lblAccion3.Name = "lblAccion3"
      Me.lblAccion3.Size = New System.Drawing.Size(178, 38)
      Me.lblAccion3.TabIndex = 0
      Me.lblAccion3.Text = "Comuniquese con Sinergia Software"
      Me.lblAccion3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion5
      '
      Me.lblAccion5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion5.AutoSize = True
      Me.lblAccion5.Location = New System.Drawing.Point(636, 172)
      Me.lblAccion5.Name = "lblAccion5"
      Me.lblAccion5.Size = New System.Drawing.Size(139, 38)
      Me.lblAccion5.TabIndex = 0
      Me.lblAccion5.Text = "Reintentar en unos minutos."
      Me.lblAccion5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion6
      '
      Me.lblAccion6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion6.AutoSize = True
      Me.lblAccion6.Location = New System.Drawing.Point(636, 210)
      Me.lblAccion6.Name = "lblAccion6"
      Me.lblAccion6.Size = New System.Drawing.Size(139, 38)
      Me.lblAccion6.TabIndex = 0
      Me.lblAccion6.Text = "Reintentar en unos minutos."
      Me.lblAccion6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion7
      '
      Me.lblAccion7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion7.AutoSize = True
      Me.lblAccion7.Location = New System.Drawing.Point(636, 248)
      Me.lblAccion7.Name = "lblAccion7"
      Me.lblAccion7.Size = New System.Drawing.Size(139, 38)
      Me.lblAccion7.TabIndex = 0
      Me.lblAccion7.Text = "Reintentar en unos minutos."
      Me.lblAccion7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAccion8
      '
      Me.lblAccion8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblAccion8.AutoSize = True
      Me.lblAccion8.Location = New System.Drawing.Point(636, 286)
      Me.lblAccion8.Name = "lblAccion8"
      Me.lblAccion8.Size = New System.Drawing.Size(139, 38)
      Me.lblAccion8.TabIndex = 0
      Me.lblAccion8.Text = "Reintentar en unos minutos."
      Me.lblAccion8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema6
      '
      Me.lblProblema6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema6.AutoSize = True
      Me.lblProblema6.Location = New System.Drawing.Point(345, 210)
      Me.lblProblema6.Name = "lblProblema6"
      Me.lblProblema6.Size = New System.Drawing.Size(253, 38)
      Me.lblProblema6.TabIndex = 0
      Me.lblProblema6.Text = "Los servicios de AFIP no se encuentran disponibles."
      Me.lblProblema6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema7
      '
      Me.lblProblema7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema7.AutoSize = True
      Me.lblProblema7.Location = New System.Drawing.Point(345, 248)
      Me.lblProblema7.Name = "lblProblema7"
      Me.lblProblema7.Size = New System.Drawing.Size(253, 38)
      Me.lblProblema7.TabIndex = 0
      Me.lblProblema7.Text = "Los servicios de AFIP no se encuentran disponibles."
      Me.lblProblema7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblProblema8
      '
      Me.lblProblema8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblProblema8.AutoSize = True
      Me.lblProblema8.Location = New System.Drawing.Point(345, 286)
      Me.lblProblema8.Name = "lblProblema8"
      Me.lblProblema8.Size = New System.Drawing.Size(253, 38)
      Me.lblProblema8.TabIndex = 0
      Me.lblProblema8.Text = "Los servicios de AFIP no se encuentran disponibles."
      Me.lblProblema8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ImageList1
      '
      Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
      Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.btnVerificar)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel1.Location = New System.Drawing.Point(0, 327)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(872, 35)
      Me.Panel1.TabIndex = 2
      '
      'frmVerificarRed
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(872, 362)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.Controls.Add(Me.Panel1)
      Me.Name = "frmVerificarRed"
      Me.Text = "Diagnóstico estado de red"
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      CType(Me.picPingServidor, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPingSQLServer, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPingGoogle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPingAFIPWSAA, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPingAFIPWSFE_1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picSharedFolders, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPingAFIPWSFE_2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.picPingAFIPWSFE_3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnVerificar As System.Windows.Forms.Button
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents lblPingServidorTitulo As System.Windows.Forms.Label
   Friend WithEvents lblPingServidor As System.Windows.Forms.Label
   Friend WithEvents lblPingSQLServerTitulo As System.Windows.Forms.Label
   Friend WithEvents lblPingSQLServer As System.Windows.Forms.Label
   Friend WithEvents picPingServidor As System.Windows.Forms.PictureBox
   Friend WithEvents picPingSQLServer As System.Windows.Forms.PictureBox
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents lblPingGoogleTitulo As System.Windows.Forms.Label
   Friend WithEvents lblPingGoogle As System.Windows.Forms.Label
   Friend WithEvents picPingGoogle As System.Windows.Forms.PictureBox
   Friend WithEvents lblPingAFIPTitulo As System.Windows.Forms.Label
   Friend WithEvents lblPingAFIPWSAA As System.Windows.Forms.Label
   Friend WithEvents picPingAFIPWSAA As System.Windows.Forms.PictureBox
   Friend WithEvents lblPingAFIPWSFE As System.Windows.Forms.Label
   Friend WithEvents picPingAFIPWSFE_1 As System.Windows.Forms.PictureBox
   Friend WithEvents lblSharedFoldersTitulo As System.Windows.Forms.Label
   Friend WithEvents lblSharedFolders As System.Windows.Forms.Label
   Friend WithEvents picSharedFolders As System.Windows.Forms.PictureBox
   Friend WithEvents picPingAFIPWSFE_2 As System.Windows.Forms.PictureBox
   Friend WithEvents picPingAFIPWSFE_3 As System.Windows.Forms.PictureBox
   Friend WithEvents lblPingAFIP1Titulo As System.Windows.Forms.Label
   Friend WithEvents lblPingAFIP2Titulo As System.Windows.Forms.Label
   Friend WithEvents lblPingAFIP3Titulo As System.Windows.Forms.Label
   Friend WithEvents lblProblema1 As System.Windows.Forms.Label
   Friend WithEvents lblProblema4 As System.Windows.Forms.Label
   Friend WithEvents lblProblema5 As System.Windows.Forms.Label
   Friend WithEvents lblProblema3 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents lblAccion1 As System.Windows.Forms.Label
   Friend WithEvents lblProblema2 As System.Windows.Forms.Label
   Friend WithEvents lblAccion2 As System.Windows.Forms.Label
   Friend WithEvents lblAccion4 As System.Windows.Forms.Label
   Friend WithEvents lblAccion3 As System.Windows.Forms.Label
   Friend WithEvents lblAccion5 As System.Windows.Forms.Label
   Friend WithEvents lblAccion6 As System.Windows.Forms.Label
   Friend WithEvents lblAccion7 As System.Windows.Forms.Label
   Friend WithEvents lblAccion8 As System.Windows.Forms.Label
   Friend WithEvents lblProblema6 As System.Windows.Forms.Label
   Friend WithEvents lblProblema7 As System.Windows.Forms.Label
   Friend WithEvents lblProblema8 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
