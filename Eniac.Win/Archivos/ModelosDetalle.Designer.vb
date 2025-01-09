<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModelosDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdModelo = New Eniac.Controles.TextBox()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.bscCodigoMarca = New Eniac.Controles.Buscador()
      Me.bscMarca = New Eniac.Controles.Buscador()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(306, 149)
      Me.btnAceptar.TabIndex = 9
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(392, 149)
      Me.btnCancelar.TabIndex = 10
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(205, 149)
      Me.btnCopiar.TabIndex = 12
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(148, 149)
      Me.btnAplicar.TabIndex = 11
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(20, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(20, 20)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'txtIdModelo
      '
      Me.txtIdModelo.BindearPropiedadControl = "Text"
      Me.txtIdModelo.BindearPropiedadEntidad = "IdModelo"
      Me.txtIdModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdModelo.Formato = ""
      Me.txtIdModelo.IsDecimal = False
      Me.txtIdModelo.IsNumber = True
      Me.txtIdModelo.IsPK = True
      Me.txtIdModelo.IsRequired = True
      Me.txtIdModelo.Key = ""
      Me.txtIdModelo.LabelAsoc = Me.lblCodigo
      Me.txtIdModelo.Location = New System.Drawing.Point(79, 16)
      Me.txtIdModelo.MaxLength = 6
      Me.txtIdModelo.Name = "txtIdModelo"
      Me.txtIdModelo.Size = New System.Drawing.Size(59, 20)
      Me.txtIdModelo.TabIndex = 1
      Me.txtIdModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreModelo"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(79, 42)
      Me.txtNombre.MaxLength = 40
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(262, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.LabelAsoc = Nothing
      Me.lblMarca.Location = New System.Drawing.Point(20, 70)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(37, 13)
      Me.lblMarca.TabIndex = 4
      Me.lblMarca.Text = "Marca"
      '
      'bscCodigoMarca
      '
      Me.bscCodigoMarca.AyudaAncho = 608
      Me.bscCodigoMarca.BindearPropiedadControl = "Text"
      Me.bscCodigoMarca.BindearPropiedadEntidad = "IdMarca"
      Me.bscCodigoMarca.ColumnasAlineacion = Nothing
      Me.bscCodigoMarca.ColumnasAncho = Nothing
      Me.bscCodigoMarca.ColumnasFormato = Nothing
      Me.bscCodigoMarca.ColumnasOcultas = Nothing
      Me.bscCodigoMarca.ColumnasTitulos = Nothing
      Me.bscCodigoMarca.Datos = Nothing
      Me.bscCodigoMarca.FilaDevuelta = Nothing
      Me.bscCodigoMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoMarca.IsDecimal = False
      Me.bscCodigoMarca.IsNumber = True
      Me.bscCodigoMarca.IsPK = True
      Me.bscCodigoMarca.IsRequired = True
      Me.bscCodigoMarca.Key = ""
      Me.bscCodigoMarca.LabelAsoc = Me.lblMarca
      Me.bscCodigoMarca.Location = New System.Drawing.Point(79, 68)
      Me.bscCodigoMarca.MaxLengh = "32767"
      Me.bscCodigoMarca.Name = "bscCodigoMarca"
      Me.bscCodigoMarca.Permitido = True
      Me.bscCodigoMarca.Selecciono = False
      Me.bscCodigoMarca.Size = New System.Drawing.Size(91, 20)
      Me.bscCodigoMarca.TabIndex = 5
      Me.bscCodigoMarca.Titulo = Nothing
      '
      'bscMarca
      '
      Me.bscMarca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscMarca.AyudaAncho = 608
      Me.bscMarca.BindearPropiedadControl = Nothing
      Me.bscMarca.BindearPropiedadEntidad = Nothing
      Me.bscMarca.ColumnasAlineacion = Nothing
      Me.bscMarca.ColumnasAncho = Nothing
      Me.bscMarca.ColumnasFormato = Nothing
      Me.bscMarca.ColumnasOcultas = Nothing
      Me.bscMarca.ColumnasTitulos = Nothing
      Me.bscMarca.Datos = Nothing
      Me.bscMarca.FilaDevuelta = Nothing
      Me.bscMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.bscMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscMarca.IsDecimal = False
      Me.bscMarca.IsNumber = False
      Me.bscMarca.IsPK = True
      Me.bscMarca.IsRequired = True
      Me.bscMarca.Key = ""
      Me.bscMarca.LabelAsoc = Me.lblMarca
      Me.bscMarca.Location = New System.Drawing.Point(174, 67)
      Me.bscMarca.MaxLengh = "32767"
      Me.bscMarca.Name = "bscMarca"
      Me.bscMarca.Permitido = True
      Me.bscMarca.Selecciono = False
      Me.bscMarca.Size = New System.Drawing.Size(294, 20)
      Me.bscMarca.TabIndex = 6
      Me.bscMarca.Titulo = Nothing
      '
      'txtOrden
      '
      Me.txtOrden.BindearPropiedadControl = "Text"
      Me.txtOrden.BindearPropiedadEntidad = "Orden"
      Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOrden.Formato = ""
      Me.txtOrden.IsDecimal = False
      Me.txtOrden.IsNumber = True
      Me.txtOrden.IsPK = False
      Me.txtOrden.IsRequired = True
      Me.txtOrden.Key = ""
      Me.txtOrden.LabelAsoc = Me.lblOrden
      Me.txtOrden.Location = New System.Drawing.Point(79, 94)
      Me.txtOrden.MaxLength = 6
      Me.txtOrden.Name = "txtOrden"
      Me.txtOrden.Size = New System.Drawing.Size(59, 20)
      Me.txtOrden.TabIndex = 8
      Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.LabelAsoc = Nothing
      Me.lblOrden.Location = New System.Drawing.Point(20, 97)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(36, 13)
      Me.lblOrden.TabIndex = 7
      Me.lblOrden.Text = "Orden"
      '
      'ModelosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(481, 184)
      Me.Controls.Add(Me.txtOrden)
      Me.Controls.Add(Me.lblOrden)
      Me.Controls.Add(Me.bscCodigoMarca)
      Me.Controls.Add(Me.bscMarca)
      Me.Controls.Add(Me.lblMarca)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtIdModelo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "ModelosDetalle"
      Me.Text = "Modelo"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtIdModelo, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblMarca, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.bscMarca, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoMarca, 0)
      Me.Controls.SetChildIndex(Me.lblOrden, 0)
      Me.Controls.SetChildIndex(Me.txtOrden, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdModelo As Eniac.Controles.TextBox
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents bscCodigoMarca As Eniac.Controles.Buscador
   Friend WithEvents bscMarca As Eniac.Controles.Buscador
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents lblOrden As Eniac.Controles.Label

End Class
