<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosTiposConceptosDetalle
    Inherits BaseDetalle

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.txtNombreTipoConcepto = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtIdTipoConcepto = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(128, 98)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(214, 98)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(46, 215)
      '
      'txtNombreTipoConcepto
      '
      Me.txtNombreTipoConcepto.BindearPropiedadControl = "Text"
      Me.txtNombreTipoConcepto.BindearPropiedadEntidad = "NombreTipoConcepto"
      Me.txtNombreTipoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoConcepto.Formato = ""
      Me.txtNombreTipoConcepto.IsDecimal = False
      Me.txtNombreTipoConcepto.IsNumber = False
      Me.txtNombreTipoConcepto.IsPK = True
      Me.txtNombreTipoConcepto.IsRequired = True
      Me.txtNombreTipoConcepto.Key = ""
      Me.txtNombreTipoConcepto.LabelAsoc = Me.lblNombre
      Me.txtNombreTipoConcepto.Location = New System.Drawing.Point(62, 42)
      Me.txtNombreTipoConcepto.MaxLength = 50
      Me.txtNombreTipoConcepto.Name = "txtNombreTipoConcepto"
      Me.txtNombreTipoConcepto.ReadOnly = True
      Me.txtNombreTipoConcepto.Size = New System.Drawing.Size(230, 20)
      Me.txtNombreTipoConcepto.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(12, 46)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtIdTipoConcepto
      '
      Me.txtIdTipoConcepto.BindearPropiedadControl = "Text"
      Me.txtIdTipoConcepto.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.txtIdTipoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoConcepto.Formato = ""
      Me.txtIdTipoConcepto.IsDecimal = False
      Me.txtIdTipoConcepto.IsNumber = True
      Me.txtIdTipoConcepto.IsPK = True
      Me.txtIdTipoConcepto.IsRequired = True
      Me.txtIdTipoConcepto.Key = ""
      Me.txtIdTipoConcepto.LabelAsoc = Me.lblCodigo
      Me.txtIdTipoConcepto.Location = New System.Drawing.Point(62, 16)
      Me.txtIdTipoConcepto.MaxLength = 3
      Me.txtIdTipoConcepto.Name = "txtIdTipoConcepto"
      Me.txtIdTipoConcepto.Size = New System.Drawing.Size(69, 20)
      Me.txtIdTipoConcepto.TabIndex = 1
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.Location = New System.Drawing.Point(12, 20)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.Location = New System.Drawing.Point(12, 72)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(36, 13)
      Me.lblOrden.TabIndex = 4
      Me.lblOrden.Text = "Orden"
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
      Me.txtOrden.IsRequired = False
      Me.txtOrden.Key = ""
      Me.txtOrden.LabelAsoc = Me.lblOrden
      Me.txtOrden.Location = New System.Drawing.Point(62, 68)
      Me.txtOrden.MaxLength = 3
      Me.txtOrden.Name = "txtOrden"
      Me.txtOrden.Size = New System.Drawing.Size(40, 20)
      Me.txtOrden.TabIndex = 5
      Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'SueldosTiposConceptosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(306, 140)
      Me.Controls.Add(Me.txtNombreTipoConcepto)
      Me.Controls.Add(Me.txtOrden)
      Me.Controls.Add(Me.txtIdTipoConcepto)
      Me.Controls.Add(Me.lblOrden)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "SueldosTiposConceptosDetalle"
      Me.Text = "Tipo de Concepto"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblOrden, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoConcepto, 0)
      Me.Controls.SetChildIndex(Me.txtOrden, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoConcepto, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents txtNombreTipoConcepto As Eniac.Controles.TextBox
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents txtIdTipoConcepto As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
End Class
