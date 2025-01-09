<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroMultipleLocalidades
   Inherits BaseFiltroMultiple

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
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdLocalidad")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreLocalidad")
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      CType(Me.ugbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ugbProductos.SuspendLayout()
      Me.grbCabeza.SuspendLayout()
      Me.grbPie.SuspendLayout()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ugbProductos
      '
      Me.ugbProductos.Size = New System.Drawing.Size(416, 393)
      '
      'lnkLimpiarFiltros
      '
      '
      'lnkGrabarFiltro
      '
      '
      'lnkRecuperarUltimo
      '
      '
      'btnEliminar
      '
      '
      'btnInsertar
      '
      '
      'bscCodigo
      '
      '
      'bscNombre
      '
      '
      'grbCuerpo
      '
      Me.grbCuerpo.Size = New System.Drawing.Size(410, 276)
      '
      'grbPie
      '
      Me.grbPie.Location = New System.Drawing.Point(3, 350)
      '
      'UltraDataSource1
      '
      UltraDataColumn1.DataType = GetType(Integer)
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2})
      '
      'FiltroMultipleLocalidades
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(416, 393)
      Me.Name = "FiltroMultipleLocalidades"
      Me.Text = "Localidades"
      CType(Me.ugbProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ugbProductos.ResumeLayout(False)
      Me.grbCabeza.ResumeLayout(False)
      Me.grbPie.ResumeLayout(False)
      Me.grbPie.PerformLayout()
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
End Class
