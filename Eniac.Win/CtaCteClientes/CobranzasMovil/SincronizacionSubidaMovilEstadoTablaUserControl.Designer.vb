<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizacionSubidaMovilEstadoTablaUserControl
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
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblTabla = New Eniac.Controles.Label()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.AutoSize = True
      Me.TableLayoutPanel1.ColumnCount = 3
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.lblTabla, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.lblCantidad, 2, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.lblEstado, 1, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.TableLayoutPanel1.MaximumSize = New System.Drawing.Size(270, 30000)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(270, 16)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'lblTabla
      '
      Me.lblTabla.AutoSize = True
      Me.lblTabla.LabelAsoc = Nothing
      Me.lblTabla.Location = New System.Drawing.Point(3, 0)
      Me.lblTabla.Name = "lblTabla"
      Me.lblTabla.Size = New System.Drawing.Size(30, 13)
      Me.lblTabla.TabIndex = 4
      Me.lblTabla.Text = "tabla"
      '
      'lblCantidad
      '
      Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCantidad.AutoSize = True
      Me.lblCantidad.LabelAsoc = Nothing
      Me.lblCantidad.Location = New System.Drawing.Point(240, 0)
      Me.lblCantidad.Name = "lblCantidad"
      Me.lblCantidad.Size = New System.Drawing.Size(27, 13)
      Me.lblCantidad.TabIndex = 6
      Me.lblCantidad.Text = "total"
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(168, 0)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(39, 13)
      Me.lblEstado.TabIndex = 8
      Me.lblEstado.Text = "estado"
      '
      'SincronizacionSubidaMovilEstadoTablaUserControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSize = True
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.Name = "SincronizacionSubidaMovilEstadoTablaUserControl"
      Me.Size = New System.Drawing.Size(273, 19)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Private WithEvents lblTabla As Eniac.Controles.Label
   Private WithEvents lblCantidad As Eniac.Controles.Label
   Private WithEvents lblEstado As Eniac.Controles.Label

End Class
