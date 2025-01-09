<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalidadListasControlItemsSubGruposDetalle
   Inherits BaseDetalle

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
      Me.lblNombreTipoAdjunto = New Eniac.Controles.Label()
      Me.txtIdTipoAdjunto = New Eniac.Controles.TextBox()
      Me.lblIdTipoAdjunto = New Eniac.Controles.Label()
      Me.txtNombreGrupoItem = New Eniac.Controles.TextBox()
      Me.lblLocalidad = New Eniac.Controles.Label()
      Me.cmbGruposItemsListasControl = New Eniac.Controles.ComboBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(196, 122)
      Me.btnAceptar.TabIndex = 6
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(282, 122)
      Me.btnCancelar.TabIndex = 7
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(95, 122)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(35, 122)
      Me.btnAplicar.TabIndex = 8
      '
      'lblNombreTipoAdjunto
      '
      Me.lblNombreTipoAdjunto.AutoSize = True
      Me.lblNombreTipoAdjunto.LabelAsoc = Nothing
      Me.lblNombreTipoAdjunto.Location = New System.Drawing.Point(36, 78)
      Me.lblNombreTipoAdjunto.Name = "lblNombreTipoAdjunto"
      Me.lblNombreTipoAdjunto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreTipoAdjunto.TabIndex = 4
      Me.lblNombreTipoAdjunto.Text = "Nombre"
      '
      'txtIdTipoAdjunto
      '
      Me.txtIdTipoAdjunto.BindearPropiedadControl = "Text"
      Me.txtIdTipoAdjunto.BindearPropiedadEntidad = "IdListaControlItemSubGrupo"
      Me.txtIdTipoAdjunto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoAdjunto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoAdjunto.Formato = ""
      Me.txtIdTipoAdjunto.IsDecimal = False
      Me.txtIdTipoAdjunto.IsNumber = False
      Me.txtIdTipoAdjunto.IsPK = True
      Me.txtIdTipoAdjunto.IsRequired = True
      Me.txtIdTipoAdjunto.Key = ""
      Me.txtIdTipoAdjunto.LabelAsoc = Me.lblIdTipoAdjunto
      Me.txtIdTipoAdjunto.Location = New System.Drawing.Point(95, 49)
      Me.txtIdTipoAdjunto.MaxLength = 6
      Me.txtIdTipoAdjunto.Name = "txtIdTipoAdjunto"
      Me.txtIdTipoAdjunto.Size = New System.Drawing.Size(59, 20)
      Me.txtIdTipoAdjunto.TabIndex = 3
      '
      'lblIdTipoAdjunto
      '
      Me.lblIdTipoAdjunto.AutoSize = True
      Me.lblIdTipoAdjunto.LabelAsoc = Nothing
      Me.lblIdTipoAdjunto.Location = New System.Drawing.Point(36, 53)
      Me.lblIdTipoAdjunto.Name = "lblIdTipoAdjunto"
      Me.lblIdTipoAdjunto.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoAdjunto.TabIndex = 2
      Me.lblIdTipoAdjunto.Text = "Código"
      '
      'txtNombreGrupoItem
      '
      Me.txtNombreGrupoItem.BindearPropiedadControl = "Text"
      Me.txtNombreGrupoItem.BindearPropiedadEntidad = "NombreListaControlItemSubGrupo"
      Me.txtNombreGrupoItem.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreGrupoItem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreGrupoItem.Formato = ""
      Me.txtNombreGrupoItem.IsDecimal = False
      Me.txtNombreGrupoItem.IsNumber = False
      Me.txtNombreGrupoItem.IsPK = False
      Me.txtNombreGrupoItem.IsRequired = True
      Me.txtNombreGrupoItem.Key = ""
      Me.txtNombreGrupoItem.LabelAsoc = Me.lblNombreTipoAdjunto
      Me.txtNombreGrupoItem.Location = New System.Drawing.Point(95, 75)
      Me.txtNombreGrupoItem.MaxLength = 50
      Me.txtNombreGrupoItem.Name = "txtNombreGrupoItem"
      Me.txtNombreGrupoItem.Size = New System.Drawing.Size(262, 20)
      Me.txtNombreGrupoItem.TabIndex = 5
      '
      'lblLocalidad
      '
      Me.lblLocalidad.AutoSize = True
      Me.lblLocalidad.LabelAsoc = Nothing
      Me.lblLocalidad.Location = New System.Drawing.Point(36, 25)
      Me.lblLocalidad.Name = "lblLocalidad"
      Me.lblLocalidad.Size = New System.Drawing.Size(36, 13)
      Me.lblLocalidad.TabIndex = 0
      Me.lblLocalidad.Text = "Grupo"
      '
      'cmbGruposItemsListasControl
      '
      Me.cmbGruposItemsListasControl.BindearPropiedadControl = "SelectedValue"
      Me.cmbGruposItemsListasControl.BindearPropiedadEntidad = "IdListaControlItemGrupo"
      Me.cmbGruposItemsListasControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGruposItemsListasControl.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGruposItemsListasControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGruposItemsListasControl.FormattingEnabled = True
      Me.cmbGruposItemsListasControl.IsPK = True
      Me.cmbGruposItemsListasControl.IsRequired = True
      Me.cmbGruposItemsListasControl.Key = Nothing
      Me.cmbGruposItemsListasControl.LabelAsoc = Me.lblLocalidad
      Me.cmbGruposItemsListasControl.Location = New System.Drawing.Point(95, 22)
      Me.cmbGruposItemsListasControl.Name = "cmbGruposItemsListasControl"
      Me.cmbGruposItemsListasControl.Size = New System.Drawing.Size(179, 21)
      Me.cmbGruposItemsListasControl.TabIndex = 1
      '
      'CalidadListasControlItemsSubGruposDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 157)
      Me.Controls.Add(Me.lblLocalidad)
      Me.Controls.Add(Me.cmbGruposItemsListasControl)
      Me.Controls.Add(Me.txtNombreGrupoItem)
      Me.Controls.Add(Me.txtIdTipoAdjunto)
      Me.Controls.Add(Me.lblNombreTipoAdjunto)
      Me.Controls.Add(Me.lblIdTipoAdjunto)
      Me.Name = "CalidadListasControlItemsSubGruposDetalle"
      Me.Text = "SubGrupo de Items"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoAdjunto, 0)
      Me.Controls.SetChildIndex(Me.txtNombreGrupoItem, 0)
      Me.Controls.SetChildIndex(Me.cmbGruposItemsListasControl, 0)
      Me.Controls.SetChildIndex(Me.lblLocalidad, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoAdjunto As Eniac.Controles.Label
   Friend WithEvents txtIdTipoAdjunto As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoAdjunto As Eniac.Controles.Label
   Friend WithEvents txtNombreGrupoItem As Eniac.Controles.TextBox
   Friend WithEvents lblLocalidad As Eniac.Controles.Label
   Friend WithEvents cmbGruposItemsListasControl As Eniac.Controles.ComboBox
End Class
