<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarCitiVentasConfirmacion
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportarCitiVentasConfirmacion))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.grpComprobantes = New System.Windows.Forms.GroupBox()
      Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblCantidadRegistrosComprobantes = New Eniac.Controles.Label()
      Me.txtCantidadRegistrosComprobantes = New Eniac.Controles.TextBox()
      Me.txtRegistrosSeleccionadosComprobantes = New Eniac.Controles.TextBox()
      Me.lblRegistrosSeleccionadosComprobantes = New Eniac.Controles.Label()
      Me.txtRegistrosConErrorComprobantes = New Eniac.Controles.TextBox()
      Me.lblRegistrosConErrorComprobantes = New Eniac.Controles.Label()
      Me.grpAlicuotas = New System.Windows.Forms.GroupBox()
      Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblCantidadRegistrosAlicuotas = New Eniac.Controles.Label()
      Me.txtCantidadRegistrosAlicuotas = New Eniac.Controles.TextBox()
      Me.txtRegistrosSeleccionadosAlicuotas = New Eniac.Controles.TextBox()
      Me.lblRegistrosSeleccionadosAlicuotas = New Eniac.Controles.Label()
      Me.txtRegistrosConErrorAlicuotas = New Eniac.Controles.TextBox()
      Me.lblRegistrosConErrorAlicuotas = New Eniac.Controles.Label()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.grpAnulados = New System.Windows.Forms.GroupBox()
      Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblCantidadRegistrosAnulados = New Eniac.Controles.Label()
      Me.txtCantidadRegistrosAnulados = New Eniac.Controles.TextBox()
      Me.txtRegistrosSeleccionadosAnulados = New Eniac.Controles.TextBox()
      Me.lblRegistrosSeleccionadosAnulados = New Eniac.Controles.Label()
      Me.txtRegistrosConErrorAnulados = New Eniac.Controles.TextBox()
      Me.lblRegistrosConErrorAnulados = New Eniac.Controles.Label()
      Me.txtRegistrosSinSeleccionarComprobantes = New Eniac.Controles.TextBox()
      Me.lblRegistrosSinSeleccionarComprobantes = New Eniac.Controles.Label()
      Me.txtRegistrosSinSeleccionarAlicuotas = New Eniac.Controles.TextBox()
      Me.lblRegistrosSinSeleccionarAlicuotas = New Eniac.Controles.Label()
      Me.txtRegistrosSinSeleccionarAnuladas = New Eniac.Controles.TextBox()
      Me.lblRegistrosSinSeleccionarAnuladas = New Eniac.Controles.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.PictureBox1 = New System.Windows.Forms.PictureBox()
      Me.grpComprobantes.SuspendLayout()
      Me.TableLayoutPanel2.SuspendLayout()
      Me.grpAlicuotas.SuspendLayout()
      Me.TableLayoutPanel3.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.grpAnulados.SuspendLayout()
      Me.TableLayoutPanel4.SuspendLayout()
      Me.Panel2.SuspendLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(0, 0)
      Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 0
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(87, 0)
      Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 1
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'grpComprobantes
      '
      Me.grpComprobantes.Controls.Add(Me.TableLayoutPanel2)
      Me.grpComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grpComprobantes.Location = New System.Drawing.Point(4, 4)
      Me.grpComprobantes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.grpComprobantes.Name = "grpComprobantes"
      Me.grpComprobantes.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.grpComprobantes.Size = New System.Drawing.Size(364, 153)
      Me.grpComprobantes.TabIndex = 0
      Me.grpComprobantes.TabStop = False
      Me.grpComprobantes.Text = "Comprobantes"
      '
      'TableLayoutPanel2
      '
      Me.TableLayoutPanel2.ColumnCount = 2
      Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel2.Controls.Add(Me.lblCantidadRegistrosComprobantes, 0, 0)
      Me.TableLayoutPanel2.Controls.Add(Me.txtCantidadRegistrosComprobantes, 1, 0)
      Me.TableLayoutPanel2.Controls.Add(Me.txtRegistrosSeleccionadosComprobantes, 1, 1)
      Me.TableLayoutPanel2.Controls.Add(Me.txtRegistrosConErrorComprobantes, 1, 3)
      Me.TableLayoutPanel2.Controls.Add(Me.lblRegistrosConErrorComprobantes, 0, 3)
      Me.TableLayoutPanel2.Controls.Add(Me.lblRegistrosSeleccionadosComprobantes, 0, 1)
      Me.TableLayoutPanel2.Controls.Add(Me.txtRegistrosSinSeleccionarComprobantes, 1, 2)
      Me.TableLayoutPanel2.Controls.Add(Me.lblRegistrosSinSeleccionarComprobantes, 0, 2)
      Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 20)
      Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
      Me.TableLayoutPanel2.RowCount = 5
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
      Me.TableLayoutPanel2.Size = New System.Drawing.Size(356, 129)
      Me.TableLayoutPanel2.TabIndex = 0
      '
      'lblCantidadRegistrosComprobantes
      '
      Me.lblCantidadRegistrosComprobantes.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblCantidadRegistrosComprobantes.AutoSize = True
      Me.lblCantidadRegistrosComprobantes.LabelAsoc = Nothing
      Me.lblCantidadRegistrosComprobantes.Location = New System.Drawing.Point(4, 7)
      Me.lblCantidadRegistrosComprobantes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblCantidadRegistrosComprobantes.Name = "lblCantidadRegistrosComprobantes"
      Me.lblCantidadRegistrosComprobantes.Size = New System.Drawing.Size(174, 17)
      Me.lblCantidadRegistrosComprobantes.TabIndex = 0
      Me.lblCantidadRegistrosComprobantes.Text = "Cantidad total de registros"
      '
      'txtCantidadRegistrosComprobantes
      '
      Me.txtCantidadRegistrosComprobantes.BindearPropiedadControl = Nothing
      Me.txtCantidadRegistrosComprobantes.BindearPropiedadEntidad = Nothing
      Me.txtCantidadRegistrosComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadRegistrosComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadRegistrosComprobantes.Formato = "N0"
      Me.txtCantidadRegistrosComprobantes.IsDecimal = True
      Me.txtCantidadRegistrosComprobantes.IsNumber = True
      Me.txtCantidadRegistrosComprobantes.IsPK = False
      Me.txtCantidadRegistrosComprobantes.IsRequired = False
      Me.txtCantidadRegistrosComprobantes.Key = ""
      Me.txtCantidadRegistrosComprobantes.LabelAsoc = Me.lblCantidadRegistrosComprobantes
      Me.txtCantidadRegistrosComprobantes.Location = New System.Drawing.Point(253, 4)
      Me.txtCantidadRegistrosComprobantes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtCantidadRegistrosComprobantes.Name = "txtCantidadRegistrosComprobantes"
      Me.txtCantidadRegistrosComprobantes.ReadOnly = True
      Me.txtCantidadRegistrosComprobantes.Size = New System.Drawing.Size(92, 23)
      Me.txtCantidadRegistrosComprobantes.TabIndex = 1
      Me.txtCantidadRegistrosComprobantes.Text = "0"
      Me.txtCantidadRegistrosComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRegistrosSeleccionadosComprobantes
      '
      Me.txtRegistrosSeleccionadosComprobantes.BindearPropiedadControl = Nothing
      Me.txtRegistrosSeleccionadosComprobantes.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosSeleccionadosComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosSeleccionadosComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosSeleccionadosComprobantes.Formato = "N0"
      Me.txtRegistrosSeleccionadosComprobantes.IsDecimal = True
      Me.txtRegistrosSeleccionadosComprobantes.IsNumber = True
      Me.txtRegistrosSeleccionadosComprobantes.IsPK = False
      Me.txtRegistrosSeleccionadosComprobantes.IsRequired = False
      Me.txtRegistrosSeleccionadosComprobantes.Key = ""
      Me.txtRegistrosSeleccionadosComprobantes.LabelAsoc = Me.lblRegistrosSeleccionadosComprobantes
      Me.txtRegistrosSeleccionadosComprobantes.Location = New System.Drawing.Point(253, 35)
      Me.txtRegistrosSeleccionadosComprobantes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtRegistrosSeleccionadosComprobantes.Name = "txtRegistrosSeleccionadosComprobantes"
      Me.txtRegistrosSeleccionadosComprobantes.ReadOnly = True
      Me.txtRegistrosSeleccionadosComprobantes.Size = New System.Drawing.Size(92, 23)
      Me.txtRegistrosSeleccionadosComprobantes.TabIndex = 3
      Me.txtRegistrosSeleccionadosComprobantes.Text = "0"
      Me.txtRegistrosSeleccionadosComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosSeleccionadosComprobantes
      '
      Me.lblRegistrosSeleccionadosComprobantes.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosSeleccionadosComprobantes.AutoSize = True
      Me.lblRegistrosSeleccionadosComprobantes.LabelAsoc = Nothing
      Me.lblRegistrosSeleccionadosComprobantes.Location = New System.Drawing.Point(4, 38)
      Me.lblRegistrosSeleccionadosComprobantes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosSeleccionadosComprobantes.Name = "lblRegistrosSeleccionadosComprobantes"
      Me.lblRegistrosSeleccionadosComprobantes.Size = New System.Drawing.Size(237, 17)
      Me.lblRegistrosSeleccionadosComprobantes.TabIndex = 2
      Me.lblRegistrosSeleccionadosComprobantes.Text = "Cantidad de registros seleccionados"
      '
      'txtRegistrosConErrorComprobantes
      '
      Me.txtRegistrosConErrorComprobantes.BackColor = System.Drawing.Color.Tomato
      Me.txtRegistrosConErrorComprobantes.BindearPropiedadControl = Nothing
      Me.txtRegistrosConErrorComprobantes.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosConErrorComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRegistrosConErrorComprobantes.ForeColor = System.Drawing.Color.White
      Me.txtRegistrosConErrorComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosConErrorComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosConErrorComprobantes.Formato = "N0"
      Me.txtRegistrosConErrorComprobantes.IsDecimal = True
      Me.txtRegistrosConErrorComprobantes.IsNumber = True
      Me.txtRegistrosConErrorComprobantes.IsPK = False
      Me.txtRegistrosConErrorComprobantes.IsRequired = False
      Me.txtRegistrosConErrorComprobantes.Key = ""
      Me.txtRegistrosConErrorComprobantes.LabelAsoc = Nothing
      Me.txtRegistrosConErrorComprobantes.Location = New System.Drawing.Point(253, 97)
      Me.txtRegistrosConErrorComprobantes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtRegistrosConErrorComprobantes.Name = "txtRegistrosConErrorComprobantes"
      Me.txtRegistrosConErrorComprobantes.ReadOnly = True
      Me.txtRegistrosConErrorComprobantes.Size = New System.Drawing.Size(92, 20)
      Me.txtRegistrosConErrorComprobantes.TabIndex = 5
      Me.txtRegistrosConErrorComprobantes.Text = "0"
      Me.txtRegistrosConErrorComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosConErrorComprobantes
      '
      Me.lblRegistrosConErrorComprobantes.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosConErrorComprobantes.AutoSize = True
      Me.lblRegistrosConErrorComprobantes.LabelAsoc = Nothing
      Me.lblRegistrosConErrorComprobantes.Location = New System.Drawing.Point(4, 98)
      Me.lblRegistrosConErrorComprobantes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosConErrorComprobantes.Name = "lblRegistrosConErrorComprobantes"
      Me.lblRegistrosConErrorComprobantes.Size = New System.Drawing.Size(205, 17)
      Me.lblRegistrosConErrorComprobantes.TabIndex = 4
      Me.lblRegistrosConErrorComprobantes.Text = "Cantidad de registros con error"
      '
      'grpAlicuotas
      '
      Me.grpAlicuotas.Controls.Add(Me.TableLayoutPanel3)
      Me.grpAlicuotas.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grpAlicuotas.Location = New System.Drawing.Point(376, 4)
      Me.grpAlicuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.grpAlicuotas.Name = "grpAlicuotas"
      Me.grpAlicuotas.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.grpAlicuotas.Size = New System.Drawing.Size(364, 153)
      Me.grpAlicuotas.TabIndex = 1
      Me.grpAlicuotas.TabStop = False
      Me.grpAlicuotas.Text = "Alicuotas"
      '
      'TableLayoutPanel3
      '
      Me.TableLayoutPanel3.ColumnCount = 2
      Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel3.Controls.Add(Me.lblCantidadRegistrosAlicuotas, 0, 0)
      Me.TableLayoutPanel3.Controls.Add(Me.txtCantidadRegistrosAlicuotas, 1, 0)
      Me.TableLayoutPanel3.Controls.Add(Me.txtRegistrosSeleccionadosAlicuotas, 1, 1)
      Me.TableLayoutPanel3.Controls.Add(Me.txtRegistrosConErrorAlicuotas, 1, 3)
      Me.TableLayoutPanel3.Controls.Add(Me.lblRegistrosConErrorAlicuotas, 0, 3)
      Me.TableLayoutPanel3.Controls.Add(Me.lblRegistrosSeleccionadosAlicuotas, 0, 1)
      Me.TableLayoutPanel3.Controls.Add(Me.txtRegistrosSinSeleccionarAlicuotas, 1, 2)
      Me.TableLayoutPanel3.Controls.Add(Me.lblRegistrosSinSeleccionarAlicuotas, 0, 2)
      Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 20)
      Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
      Me.TableLayoutPanel3.RowCount = 5
      Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
      Me.TableLayoutPanel3.Size = New System.Drawing.Size(356, 129)
      Me.TableLayoutPanel3.TabIndex = 0
      '
      'lblCantidadRegistrosAlicuotas
      '
      Me.lblCantidadRegistrosAlicuotas.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblCantidadRegistrosAlicuotas.AutoSize = True
      Me.lblCantidadRegistrosAlicuotas.LabelAsoc = Nothing
      Me.lblCantidadRegistrosAlicuotas.Location = New System.Drawing.Point(4, 7)
      Me.lblCantidadRegistrosAlicuotas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblCantidadRegistrosAlicuotas.Name = "lblCantidadRegistrosAlicuotas"
      Me.lblCantidadRegistrosAlicuotas.Size = New System.Drawing.Size(174, 17)
      Me.lblCantidadRegistrosAlicuotas.TabIndex = 0
      Me.lblCantidadRegistrosAlicuotas.Text = "Cantidad total de registros"
      '
      'txtCantidadRegistrosAlicuotas
      '
      Me.txtCantidadRegistrosAlicuotas.BindearPropiedadControl = Nothing
      Me.txtCantidadRegistrosAlicuotas.BindearPropiedadEntidad = Nothing
      Me.txtCantidadRegistrosAlicuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadRegistrosAlicuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadRegistrosAlicuotas.Formato = "N0"
      Me.txtCantidadRegistrosAlicuotas.IsDecimal = True
      Me.txtCantidadRegistrosAlicuotas.IsNumber = True
      Me.txtCantidadRegistrosAlicuotas.IsPK = False
      Me.txtCantidadRegistrosAlicuotas.IsRequired = False
      Me.txtCantidadRegistrosAlicuotas.Key = ""
      Me.txtCantidadRegistrosAlicuotas.LabelAsoc = Me.lblCantidadRegistrosAlicuotas
      Me.txtCantidadRegistrosAlicuotas.Location = New System.Drawing.Point(253, 4)
      Me.txtCantidadRegistrosAlicuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtCantidadRegistrosAlicuotas.Name = "txtCantidadRegistrosAlicuotas"
      Me.txtCantidadRegistrosAlicuotas.ReadOnly = True
      Me.txtCantidadRegistrosAlicuotas.Size = New System.Drawing.Size(92, 23)
      Me.txtCantidadRegistrosAlicuotas.TabIndex = 1
      Me.txtCantidadRegistrosAlicuotas.Text = "0"
      Me.txtCantidadRegistrosAlicuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRegistrosSeleccionadosAlicuotas
      '
      Me.txtRegistrosSeleccionadosAlicuotas.BackColor = System.Drawing.Color.LightYellow
      Me.txtRegistrosSeleccionadosAlicuotas.BindearPropiedadControl = Nothing
      Me.txtRegistrosSeleccionadosAlicuotas.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosSeleccionadosAlicuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosSeleccionadosAlicuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosSeleccionadosAlicuotas.Formato = "N0"
      Me.txtRegistrosSeleccionadosAlicuotas.IsDecimal = True
      Me.txtRegistrosSeleccionadosAlicuotas.IsNumber = True
      Me.txtRegistrosSeleccionadosAlicuotas.IsPK = False
      Me.txtRegistrosSeleccionadosAlicuotas.IsRequired = False
      Me.txtRegistrosSeleccionadosAlicuotas.Key = ""
      Me.txtRegistrosSeleccionadosAlicuotas.LabelAsoc = Me.lblRegistrosSeleccionadosAlicuotas
      Me.txtRegistrosSeleccionadosAlicuotas.Location = New System.Drawing.Point(253, 35)
      Me.txtRegistrosSeleccionadosAlicuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtRegistrosSeleccionadosAlicuotas.Name = "txtRegistrosSeleccionadosAlicuotas"
      Me.txtRegistrosSeleccionadosAlicuotas.ReadOnly = True
      Me.txtRegistrosSeleccionadosAlicuotas.Size = New System.Drawing.Size(92, 23)
      Me.txtRegistrosSeleccionadosAlicuotas.TabIndex = 3
      Me.txtRegistrosSeleccionadosAlicuotas.Text = "0"
      Me.txtRegistrosSeleccionadosAlicuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosSeleccionadosAlicuotas
      '
      Me.lblRegistrosSeleccionadosAlicuotas.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosSeleccionadosAlicuotas.AutoSize = True
      Me.lblRegistrosSeleccionadosAlicuotas.LabelAsoc = Nothing
      Me.lblRegistrosSeleccionadosAlicuotas.Location = New System.Drawing.Point(4, 38)
      Me.lblRegistrosSeleccionadosAlicuotas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosSeleccionadosAlicuotas.Name = "lblRegistrosSeleccionadosAlicuotas"
      Me.lblRegistrosSeleccionadosAlicuotas.Size = New System.Drawing.Size(237, 17)
      Me.lblRegistrosSeleccionadosAlicuotas.TabIndex = 2
      Me.lblRegistrosSeleccionadosAlicuotas.Text = "Cantidad de registros seleccionados"
      '
      'txtRegistrosConErrorAlicuotas
      '
      Me.txtRegistrosConErrorAlicuotas.BackColor = System.Drawing.Color.Tomato
      Me.txtRegistrosConErrorAlicuotas.BindearPropiedadControl = Nothing
      Me.txtRegistrosConErrorAlicuotas.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosConErrorAlicuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRegistrosConErrorAlicuotas.ForeColor = System.Drawing.Color.White
      Me.txtRegistrosConErrorAlicuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosConErrorAlicuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosConErrorAlicuotas.Formato = "N0"
      Me.txtRegistrosConErrorAlicuotas.IsDecimal = True
      Me.txtRegistrosConErrorAlicuotas.IsNumber = True
      Me.txtRegistrosConErrorAlicuotas.IsPK = False
      Me.txtRegistrosConErrorAlicuotas.IsRequired = False
      Me.txtRegistrosConErrorAlicuotas.Key = ""
      Me.txtRegistrosConErrorAlicuotas.LabelAsoc = Me.lblRegistrosConErrorAlicuotas
      Me.txtRegistrosConErrorAlicuotas.Location = New System.Drawing.Point(253, 97)
      Me.txtRegistrosConErrorAlicuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtRegistrosConErrorAlicuotas.Name = "txtRegistrosConErrorAlicuotas"
      Me.txtRegistrosConErrorAlicuotas.ReadOnly = True
      Me.txtRegistrosConErrorAlicuotas.Size = New System.Drawing.Size(92, 20)
      Me.txtRegistrosConErrorAlicuotas.TabIndex = 5
      Me.txtRegistrosConErrorAlicuotas.Text = "0"
      Me.txtRegistrosConErrorAlicuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosConErrorAlicuotas
      '
      Me.lblRegistrosConErrorAlicuotas.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosConErrorAlicuotas.AutoSize = True
      Me.lblRegistrosConErrorAlicuotas.LabelAsoc = Nothing
      Me.lblRegistrosConErrorAlicuotas.Location = New System.Drawing.Point(4, 98)
      Me.lblRegistrosConErrorAlicuotas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosConErrorAlicuotas.Name = "lblRegistrosConErrorAlicuotas"
      Me.lblRegistrosConErrorAlicuotas.Size = New System.Drawing.Size(205, 17)
      Me.lblRegistrosConErrorAlicuotas.TabIndex = 4
      Me.lblRegistrosConErrorAlicuotas.Text = "Cantidad de registros con error"
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.grpComprobantes, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.grpAlicuotas, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.grpAnulados, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 1)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 2
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(744, 322)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.AutoSize = True
      Me.Panel1.Controls.Add(Me.btnAceptar)
      Me.Panel1.Controls.Add(Me.btnCancelar)
      Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Panel1.Location = New System.Drawing.Point(190, 116)
      Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(171, 34)
      Me.Panel1.TabIndex = 2
      '
      'grpAnulados
      '
      Me.grpAnulados.Controls.Add(Me.TableLayoutPanel4)
      Me.grpAnulados.Dock = System.Windows.Forms.DockStyle.Fill
      Me.grpAnulados.Location = New System.Drawing.Point(4, 165)
      Me.grpAnulados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.grpAnulados.Name = "grpAnulados"
      Me.grpAnulados.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.grpAnulados.Size = New System.Drawing.Size(364, 153)
      Me.grpAnulados.TabIndex = 3
      Me.grpAnulados.TabStop = False
      Me.grpAnulados.Text = "Anulados"
      '
      'TableLayoutPanel4
      '
      Me.TableLayoutPanel4.ColumnCount = 2
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel4.Controls.Add(Me.lblCantidadRegistrosAnulados, 0, 0)
      Me.TableLayoutPanel4.Controls.Add(Me.txtCantidadRegistrosAnulados, 1, 0)
      Me.TableLayoutPanel4.Controls.Add(Me.txtRegistrosSeleccionadosAnulados, 1, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.txtRegistrosConErrorAnulados, 1, 3)
      Me.TableLayoutPanel4.Controls.Add(Me.lblRegistrosConErrorAnulados, 0, 3)
      Me.TableLayoutPanel4.Controls.Add(Me.lblRegistrosSeleccionadosAnulados, 0, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.txtRegistrosSinSeleccionarAnuladas, 1, 2)
      Me.TableLayoutPanel4.Controls.Add(Me.lblRegistrosSinSeleccionarAnuladas, 0, 2)
      Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel4.Location = New System.Drawing.Point(4, 20)
      Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
      Me.TableLayoutPanel4.RowCount = 5
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
      Me.TableLayoutPanel4.Size = New System.Drawing.Size(356, 129)
      Me.TableLayoutPanel4.TabIndex = 0
      '
      'lblCantidadRegistrosAnulados
      '
      Me.lblCantidadRegistrosAnulados.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblCantidadRegistrosAnulados.AutoSize = True
      Me.lblCantidadRegistrosAnulados.LabelAsoc = Nothing
      Me.lblCantidadRegistrosAnulados.Location = New System.Drawing.Point(4, 7)
      Me.lblCantidadRegistrosAnulados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblCantidadRegistrosAnulados.Name = "lblCantidadRegistrosAnulados"
      Me.lblCantidadRegistrosAnulados.Size = New System.Drawing.Size(174, 17)
      Me.lblCantidadRegistrosAnulados.TabIndex = 0
      Me.lblCantidadRegistrosAnulados.Text = "Cantidad total de registros"
      '
      'txtCantidadRegistrosAnulados
      '
      Me.txtCantidadRegistrosAnulados.BindearPropiedadControl = Nothing
      Me.txtCantidadRegistrosAnulados.BindearPropiedadEntidad = Nothing
      Me.txtCantidadRegistrosAnulados.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadRegistrosAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadRegistrosAnulados.Formato = "N0"
      Me.txtCantidadRegistrosAnulados.IsDecimal = True
      Me.txtCantidadRegistrosAnulados.IsNumber = True
      Me.txtCantidadRegistrosAnulados.IsPK = False
      Me.txtCantidadRegistrosAnulados.IsRequired = False
      Me.txtCantidadRegistrosAnulados.Key = ""
      Me.txtCantidadRegistrosAnulados.LabelAsoc = Me.lblCantidadRegistrosAnulados
      Me.txtCantidadRegistrosAnulados.Location = New System.Drawing.Point(253, 4)
      Me.txtCantidadRegistrosAnulados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtCantidadRegistrosAnulados.Name = "txtCantidadRegistrosAnulados"
      Me.txtCantidadRegistrosAnulados.ReadOnly = True
      Me.txtCantidadRegistrosAnulados.Size = New System.Drawing.Size(92, 23)
      Me.txtCantidadRegistrosAnulados.TabIndex = 1
      Me.txtCantidadRegistrosAnulados.Text = "0"
      Me.txtCantidadRegistrosAnulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRegistrosSeleccionadosAnulados
      '
      Me.txtRegistrosSeleccionadosAnulados.BackColor = System.Drawing.Color.LightYellow
      Me.txtRegistrosSeleccionadosAnulados.BindearPropiedadControl = Nothing
      Me.txtRegistrosSeleccionadosAnulados.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosSeleccionadosAnulados.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosSeleccionadosAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosSeleccionadosAnulados.Formato = "N0"
      Me.txtRegistrosSeleccionadosAnulados.IsDecimal = True
      Me.txtRegistrosSeleccionadosAnulados.IsNumber = True
      Me.txtRegistrosSeleccionadosAnulados.IsPK = False
      Me.txtRegistrosSeleccionadosAnulados.IsRequired = False
      Me.txtRegistrosSeleccionadosAnulados.Key = ""
      Me.txtRegistrosSeleccionadosAnulados.LabelAsoc = Me.lblRegistrosSeleccionadosAnulados
      Me.txtRegistrosSeleccionadosAnulados.Location = New System.Drawing.Point(253, 35)
      Me.txtRegistrosSeleccionadosAnulados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtRegistrosSeleccionadosAnulados.Name = "txtRegistrosSeleccionadosAnulados"
      Me.txtRegistrosSeleccionadosAnulados.ReadOnly = True
      Me.txtRegistrosSeleccionadosAnulados.Size = New System.Drawing.Size(92, 23)
      Me.txtRegistrosSeleccionadosAnulados.TabIndex = 3
      Me.txtRegistrosSeleccionadosAnulados.Text = "0"
      Me.txtRegistrosSeleccionadosAnulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosSeleccionadosAnulados
      '
      Me.lblRegistrosSeleccionadosAnulados.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosSeleccionadosAnulados.AutoSize = True
      Me.lblRegistrosSeleccionadosAnulados.LabelAsoc = Nothing
      Me.lblRegistrosSeleccionadosAnulados.Location = New System.Drawing.Point(4, 38)
      Me.lblRegistrosSeleccionadosAnulados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosSeleccionadosAnulados.Name = "lblRegistrosSeleccionadosAnulados"
      Me.lblRegistrosSeleccionadosAnulados.Size = New System.Drawing.Size(237, 17)
      Me.lblRegistrosSeleccionadosAnulados.TabIndex = 2
      Me.lblRegistrosSeleccionadosAnulados.Text = "Cantidad de registros seleccionados"
      '
      'txtRegistrosConErrorAnulados
      '
      Me.txtRegistrosConErrorAnulados.BackColor = System.Drawing.Color.Tomato
      Me.txtRegistrosConErrorAnulados.BindearPropiedadControl = Nothing
      Me.txtRegistrosConErrorAnulados.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosConErrorAnulados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRegistrosConErrorAnulados.ForeColor = System.Drawing.Color.White
      Me.txtRegistrosConErrorAnulados.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosConErrorAnulados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosConErrorAnulados.Formato = "N0"
      Me.txtRegistrosConErrorAnulados.IsDecimal = True
      Me.txtRegistrosConErrorAnulados.IsNumber = True
      Me.txtRegistrosConErrorAnulados.IsPK = False
      Me.txtRegistrosConErrorAnulados.IsRequired = False
      Me.txtRegistrosConErrorAnulados.Key = ""
      Me.txtRegistrosConErrorAnulados.LabelAsoc = Me.lblRegistrosConErrorAnulados
      Me.txtRegistrosConErrorAnulados.Location = New System.Drawing.Point(253, 97)
      Me.txtRegistrosConErrorAnulados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.txtRegistrosConErrorAnulados.Name = "txtRegistrosConErrorAnulados"
      Me.txtRegistrosConErrorAnulados.ReadOnly = True
      Me.txtRegistrosConErrorAnulados.Size = New System.Drawing.Size(92, 20)
      Me.txtRegistrosConErrorAnulados.TabIndex = 5
      Me.txtRegistrosConErrorAnulados.Text = "0"
      Me.txtRegistrosConErrorAnulados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosConErrorAnulados
      '
      Me.lblRegistrosConErrorAnulados.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosConErrorAnulados.AutoSize = True
      Me.lblRegistrosConErrorAnulados.LabelAsoc = Nothing
      Me.lblRegistrosConErrorAnulados.Location = New System.Drawing.Point(4, 98)
      Me.lblRegistrosConErrorAnulados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosConErrorAnulados.Name = "lblRegistrosConErrorAnulados"
      Me.lblRegistrosConErrorAnulados.Size = New System.Drawing.Size(205, 17)
      Me.lblRegistrosConErrorAnulados.TabIndex = 4
      Me.lblRegistrosConErrorAnulados.Text = "Cantidad de registros con error"
      '
      'txtRegistrosSinSeleccionarComprobantes
      '
      Me.txtRegistrosSinSeleccionarComprobantes.BackColor = System.Drawing.Color.LightYellow
      Me.txtRegistrosSinSeleccionarComprobantes.BindearPropiedadControl = Nothing
      Me.txtRegistrosSinSeleccionarComprobantes.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosSinSeleccionarComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosSinSeleccionarComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosSinSeleccionarComprobantes.Formato = "N0"
      Me.txtRegistrosSinSeleccionarComprobantes.IsDecimal = True
      Me.txtRegistrosSinSeleccionarComprobantes.IsNumber = True
      Me.txtRegistrosSinSeleccionarComprobantes.IsPK = False
      Me.txtRegistrosSinSeleccionarComprobantes.IsRequired = False
      Me.txtRegistrosSinSeleccionarComprobantes.Key = ""
      Me.txtRegistrosSinSeleccionarComprobantes.LabelAsoc = Me.lblRegistrosSinSeleccionarComprobantes
      Me.txtRegistrosSinSeleccionarComprobantes.Location = New System.Drawing.Point(253, 66)
      Me.txtRegistrosSinSeleccionarComprobantes.Margin = New System.Windows.Forms.Padding(4)
      Me.txtRegistrosSinSeleccionarComprobantes.Name = "txtRegistrosSinSeleccionarComprobantes"
      Me.txtRegistrosSinSeleccionarComprobantes.ReadOnly = True
      Me.txtRegistrosSinSeleccionarComprobantes.Size = New System.Drawing.Size(92, 23)
      Me.txtRegistrosSinSeleccionarComprobantes.TabIndex = 3
      Me.txtRegistrosSinSeleccionarComprobantes.Text = "0"
      Me.txtRegistrosSinSeleccionarComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosSinSeleccionarComprobantes
      '
      Me.lblRegistrosSinSeleccionarComprobantes.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosSinSeleccionarComprobantes.AutoSize = True
      Me.lblRegistrosSinSeleccionarComprobantes.LabelAsoc = Nothing
      Me.lblRegistrosSinSeleccionarComprobantes.Location = New System.Drawing.Point(4, 69)
      Me.lblRegistrosSinSeleccionarComprobantes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosSinSeleccionarComprobantes.Name = "lblRegistrosSinSeleccionarComprobantes"
      Me.lblRegistrosSinSeleccionarComprobantes.Size = New System.Drawing.Size(241, 17)
      Me.lblRegistrosSinSeleccionarComprobantes.TabIndex = 2
      Me.lblRegistrosSinSeleccionarComprobantes.Text = "Cantidad de registros sin seleccionar"
      '
      'txtRegistrosSinSeleccionarAlicuotas
      '
      Me.txtRegistrosSinSeleccionarAlicuotas.BackColor = System.Drawing.Color.LightYellow
      Me.txtRegistrosSinSeleccionarAlicuotas.BindearPropiedadControl = Nothing
      Me.txtRegistrosSinSeleccionarAlicuotas.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosSinSeleccionarAlicuotas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosSinSeleccionarAlicuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosSinSeleccionarAlicuotas.Formato = "N0"
      Me.txtRegistrosSinSeleccionarAlicuotas.IsDecimal = True
      Me.txtRegistrosSinSeleccionarAlicuotas.IsNumber = True
      Me.txtRegistrosSinSeleccionarAlicuotas.IsPK = False
      Me.txtRegistrosSinSeleccionarAlicuotas.IsRequired = False
      Me.txtRegistrosSinSeleccionarAlicuotas.Key = ""
      Me.txtRegistrosSinSeleccionarAlicuotas.LabelAsoc = Me.lblRegistrosSinSeleccionarAlicuotas
      Me.txtRegistrosSinSeleccionarAlicuotas.Location = New System.Drawing.Point(253, 66)
      Me.txtRegistrosSinSeleccionarAlicuotas.Margin = New System.Windows.Forms.Padding(4)
      Me.txtRegistrosSinSeleccionarAlicuotas.Name = "txtRegistrosSinSeleccionarAlicuotas"
      Me.txtRegistrosSinSeleccionarAlicuotas.ReadOnly = True
      Me.txtRegistrosSinSeleccionarAlicuotas.Size = New System.Drawing.Size(92, 23)
      Me.txtRegistrosSinSeleccionarAlicuotas.TabIndex = 3
      Me.txtRegistrosSinSeleccionarAlicuotas.Text = "0"
      Me.txtRegistrosSinSeleccionarAlicuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosSinSeleccionarAlicuotas
      '
      Me.lblRegistrosSinSeleccionarAlicuotas.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosSinSeleccionarAlicuotas.AutoSize = True
      Me.lblRegistrosSinSeleccionarAlicuotas.LabelAsoc = Nothing
      Me.lblRegistrosSinSeleccionarAlicuotas.Location = New System.Drawing.Point(4, 69)
      Me.lblRegistrosSinSeleccionarAlicuotas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosSinSeleccionarAlicuotas.Name = "lblRegistrosSinSeleccionarAlicuotas"
      Me.lblRegistrosSinSeleccionarAlicuotas.Size = New System.Drawing.Size(241, 17)
      Me.lblRegistrosSinSeleccionarAlicuotas.TabIndex = 2
      Me.lblRegistrosSinSeleccionarAlicuotas.Text = "Cantidad de registros sin seleccionar"
      '
      'txtRegistrosSinSeleccionarAnuladas
      '
      Me.txtRegistrosSinSeleccionarAnuladas.BackColor = System.Drawing.Color.LightYellow
      Me.txtRegistrosSinSeleccionarAnuladas.BindearPropiedadControl = Nothing
      Me.txtRegistrosSinSeleccionarAnuladas.BindearPropiedadEntidad = Nothing
      Me.txtRegistrosSinSeleccionarAnuladas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegistrosSinSeleccionarAnuladas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegistrosSinSeleccionarAnuladas.Formato = "N0"
      Me.txtRegistrosSinSeleccionarAnuladas.IsDecimal = True
      Me.txtRegistrosSinSeleccionarAnuladas.IsNumber = True
      Me.txtRegistrosSinSeleccionarAnuladas.IsPK = False
      Me.txtRegistrosSinSeleccionarAnuladas.IsRequired = False
      Me.txtRegistrosSinSeleccionarAnuladas.Key = ""
      Me.txtRegistrosSinSeleccionarAnuladas.LabelAsoc = Me.lblRegistrosSinSeleccionarAnuladas
      Me.txtRegistrosSinSeleccionarAnuladas.Location = New System.Drawing.Point(253, 66)
      Me.txtRegistrosSinSeleccionarAnuladas.Margin = New System.Windows.Forms.Padding(4)
      Me.txtRegistrosSinSeleccionarAnuladas.Name = "txtRegistrosSinSeleccionarAnuladas"
      Me.txtRegistrosSinSeleccionarAnuladas.ReadOnly = True
      Me.txtRegistrosSinSeleccionarAnuladas.Size = New System.Drawing.Size(92, 23)
      Me.txtRegistrosSinSeleccionarAnuladas.TabIndex = 3
      Me.txtRegistrosSinSeleccionarAnuladas.Text = "0"
      Me.txtRegistrosSinSeleccionarAnuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRegistrosSinSeleccionarAnuladas
      '
      Me.lblRegistrosSinSeleccionarAnuladas.Anchor = System.Windows.Forms.AnchorStyles.Left
      Me.lblRegistrosSinSeleccionarAnuladas.AutoSize = True
      Me.lblRegistrosSinSeleccionarAnuladas.LabelAsoc = Nothing
      Me.lblRegistrosSinSeleccionarAnuladas.Location = New System.Drawing.Point(4, 69)
      Me.lblRegistrosSinSeleccionarAnuladas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.lblRegistrosSinSeleccionarAnuladas.Name = "lblRegistrosSinSeleccionarAnuladas"
      Me.lblRegistrosSinSeleccionarAnuladas.Size = New System.Drawing.Size(241, 17)
      Me.lblRegistrosSinSeleccionarAnuladas.TabIndex = 2
      Me.lblRegistrosSinSeleccionarAnuladas.Text = "Cantidad de registros sin seleccionar"
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.PictureBox1)
      Me.Panel2.Controls.Add(Me.Panel1)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel2.Location = New System.Drawing.Point(375, 164)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(366, 155)
      Me.Panel2.TabIndex = 4
      '
      'PictureBox1
      '
      Me.PictureBox1.BackgroundImage = Global.Eniac.Win.My.Resources.Resources._stop
      Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.PictureBox1.Location = New System.Drawing.Point(39, 16)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(120, 120)
      Me.PictureBox1.TabIndex = 3
      Me.PictureBox1.TabStop = False
      Me.PictureBox1.Visible = False
      '
      'ExportarCitiVentasConfirmacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(744, 322)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
      Me.Name = "ExportarCitiVentasConfirmacion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Confirmar exportación"
      Me.grpComprobantes.ResumeLayout(False)
      Me.TableLayoutPanel2.ResumeLayout(False)
      Me.TableLayoutPanel2.PerformLayout()
      Me.grpAlicuotas.ResumeLayout(False)
      Me.TableLayoutPanel3.ResumeLayout(False)
      Me.TableLayoutPanel3.PerformLayout()
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.grpAnulados.ResumeLayout(False)
      Me.TableLayoutPanel4.ResumeLayout(False)
      Me.TableLayoutPanel4.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents grpComprobantes As GroupBox
   Friend WithEvents grpAlicuotas As GroupBox
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents Panel1 As Panel
   Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
   Friend WithEvents lblCantidadRegistrosComprobantes As Controles.Label
   Friend WithEvents txtCantidadRegistrosComprobantes As Controles.TextBox
   Friend WithEvents txtRegistrosSeleccionadosComprobantes As Controles.TextBox
   Friend WithEvents txtRegistrosConErrorComprobantes As Controles.TextBox
   Friend WithEvents lblRegistrosConErrorComprobantes As Controles.Label
   Friend WithEvents lblRegistrosSeleccionadosComprobantes As Controles.Label
   Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
   Friend WithEvents lblCantidadRegistrosAlicuotas As Controles.Label
   Friend WithEvents txtCantidadRegistrosAlicuotas As Controles.TextBox
   Friend WithEvents txtRegistrosSeleccionadosAlicuotas As Controles.TextBox
   Friend WithEvents txtRegistrosConErrorAlicuotas As Controles.TextBox
   Friend WithEvents lblRegistrosConErrorAlicuotas As Controles.Label
   Friend WithEvents lblRegistrosSeleccionadosAlicuotas As Controles.Label
   Friend WithEvents grpAnulados As GroupBox
   Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
   Friend WithEvents lblCantidadRegistrosAnulados As Controles.Label
   Friend WithEvents txtCantidadRegistrosAnulados As Controles.TextBox
   Friend WithEvents txtRegistrosSeleccionadosAnulados As Controles.TextBox
   Friend WithEvents lblRegistrosSeleccionadosAnulados As Controles.Label
   Friend WithEvents txtRegistrosConErrorAnulados As Controles.TextBox
   Friend WithEvents lblRegistrosConErrorAnulados As Controles.Label
   Friend WithEvents txtRegistrosSinSeleccionarComprobantes As Controles.TextBox
   Friend WithEvents lblRegistrosSinSeleccionarComprobantes As Controles.Label
   Friend WithEvents txtRegistrosSinSeleccionarAlicuotas As Controles.TextBox
   Friend WithEvents lblRegistrosSinSeleccionarAlicuotas As Controles.Label
   Friend WithEvents txtRegistrosSinSeleccionarAnuladas As Controles.TextBox
   Friend WithEvents lblRegistrosSinSeleccionarAnuladas As Controles.Label
   Friend WithEvents Panel2 As Panel
   Friend WithEvents PictureBox1 As PictureBox
End Class
