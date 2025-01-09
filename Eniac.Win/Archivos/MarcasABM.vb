Public Class MarcasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MarcasDetalle(DirectCast(GetEntidad(), Entidades.Marca))
      End If
      Return New MarcasDetalle(New Entidades.Marca)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Marcas()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Marcas.rdlc", "SistemaDataSet_Marcas", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Marcas"
         frmImprime.Show()

         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim marca = New Entidades.Marca()
      With dgvDatos.ActiveRow
         marca = New Reglas.Marcas().GetUna(Integer.Parse(.Cells("IdMarca").Value.ToString()))
      End With
      Return marca
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns("IdMarca").FormatearColumna("Código", col, 90, HAlign.Right)
         .Columns("NombreMarca").FormatearColumna("Nombre", col, 180, HAlign.Left)
         .Columns("ComisionPorVenta").FormatearColumna("Comision por Venta", col, 70, HAlign.Right,, "N2")
         .Columns("DescuentoRecargoPorc1").FormatearColumna("% D/R 1", col, 70, HAlign.Right,, "N2")
         .Columns("DescuentoRecargoPorc2").FormatearColumna("% D/R 2", col, 70, HAlign.Right,, "N2")
      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreMarca"})
   End Sub

#End Region

End Class