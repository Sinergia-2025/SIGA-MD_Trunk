#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class BancosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New BancosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Banco))
      End If
      Return New BancosDetalle(New Entidades.Banco)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Bancos()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Bancos.rdlc", "SistemaDataSet_Bancos", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Bancos"
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim banco As Entidades.Banco = New Entidades.Banco
      With Me.dgvDatos.ActiveRow
         banco = New Reglas.Bancos().GetUno(Integer.Parse(.Cells("IdBanco").Value.ToString()))
      End With
      Return banco
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns("IdBanco").FormatearColumna("Código", col, 50, HAlign.Right)
         .Columns("NombreBanco").FormatearColumna("Nombre", col, 240, HAlign.Left)
         .Columns("DebitoDirecto").FormatearColumna("Debito Dir.", col, 70, HAlign.Right)
         .Columns("Empresa").FormatearColumna("Empresa", col, 70, HAlign.Right)
         .Columns("Convenio").FormatearColumna("Convenio", col, 70, HAlign.Right)
         .Columns("Servicio").FormatearColumna("Servicio", col, 70, HAlign.Right)
      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreBanco"})
   End Sub

#End Region

End Class
