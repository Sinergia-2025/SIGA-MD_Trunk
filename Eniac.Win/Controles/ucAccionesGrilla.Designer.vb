<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAccionesGrilla
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.btnConsultar = New ButtonConsultar()
      Me.btnTodos = New Eniac.Controles.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnConsultar
      '
      Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
      Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(196, 0)
      Me.btnConsultar.Margin = New System.Windows.Forms.Padding(0)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 30)
      Me.btnConsultar.TabIndex = 26
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'btnTodos
      '
      Me.btnTodos.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnTodos.Location = New System.Drawing.Point(0, 3)
      Me.btnTodos.Margin = New System.Windows.Forms.Padding(0)
      Me.btnTodos.Name = "btnTodos"
      Me.btnTodos.Size = New System.Drawing.Size(75, 23)
      Me.btnTodos.TabIndex = 28
      Me.btnTodos.Text = "Aplicar"
      Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnTodos.UseVisualStyleBackColor = True
      '
      'cmbTodos
      '
      Me.cmbTodos.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.cmbTodos.BindearPropiedadControl = Nothing
      Me.cmbTodos.BindearPropiedadEntidad = Nothing
      Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTodos.FormattingEnabled = True
      Me.cmbTodos.IsPK = False
      Me.cmbTodos.IsRequired = False
      Me.cmbTodos.Key = Nothing
      Me.cmbTodos.LabelAsoc = Nothing
      Me.cmbTodos.Location = New System.Drawing.Point(75, 4)
      Me.cmbTodos.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbTodos.Name = "cmbTodos"
      Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
      Me.cmbTodos.TabIndex = 27
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 4
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.btnTodos, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.btnConsultar, 2, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.cmbTodos, 1, 0)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 2
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(298, 32)
      Me.TableLayoutPanel1.TabIndex = 29
      '
      'ucAccionesGrilla
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.Name = "ucAccionesGrilla"
      Me.Size = New System.Drawing.Size(298, 32)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents btnConsultar As ButtonConsultar
   Friend WithEvents btnTodos As Controles.Button
   Friend WithEvents cmbTodos As Controles.ComboBox
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
