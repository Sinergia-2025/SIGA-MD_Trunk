<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablerosControlDetalle
   Inherits Win.BaseDetalle

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
      Me.lblIdTabCtrlPanel1 = New Eniac.Controles.Label()
      Me.bscCodigoTabCtrlPnl1 = New Eniac.Controles.Buscador2()
      Me.bscNombrePanel1 = New Eniac.Controles.Buscador2()
      Me.lblNombreTableroControl = New Eniac.Controles.Label()
      Me.txtNombreSubUnidad = New Eniac.Controles.TextBox()
      Me.lblIdTabCtrl = New Eniac.Controles.Label()
      Me.txtIdTableroControl = New Eniac.Controles.TextBox()
      Me.gpBox_PanelControl = New System.Windows.Forms.GroupBox()
        Me.bscNombrePanel6 = New Eniac.Controles.Buscador2()
        Me.lblIdTabCtrlPanel6 = New Eniac.Controles.Label()
        Me.bscCodigoTabCtrlPnl6 = New Eniac.Controles.Buscador2()
        Me.bscNombrePanel5 = New Eniac.Controles.Buscador2()
        Me.lblIdTabCtrlPanel5 = New Eniac.Controles.Label()
        Me.bscNombrePanel4 = New Eniac.Controles.Buscador2()
        Me.lblIdTabCtrlPanel4 = New Eniac.Controles.Label()
        Me.bscCodigoTabCtrlPnl5 = New Eniac.Controles.Buscador2()
        Me.bscCodigoTabCtrlPnl4 = New Eniac.Controles.Buscador2()
        Me.bscNombrePanel3 = New Eniac.Controles.Buscador2()
        Me.lblIdTabCtrlPanel3 = New Eniac.Controles.Label()
        Me.bscCodigoTabCtrlPnl3 = New Eniac.Controles.Buscador2()
        Me.bscNombrePanel2 = New Eniac.Controles.Buscador2()
        Me.lblIdTabCtrlPanel2 = New Eniac.Controles.Label()
        Me.bscCodigoTabCtrlPnl2 = New Eniac.Controles.Buscador2()
        Me.lblControllerFiltro = New Eniac.Controles.Label()
        Me.txtFiltro = New Eniac.Controles.TextBox()
        Me.gpBox_PanelControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(373, 273)
        Me.btnAceptar.TabIndex = 7
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(459, 273)
        Me.btnCancelar.TabIndex = 8
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(272, 273)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(215, 273)
        Me.btnAplicar.TabIndex = 10
        '
        'lblIdTabCtrlPanel1
        '
        Me.lblIdTabCtrlPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrlPanel1.AutoSize = True
        Me.lblIdTabCtrlPanel1.LabelAsoc = Nothing
        Me.lblIdTabCtrlPanel1.Location = New System.Drawing.Point(10, 19)
        Me.lblIdTabCtrlPanel1.Name = "lblIdTabCtrlPanel1"
        Me.lblIdTabCtrlPanel1.Size = New System.Drawing.Size(49, 13)
        Me.lblIdTabCtrlPanel1.TabIndex = 0
        Me.lblIdTabCtrlPanel1.Text = "Código 1"
        '
        'bscCodigoTabCtrlPnl1
        '
        Me.bscCodigoTabCtrlPnl1.ActivarFiltroEnGrilla = True
        Me.bscCodigoTabCtrlPnl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoTabCtrlPnl1.BindearPropiedadControl = ""
        Me.bscCodigoTabCtrlPnl1.BindearPropiedadEntidad = ""
        Me.bscCodigoTabCtrlPnl1.ConfigBuscador = Nothing
        Me.bscCodigoTabCtrlPnl1.Datos = Nothing
        Me.bscCodigoTabCtrlPnl1.FilaDevuelta = Nothing
        Me.bscCodigoTabCtrlPnl1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTabCtrlPnl1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTabCtrlPnl1.IsDecimal = False
        Me.bscCodigoTabCtrlPnl1.IsNumber = True
        Me.bscCodigoTabCtrlPnl1.IsPK = False
        Me.bscCodigoTabCtrlPnl1.IsRequired = True
        Me.bscCodigoTabCtrlPnl1.Key = ""
        Me.bscCodigoTabCtrlPnl1.LabelAsoc = Me.lblIdTabCtrlPanel1
        Me.bscCodigoTabCtrlPnl1.Location = New System.Drawing.Point(79, 19)
        Me.bscCodigoTabCtrlPnl1.MaxLengh = "32767"
        Me.bscCodigoTabCtrlPnl1.Name = "bscCodigoTabCtrlPnl1"
        Me.bscCodigoTabCtrlPnl1.Permitido = True
        Me.bscCodigoTabCtrlPnl1.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoTabCtrlPnl1.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl1.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoTabCtrlPnl1.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl1.Selecciono = False
        Me.bscCodigoTabCtrlPnl1.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoTabCtrlPnl1.TabIndex = 1
        '
        'bscNombrePanel1
        '
        Me.bscNombrePanel1.ActivarFiltroEnGrilla = True
        Me.bscNombrePanel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscNombrePanel1.BindearPropiedadControl = Nothing
        Me.bscNombrePanel1.BindearPropiedadEntidad = ""
        Me.bscNombrePanel1.ConfigBuscador = Nothing
        Me.bscNombrePanel1.Datos = Nothing
        Me.bscNombrePanel1.FilaDevuelta = Nothing
        Me.bscNombrePanel1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePanel1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePanel1.IsDecimal = False
        Me.bscNombrePanel1.IsNumber = False
        Me.bscNombrePanel1.IsPK = False
        Me.bscNombrePanel1.IsRequired = True
        Me.bscNombrePanel1.Key = ""
        Me.bscNombrePanel1.LabelAsoc = Me.lblIdTabCtrlPanel1
        Me.bscNombrePanel1.Location = New System.Drawing.Point(203, 19)
        Me.bscNombrePanel1.MaxLengh = "32767"
        Me.bscNombrePanel1.Name = "bscNombrePanel1"
        Me.bscNombrePanel1.Permitido = True
        Me.bscNombrePanel1.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombrePanel1.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel1.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombrePanel1.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel1.Selecciono = False
        Me.bscNombrePanel1.Size = New System.Drawing.Size(312, 29)
        Me.bscNombrePanel1.TabIndex = 2
        '
        'lblNombreTableroControl
        '
        Me.lblNombreTableroControl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombreTableroControl.AutoSize = True
        Me.lblNombreTableroControl.LabelAsoc = Nothing
        Me.lblNombreTableroControl.Location = New System.Drawing.Point(153, 18)
        Me.lblNombreTableroControl.Name = "lblNombreTableroControl"
        Me.lblNombreTableroControl.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreTableroControl.TabIndex = 2
        Me.lblNombreTableroControl.Text = "Nombre"
        '
        'txtNombreSubUnidad
        '
        Me.txtNombreSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreSubUnidad.BindearPropiedadControl = "Text"
        Me.txtNombreSubUnidad.BindearPropiedadEntidad = "NombreTableroControl"
        Me.txtNombreSubUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreSubUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreSubUnidad.Formato = ""
        Me.txtNombreSubUnidad.IsDecimal = False
        Me.txtNombreSubUnidad.IsNumber = False
        Me.txtNombreSubUnidad.IsPK = False
        Me.txtNombreSubUnidad.IsRequired = True
        Me.txtNombreSubUnidad.Key = ""
        Me.txtNombreSubUnidad.LabelAsoc = Me.lblNombreTableroControl
        Me.txtNombreSubUnidad.Location = New System.Drawing.Point(203, 15)
        Me.txtNombreSubUnidad.MaxLength = 50
        Me.txtNombreSubUnidad.Name = "txtNombreSubUnidad"
        Me.txtNombreSubUnidad.Size = New System.Drawing.Size(297, 20)
        Me.txtNombreSubUnidad.TabIndex = 3
        '
        'lblIdTabCtrl
        '
        Me.lblIdTabCtrl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrl.AutoSize = True
        Me.lblIdTabCtrl.LabelAsoc = Nothing
        Me.lblIdTabCtrl.Location = New System.Drawing.Point(22, 18)
        Me.lblIdTabCtrl.Name = "lblIdTabCtrl"
        Me.lblIdTabCtrl.Size = New System.Drawing.Size(40, 13)
        Me.lblIdTabCtrl.TabIndex = 0
        Me.lblIdTabCtrl.Text = "Código"
        '
        'txtIdTableroControl
        '
        Me.txtIdTableroControl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIdTableroControl.BindearPropiedadControl = "Text"
        Me.txtIdTableroControl.BindearPropiedadEntidad = "IdTableroControl"
        Me.txtIdTableroControl.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdTableroControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdTableroControl.Formato = ""
        Me.txtIdTableroControl.IsDecimal = False
        Me.txtIdTableroControl.IsNumber = True
        Me.txtIdTableroControl.IsPK = True
        Me.txtIdTableroControl.IsRequired = True
        Me.txtIdTableroControl.Key = ""
        Me.txtIdTableroControl.LabelAsoc = Me.lblIdTabCtrl
        Me.txtIdTableroControl.Location = New System.Drawing.Point(68, 15)
        Me.txtIdTableroControl.MaxLength = 4
        Me.txtIdTableroControl.Name = "txtIdTableroControl"
        Me.txtIdTableroControl.Size = New System.Drawing.Size(77, 20)
        Me.txtIdTableroControl.TabIndex = 1
        Me.txtIdTableroControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpBox_PanelControl
        '
        Me.gpBox_PanelControl.Controls.Add(Me.bscNombrePanel6)
        Me.gpBox_PanelControl.Controls.Add(Me.lblIdTabCtrlPanel6)
        Me.gpBox_PanelControl.Controls.Add(Me.bscCodigoTabCtrlPnl6)
        Me.gpBox_PanelControl.Controls.Add(Me.bscNombrePanel5)
        Me.gpBox_PanelControl.Controls.Add(Me.bscNombrePanel4)
        Me.gpBox_PanelControl.Controls.Add(Me.lblIdTabCtrlPanel5)
        Me.gpBox_PanelControl.Controls.Add(Me.bscCodigoTabCtrlPnl5)
        Me.gpBox_PanelControl.Controls.Add(Me.lblIdTabCtrlPanel4)
        Me.gpBox_PanelControl.Controls.Add(Me.bscCodigoTabCtrlPnl4)
        Me.gpBox_PanelControl.Controls.Add(Me.bscNombrePanel3)
        Me.gpBox_PanelControl.Controls.Add(Me.lblIdTabCtrlPanel3)
        Me.gpBox_PanelControl.Controls.Add(Me.bscCodigoTabCtrlPnl3)
        Me.gpBox_PanelControl.Controls.Add(Me.bscNombrePanel2)
        Me.gpBox_PanelControl.Controls.Add(Me.lblIdTabCtrlPanel2)
        Me.gpBox_PanelControl.Controls.Add(Me.bscCodigoTabCtrlPnl2)
        Me.gpBox_PanelControl.Controls.Add(Me.bscNombrePanel1)
        Me.gpBox_PanelControl.Controls.Add(Me.lblIdTabCtrlPanel1)
        Me.gpBox_PanelControl.Controls.Add(Me.bscCodigoTabCtrlPnl1)
        Me.gpBox_PanelControl.Location = New System.Drawing.Point(12, 45)
        Me.gpBox_PanelControl.Name = "gpBox_PanelControl"
        Me.gpBox_PanelControl.Size = New System.Drawing.Size(526, 183)
        Me.gpBox_PanelControl.TabIndex = 4
        Me.gpBox_PanelControl.TabStop = False
        Me.gpBox_PanelControl.Text = "Panel de Control"
        '
        'bscNombrePanel6
        '
        Me.bscNombrePanel6.ActivarFiltroEnGrilla = True
        Me.bscNombrePanel6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscNombrePanel6.BindearPropiedadControl = Nothing
        Me.bscNombrePanel6.BindearPropiedadEntidad = ""
        Me.bscNombrePanel6.ConfigBuscador = Nothing
        Me.bscNombrePanel6.Datos = Nothing
        Me.bscNombrePanel6.FilaDevuelta = Nothing
        Me.bscNombrePanel6.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePanel6.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePanel6.IsDecimal = False
        Me.bscNombrePanel6.IsNumber = False
        Me.bscNombrePanel6.IsPK = False
        Me.bscNombrePanel6.IsRequired = False
        Me.bscNombrePanel6.Key = ""
        Me.bscNombrePanel6.LabelAsoc = Me.lblIdTabCtrlPanel6
        Me.bscNombrePanel6.Location = New System.Drawing.Point(203, 146)
        Me.bscNombrePanel6.MaxLengh = "32767"
        Me.bscNombrePanel6.Name = "bscNombrePanel6"
        Me.bscNombrePanel6.Permitido = True
        Me.bscNombrePanel6.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombrePanel6.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel6.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombrePanel6.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel6.Selecciono = False
        Me.bscNombrePanel6.Size = New System.Drawing.Size(312, 20)
        Me.bscNombrePanel6.TabIndex = 17
        '
        'lblIdTabCtrlPanel6
        '
        Me.lblIdTabCtrlPanel6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrlPanel6.AutoSize = True
        Me.lblIdTabCtrlPanel6.LabelAsoc = Nothing
        Me.lblIdTabCtrlPanel6.Location = New System.Drawing.Point(10, 146)
        Me.lblIdTabCtrlPanel6.Name = "lblIdTabCtrlPanel6"
        Me.lblIdTabCtrlPanel6.Size = New System.Drawing.Size(49, 13)
        Me.lblIdTabCtrlPanel6.TabIndex = 15
        Me.lblIdTabCtrlPanel6.Text = "Código 6"
        '
        'bscCodigoTabCtrlPnl6
        '
        Me.bscCodigoTabCtrlPnl6.ActivarFiltroEnGrilla = True
        Me.bscCodigoTabCtrlPnl6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoTabCtrlPnl6.BindearPropiedadControl = ""
        Me.bscCodigoTabCtrlPnl6.BindearPropiedadEntidad = ""
        Me.bscCodigoTabCtrlPnl6.ConfigBuscador = Nothing
        Me.bscCodigoTabCtrlPnl6.Datos = Nothing
        Me.bscCodigoTabCtrlPnl6.FilaDevuelta = Nothing
        Me.bscCodigoTabCtrlPnl6.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTabCtrlPnl6.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTabCtrlPnl6.IsDecimal = False
        Me.bscCodigoTabCtrlPnl6.IsNumber = True
        Me.bscCodigoTabCtrlPnl6.IsPK = False
        Me.bscCodigoTabCtrlPnl6.IsRequired = False
        Me.bscCodigoTabCtrlPnl6.Key = ""
        Me.bscCodigoTabCtrlPnl6.LabelAsoc = Me.lblIdTabCtrlPanel6
        Me.bscCodigoTabCtrlPnl6.Location = New System.Drawing.Point(79, 146)
        Me.bscCodigoTabCtrlPnl6.MaxLengh = "32767"
        Me.bscCodigoTabCtrlPnl6.Name = "bscCodigoTabCtrlPnl6"
        Me.bscCodigoTabCtrlPnl6.Permitido = True
        Me.bscCodigoTabCtrlPnl6.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoTabCtrlPnl6.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl6.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoTabCtrlPnl6.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl6.Selecciono = False
        Me.bscCodigoTabCtrlPnl6.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoTabCtrlPnl6.TabIndex = 16
        '
        'bscNombrePanel5
        '
        Me.bscNombrePanel5.ActivarFiltroEnGrilla = True
        Me.bscNombrePanel5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscNombrePanel5.BindearPropiedadControl = Nothing
        Me.bscNombrePanel5.BindearPropiedadEntidad = ""
        Me.bscNombrePanel5.ConfigBuscador = Nothing
        Me.bscNombrePanel5.Datos = Nothing
        Me.bscNombrePanel5.FilaDevuelta = Nothing
        Me.bscNombrePanel5.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePanel5.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePanel5.IsDecimal = False
        Me.bscNombrePanel5.IsNumber = False
        Me.bscNombrePanel5.IsPK = False
        Me.bscNombrePanel5.IsRequired = False
        Me.bscNombrePanel5.Key = ""
        Me.bscNombrePanel5.LabelAsoc = Me.lblIdTabCtrlPanel5
        Me.bscNombrePanel5.Location = New System.Drawing.Point(203, 120)
        Me.bscNombrePanel5.MaxLengh = "32767"
        Me.bscNombrePanel5.Name = "bscNombrePanel5"
        Me.bscNombrePanel5.Permitido = True
        Me.bscNombrePanel5.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombrePanel5.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel5.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombrePanel5.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel5.Selecciono = False
        Me.bscNombrePanel5.Size = New System.Drawing.Size(312, 20)
        Me.bscNombrePanel5.TabIndex = 14
        '
        'lblIdTabCtrlPanel5
        '
        Me.lblIdTabCtrlPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrlPanel5.AutoSize = True
        Me.lblIdTabCtrlPanel5.LabelAsoc = Nothing
        Me.lblIdTabCtrlPanel5.Location = New System.Drawing.Point(10, 120)
        Me.lblIdTabCtrlPanel5.Name = "lblIdTabCtrlPanel5"
        Me.lblIdTabCtrlPanel5.Size = New System.Drawing.Size(49, 13)
        Me.lblIdTabCtrlPanel5.TabIndex = 12
        Me.lblIdTabCtrlPanel5.Text = "Código 5"
        '
        'bscNombrePanel4
        '
        Me.bscNombrePanel4.ActivarFiltroEnGrilla = True
        Me.bscNombrePanel4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscNombrePanel4.BindearPropiedadControl = Nothing
        Me.bscNombrePanel4.BindearPropiedadEntidad = ""
        Me.bscNombrePanel4.ConfigBuscador = Nothing
        Me.bscNombrePanel4.Datos = Nothing
        Me.bscNombrePanel4.FilaDevuelta = Nothing
        Me.bscNombrePanel4.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePanel4.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePanel4.IsDecimal = False
        Me.bscNombrePanel4.IsNumber = False
        Me.bscNombrePanel4.IsPK = False
        Me.bscNombrePanel4.IsRequired = False
        Me.bscNombrePanel4.Key = ""
        Me.bscNombrePanel4.LabelAsoc = Me.lblIdTabCtrlPanel4
        Me.bscNombrePanel4.Location = New System.Drawing.Point(203, 94)
        Me.bscNombrePanel4.MaxLengh = "32767"
        Me.bscNombrePanel4.Name = "bscNombrePanel4"
        Me.bscNombrePanel4.Permitido = True
        Me.bscNombrePanel4.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombrePanel4.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel4.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombrePanel4.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel4.Selecciono = False
        Me.bscNombrePanel4.Size = New System.Drawing.Size(312, 20)
        Me.bscNombrePanel4.TabIndex = 11
        '
        'lblIdTabCtrlPanel4
        '
        Me.lblIdTabCtrlPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrlPanel4.AutoSize = True
        Me.lblIdTabCtrlPanel4.LabelAsoc = Nothing
        Me.lblIdTabCtrlPanel4.Location = New System.Drawing.Point(10, 94)
        Me.lblIdTabCtrlPanel4.Name = "lblIdTabCtrlPanel4"
        Me.lblIdTabCtrlPanel4.Size = New System.Drawing.Size(49, 13)
        Me.lblIdTabCtrlPanel4.TabIndex = 9
        Me.lblIdTabCtrlPanel4.Text = "Código 4"
        '
        'bscCodigoTabCtrlPnl5
        '
        Me.bscCodigoTabCtrlPnl5.ActivarFiltroEnGrilla = True
        Me.bscCodigoTabCtrlPnl5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoTabCtrlPnl5.BindearPropiedadControl = ""
        Me.bscCodigoTabCtrlPnl5.BindearPropiedadEntidad = ""
        Me.bscCodigoTabCtrlPnl5.ConfigBuscador = Nothing
        Me.bscCodigoTabCtrlPnl5.Datos = Nothing
        Me.bscCodigoTabCtrlPnl5.FilaDevuelta = Nothing
        Me.bscCodigoTabCtrlPnl5.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTabCtrlPnl5.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTabCtrlPnl5.IsDecimal = False
        Me.bscCodigoTabCtrlPnl5.IsNumber = True
        Me.bscCodigoTabCtrlPnl5.IsPK = False
        Me.bscCodigoTabCtrlPnl5.IsRequired = False
        Me.bscCodigoTabCtrlPnl5.Key = ""
        Me.bscCodigoTabCtrlPnl5.LabelAsoc = Me.lblIdTabCtrlPanel5
        Me.bscCodigoTabCtrlPnl5.Location = New System.Drawing.Point(79, 120)
        Me.bscCodigoTabCtrlPnl5.MaxLengh = "32767"
        Me.bscCodigoTabCtrlPnl5.Name = "bscCodigoTabCtrlPnl5"
        Me.bscCodigoTabCtrlPnl5.Permitido = True
        Me.bscCodigoTabCtrlPnl5.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoTabCtrlPnl5.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl5.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoTabCtrlPnl5.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl5.Selecciono = False
        Me.bscCodigoTabCtrlPnl5.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoTabCtrlPnl5.TabIndex = 13
        '
        'bscCodigoTabCtrlPnl4
        '
        Me.bscCodigoTabCtrlPnl4.ActivarFiltroEnGrilla = True
        Me.bscCodigoTabCtrlPnl4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoTabCtrlPnl4.BindearPropiedadControl = ""
        Me.bscCodigoTabCtrlPnl4.BindearPropiedadEntidad = ""
        Me.bscCodigoTabCtrlPnl4.ConfigBuscador = Nothing
        Me.bscCodigoTabCtrlPnl4.Datos = Nothing
        Me.bscCodigoTabCtrlPnl4.FilaDevuelta = Nothing
        Me.bscCodigoTabCtrlPnl4.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTabCtrlPnl4.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTabCtrlPnl4.IsDecimal = False
        Me.bscCodigoTabCtrlPnl4.IsNumber = True
        Me.bscCodigoTabCtrlPnl4.IsPK = False
        Me.bscCodigoTabCtrlPnl4.IsRequired = False
        Me.bscCodigoTabCtrlPnl4.Key = ""
        Me.bscCodigoTabCtrlPnl4.LabelAsoc = Me.lblIdTabCtrlPanel4
        Me.bscCodigoTabCtrlPnl4.Location = New System.Drawing.Point(79, 94)
        Me.bscCodigoTabCtrlPnl4.MaxLengh = "32767"
        Me.bscCodigoTabCtrlPnl4.Name = "bscCodigoTabCtrlPnl4"
        Me.bscCodigoTabCtrlPnl4.Permitido = True
        Me.bscCodigoTabCtrlPnl4.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoTabCtrlPnl4.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl4.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoTabCtrlPnl4.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl4.Selecciono = False
        Me.bscCodigoTabCtrlPnl4.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoTabCtrlPnl4.TabIndex = 10
        '
        'bscNombrePanel3
        '
        Me.bscNombrePanel3.ActivarFiltroEnGrilla = True
        Me.bscNombrePanel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscNombrePanel3.BindearPropiedadControl = Nothing
        Me.bscNombrePanel3.BindearPropiedadEntidad = ""
        Me.bscNombrePanel3.ConfigBuscador = Nothing
        Me.bscNombrePanel3.Datos = Nothing
        Me.bscNombrePanel3.FilaDevuelta = Nothing
        Me.bscNombrePanel3.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePanel3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePanel3.IsDecimal = False
        Me.bscNombrePanel3.IsNumber = False
        Me.bscNombrePanel3.IsPK = False
        Me.bscNombrePanel3.IsRequired = False
        Me.bscNombrePanel3.Key = ""
        Me.bscNombrePanel3.LabelAsoc = Me.lblIdTabCtrlPanel3
        Me.bscNombrePanel3.Location = New System.Drawing.Point(203, 68)
        Me.bscNombrePanel3.MaxLengh = "32767"
        Me.bscNombrePanel3.Name = "bscNombrePanel3"
        Me.bscNombrePanel3.Permitido = True
        Me.bscNombrePanel3.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombrePanel3.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel3.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombrePanel3.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel3.Selecciono = False
        Me.bscNombrePanel3.Size = New System.Drawing.Size(312, 20)
        Me.bscNombrePanel3.TabIndex = 8
        '
        'lblIdTabCtrlPanel3
        '
        Me.lblIdTabCtrlPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrlPanel3.AutoSize = True
        Me.lblIdTabCtrlPanel3.LabelAsoc = Nothing
        Me.lblIdTabCtrlPanel3.Location = New System.Drawing.Point(10, 68)
        Me.lblIdTabCtrlPanel3.Name = "lblIdTabCtrlPanel3"
        Me.lblIdTabCtrlPanel3.Size = New System.Drawing.Size(49, 13)
        Me.lblIdTabCtrlPanel3.TabIndex = 6
        Me.lblIdTabCtrlPanel3.Text = "Código 3"
        '
        'bscCodigoTabCtrlPnl3
        '
        Me.bscCodigoTabCtrlPnl3.ActivarFiltroEnGrilla = True
        Me.bscCodigoTabCtrlPnl3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoTabCtrlPnl3.BindearPropiedadControl = ""
        Me.bscCodigoTabCtrlPnl3.BindearPropiedadEntidad = ""
        Me.bscCodigoTabCtrlPnl3.ConfigBuscador = Nothing
        Me.bscCodigoTabCtrlPnl3.Datos = Nothing
        Me.bscCodigoTabCtrlPnl3.FilaDevuelta = Nothing
        Me.bscCodigoTabCtrlPnl3.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTabCtrlPnl3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTabCtrlPnl3.IsDecimal = False
        Me.bscCodigoTabCtrlPnl3.IsNumber = True
        Me.bscCodigoTabCtrlPnl3.IsPK = False
        Me.bscCodigoTabCtrlPnl3.IsRequired = False
        Me.bscCodigoTabCtrlPnl3.Key = ""
        Me.bscCodigoTabCtrlPnl3.LabelAsoc = Me.lblIdTabCtrlPanel3
        Me.bscCodigoTabCtrlPnl3.Location = New System.Drawing.Point(79, 68)
        Me.bscCodigoTabCtrlPnl3.MaxLengh = "32767"
        Me.bscCodigoTabCtrlPnl3.Name = "bscCodigoTabCtrlPnl3"
        Me.bscCodigoTabCtrlPnl3.Permitido = True
        Me.bscCodigoTabCtrlPnl3.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoTabCtrlPnl3.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl3.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoTabCtrlPnl3.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl3.Selecciono = False
        Me.bscCodigoTabCtrlPnl3.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoTabCtrlPnl3.TabIndex = 7
        '
        'bscNombrePanel2
        '
        Me.bscNombrePanel2.ActivarFiltroEnGrilla = True
        Me.bscNombrePanel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscNombrePanel2.BindearPropiedadControl = Nothing
        Me.bscNombrePanel2.BindearPropiedadEntidad = ""
        Me.bscNombrePanel2.ConfigBuscador = Nothing
        Me.bscNombrePanel2.Datos = Nothing
        Me.bscNombrePanel2.FilaDevuelta = Nothing
        Me.bscNombrePanel2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombrePanel2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombrePanel2.IsDecimal = False
        Me.bscNombrePanel2.IsNumber = False
        Me.bscNombrePanel2.IsPK = False
        Me.bscNombrePanel2.IsRequired = False
        Me.bscNombrePanel2.Key = ""
        Me.bscNombrePanel2.LabelAsoc = Me.lblIdTabCtrlPanel2
        Me.bscNombrePanel2.Location = New System.Drawing.Point(203, 43)
        Me.bscNombrePanel2.MaxLengh = "32767"
        Me.bscNombrePanel2.Name = "bscNombrePanel2"
        Me.bscNombrePanel2.Permitido = True
        Me.bscNombrePanel2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombrePanel2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombrePanel2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombrePanel2.Selecciono = False
        Me.bscNombrePanel2.Size = New System.Drawing.Size(312, 20)
        Me.bscNombrePanel2.TabIndex = 5
        '
        'lblIdTabCtrlPanel2
        '
        Me.lblIdTabCtrlPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdTabCtrlPanel2.AutoSize = True
        Me.lblIdTabCtrlPanel2.LabelAsoc = Nothing
        Me.lblIdTabCtrlPanel2.Location = New System.Drawing.Point(10, 43)
        Me.lblIdTabCtrlPanel2.Name = "lblIdTabCtrlPanel2"
        Me.lblIdTabCtrlPanel2.Size = New System.Drawing.Size(49, 13)
        Me.lblIdTabCtrlPanel2.TabIndex = 3
        Me.lblIdTabCtrlPanel2.Text = "Código 2"
        '
        'bscCodigoTabCtrlPnl2
        '
        Me.bscCodigoTabCtrlPnl2.ActivarFiltroEnGrilla = True
        Me.bscCodigoTabCtrlPnl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoTabCtrlPnl2.BindearPropiedadControl = ""
        Me.bscCodigoTabCtrlPnl2.BindearPropiedadEntidad = ""
        Me.bscCodigoTabCtrlPnl2.ConfigBuscador = Nothing
        Me.bscCodigoTabCtrlPnl2.Datos = Nothing
        Me.bscCodigoTabCtrlPnl2.FilaDevuelta = Nothing
        Me.bscCodigoTabCtrlPnl2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTabCtrlPnl2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTabCtrlPnl2.IsDecimal = False
        Me.bscCodigoTabCtrlPnl2.IsNumber = True
        Me.bscCodigoTabCtrlPnl2.IsPK = False
        Me.bscCodigoTabCtrlPnl2.IsRequired = False
        Me.bscCodigoTabCtrlPnl2.Key = ""
        Me.bscCodigoTabCtrlPnl2.LabelAsoc = Me.lblIdTabCtrlPanel2
        Me.bscCodigoTabCtrlPnl2.Location = New System.Drawing.Point(79, 43)
        Me.bscCodigoTabCtrlPnl2.MaxLengh = "32767"
        Me.bscCodigoTabCtrlPnl2.Name = "bscCodigoTabCtrlPnl2"
        Me.bscCodigoTabCtrlPnl2.Permitido = True
        Me.bscCodigoTabCtrlPnl2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoTabCtrlPnl2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoTabCtrlPnl2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoTabCtrlPnl2.Selecciono = False
        Me.bscCodigoTabCtrlPnl2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoTabCtrlPnl2.TabIndex = 4
        '
        'lblControllerFiltro
        '
        Me.lblControllerFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblControllerFiltro.AutoSize = True
        Me.lblControllerFiltro.LabelAsoc = Nothing
        Me.lblControllerFiltro.Location = New System.Drawing.Point(22, 237)
        Me.lblControllerFiltro.Name = "lblControllerFiltro"
        Me.lblControllerFiltro.Size = New System.Drawing.Size(29, 13)
        Me.lblControllerFiltro.TabIndex = 5
        Me.lblControllerFiltro.Text = "Filtro"
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtFiltro.BindearPropiedadControl = "Text"
        Me.txtFiltro.BindearPropiedadEntidad = "IdControllerFiltro"
        Me.txtFiltro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFiltro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFiltro.Formato = ""
        Me.txtFiltro.IsDecimal = False
        Me.txtFiltro.IsNumber = False
        Me.txtFiltro.IsPK = False
        Me.txtFiltro.IsRequired = False
        Me.txtFiltro.Key = ""
        Me.txtFiltro.LabelAsoc = Me.lblControllerFiltro
        Me.txtFiltro.Location = New System.Drawing.Point(68, 234)
        Me.txtFiltro.MaxLength = 200
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(432, 20)
        Me.txtFiltro.TabIndex = 6
        '
        'TablerosControlDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 315)
        Me.Controls.Add(Me.lblControllerFiltro)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.gpBox_PanelControl)
        Me.Controls.Add(Me.lblNombreTableroControl)
        Me.Controls.Add(Me.txtNombreSubUnidad)
        Me.Controls.Add(Me.txtIdTableroControl)
        Me.Controls.Add(Me.lblIdTabCtrl)
        Me.Name = "TablerosControlDetalle"
        Me.Text = "Control"
        Me.Controls.SetChildIndex(Me.lblIdTabCtrl, 0)
        Me.Controls.SetChildIndex(Me.txtIdTableroControl, 0)
        Me.Controls.SetChildIndex(Me.txtNombreSubUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblNombreTableroControl, 0)
        Me.Controls.SetChildIndex(Me.gpBox_PanelControl, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtFiltro, 0)
        Me.Controls.SetChildIndex(Me.lblControllerFiltro, 0)
        Me.gpBox_PanelControl.ResumeLayout(False)
        Me.gpBox_PanelControl.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdTabCtrlPanel1 As Controles.Label
   Friend WithEvents bscCodigoTabCtrlPnl1 As Controles.Buscador2
   Friend WithEvents bscNombrePanel1 As Controles.Buscador2
   Friend WithEvents lblNombreTableroControl As Controles.Label
   Friend WithEvents txtNombreSubUnidad As Controles.TextBox
   Friend WithEvents lblIdTabCtrl As Controles.Label
   Friend WithEvents txtIdTableroControl As Controles.TextBox
   Friend WithEvents gpBox_PanelControl As GroupBox
   Friend WithEvents bscNombrePanel6 As Controles.Buscador2
   Friend WithEvents lblIdTabCtrlPanel6 As Controles.Label
   Friend WithEvents bscCodigoTabCtrlPnl6 As Controles.Buscador2
   Friend WithEvents bscNombrePanel5 As Controles.Buscador2
   Friend WithEvents lblIdTabCtrlPanel5 As Controles.Label
   Friend WithEvents bscNombrePanel4 As Controles.Buscador2
   Friend WithEvents lblIdTabCtrlPanel4 As Controles.Label
   Friend WithEvents bscCodigoTabCtrlPnl5 As Controles.Buscador2
   Friend WithEvents bscCodigoTabCtrlPnl4 As Controles.Buscador2
   Friend WithEvents bscNombrePanel3 As Controles.Buscador2
   Friend WithEvents lblIdTabCtrlPanel3 As Controles.Label
   Friend WithEvents bscCodigoTabCtrlPnl3 As Controles.Buscador2
   Friend WithEvents bscNombrePanel2 As Controles.Buscador2
   Friend WithEvents lblIdTabCtrlPanel2 As Controles.Label
   Friend WithEvents bscCodigoTabCtrlPnl2 As Controles.Buscador2
   Friend WithEvents lblControllerFiltro As Controles.Label
   Friend WithEvents txtFiltro As Controles.TextBox
End Class
