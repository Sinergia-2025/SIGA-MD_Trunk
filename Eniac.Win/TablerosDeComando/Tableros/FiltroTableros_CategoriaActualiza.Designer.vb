<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroTableros_CategoriaActualiza
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.chbActualizaAplicacion = New Eniac.Controles.CheckBox()
      Me.chbCategoriaCliente = New Eniac.Controles.Label()
      Me.cmbNombreCliente = New Eniac.Controles.ComboBox()
      Me.cmbActualizaAplicacion = New Eniac.Controles.ComboBox()
      Me.cmbCategoriasClientes = New Eniac.Win.ComboBoxCategorias()
      Me.SuspendLayout()
      '
      'lblNombreCliente
      '
      Me.lblNombreCliente.AutoSize = True
      Me.lblNombreCliente.LabelAsoc = Nothing
      Me.lblNombreCliente.Location = New System.Drawing.Point(459, 4)
      Me.lblNombreCliente.Margin = New System.Windows.Forms.Padding(0)
      Me.lblNombreCliente.Name = "lblNombreCliente"
      Me.lblNombreCliente.Size = New System.Drawing.Size(23, 13)
      Me.lblNombreCliente.TabIndex = 13
      Me.lblNombreCliente.Text = "Ver"
      '
      'chbActualizaAplicacion
      '
      Me.chbActualizaAplicacion.AutoSize = True
      Me.chbActualizaAplicacion.BindearPropiedadControl = Nothing
      Me.chbActualizaAplicacion.BindearPropiedadEntidad = Nothing
      Me.chbActualizaAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActualizaAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActualizaAplicacion.IsPK = False
      Me.chbActualizaAplicacion.IsRequired = False
      Me.chbActualizaAplicacion.Key = Nothing
      Me.chbActualizaAplicacion.LabelAsoc = Nothing
      Me.chbActualizaAplicacion.Location = New System.Drawing.Point(242, 2)
      Me.chbActualizaAplicacion.Margin = New System.Windows.Forms.Padding(0)
      Me.chbActualizaAplicacion.Name = "chbActualizaAplicacion"
      Me.chbActualizaAplicacion.Size = New System.Drawing.Size(69, 17)
      Me.chbActualizaAplicacion.TabIndex = 11
      Me.chbActualizaAplicacion.Text = "Actualiza"
      Me.chbActualizaAplicacion.UseVisualStyleBackColor = True
      '
      'chbCategoriaCliente
      '
      Me.chbCategoriaCliente.AutoSize = True
      Me.chbCategoriaCliente.LabelAsoc = Nothing
      Me.chbCategoriaCliente.Location = New System.Drawing.Point(3, 4)
      Me.chbCategoriaCliente.Margin = New System.Windows.Forms.Padding(0)
      Me.chbCategoriaCliente.Name = "chbCategoriaCliente"
      Me.chbCategoriaCliente.Size = New System.Drawing.Size(92, 13)
      Me.chbCategoriaCliente.TabIndex = 9
      Me.chbCategoriaCliente.Text = "Categoria Clientes"
      '
      'cmbNombreCliente
      '
      Me.cmbNombreCliente.BindearPropiedadControl = "SelectedValue"
      Me.cmbNombreCliente.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
      Me.cmbNombreCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNombreCliente.FormattingEnabled = True
      Me.cmbNombreCliente.IsPK = False
      Me.cmbNombreCliente.IsRequired = False
      Me.cmbNombreCliente.Key = Nothing
      Me.cmbNombreCliente.LabelAsoc = Me.lblNombreCliente
      Me.cmbNombreCliente.Location = New System.Drawing.Point(489, 0)
      Me.cmbNombreCliente.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbNombreCliente.Name = "cmbNombreCliente"
      Me.cmbNombreCliente.Size = New System.Drawing.Size(146, 21)
      Me.cmbNombreCliente.TabIndex = 14
      '
      'cmbActualizaAplicacion
      '
      Me.cmbActualizaAplicacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbActualizaAplicacion.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
      Me.cmbActualizaAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbActualizaAplicacion.Enabled = False
      Me.cmbActualizaAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbActualizaAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbActualizaAplicacion.FormattingEnabled = True
      Me.cmbActualizaAplicacion.IsPK = False
      Me.cmbActualizaAplicacion.IsRequired = False
      Me.cmbActualizaAplicacion.Key = Nothing
      Me.cmbActualizaAplicacion.LabelAsoc = Nothing
      Me.cmbActualizaAplicacion.Location = New System.Drawing.Point(311, 0)
      Me.cmbActualizaAplicacion.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbActualizaAplicacion.Name = "cmbActualizaAplicacion"
      Me.cmbActualizaAplicacion.Size = New System.Drawing.Size(146, 21)
      Me.cmbActualizaAplicacion.TabIndex = 12
      '
      'cmbCategoriasClientes
      '
      Me.cmbCategoriasClientes.BindearPropiedadControl = Nothing
      Me.cmbCategoriasClientes.BindearPropiedadEntidad = Nothing
      Me.cmbCategoriasClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriasClientes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriasClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriasClientes.FormattingEnabled = True
      Me.cmbCategoriasClientes.IsPK = False
      Me.cmbCategoriasClientes.IsRequired = False
      Me.cmbCategoriasClientes.Key = Nothing
      Me.cmbCategoriasClientes.LabelAsoc = Nothing
      Me.cmbCategoriasClientes.Location = New System.Drawing.Point(96, 0)
      Me.cmbCategoriasClientes.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbCategoriasClientes.Name = "cmbCategoriasClientes"
      Me.cmbCategoriasClientes.Size = New System.Drawing.Size(140, 21)
      Me.cmbCategoriasClientes.TabIndex = 10
      '
      'FiltroTableros_CategoriaActualiza
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSize = True
      Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.Controls.Add(Me.lblNombreCliente)
      Me.Controls.Add(Me.cmbNombreCliente)
      Me.Controls.Add(Me.chbActualizaAplicacion)
      Me.Controls.Add(Me.cmbActualizaAplicacion)
      Me.Controls.Add(Me.cmbCategoriasClientes)
      Me.Controls.Add(Me.chbCategoriaCliente)
      Me.Name = "FiltroTableros_CategoriaActualiza"
      Me.Size = New System.Drawing.Size(635, 21)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents cmbNombreCliente As Eniac.Controles.ComboBox
   Friend WithEvents chbActualizaAplicacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbActualizaAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents cmbCategoriasClientes As Eniac.Win.ComboBoxCategorias
   Friend WithEvents chbCategoriaCliente As Eniac.Controles.Label

End Class
