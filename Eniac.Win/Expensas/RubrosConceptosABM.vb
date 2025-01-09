Option Explicit On
Option Strict On

Public Class RubrosConceptosABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RubrosConceptosDetalle(DirectCast(Me.GetEntidad(), Entidades.RubroConcepto))
      End If
      Return New RubrosConceptosDetalle(New Entidades.RubroConcepto)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RubrosConceptos()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.RubrosConceptos.rdlc", "SistemaDataSet_RubrosConceptos", Me.dtDatos, parm, True, 1) '# 1 = Cantidad de Copias
         frmImprime.Text = Me.Text
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim RubroConcepto As Entidades.RubroConcepto = New Entidades.RubroConcepto
      With Me.dgvDatos.ActiveCell.Row
         RubroConcepto.IdRubroConcepto = Int32.Parse(.Cells("IdRubroConcepto").Value.ToString())
         RubroConcepto.NombreRubroConcepto = .Cells("NombreRubroConcepto").Value.ToString()
      End With
      Return RubroConcepto
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns("IdRubroConcepto").Header.Caption = "Código"
         .Columns("IdRubroConcepto").Width = 70
         .Columns("IdRubroConcepto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NombreRubroConcepto").Header.Caption = "Nombre"
         .Columns("NombreRubroConcepto").Width = 300

      End With
   End Sub

#End Region

End Class
