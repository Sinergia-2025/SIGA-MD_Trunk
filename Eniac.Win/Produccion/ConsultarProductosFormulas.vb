Option Strict On
Option Explicit On
Public Class ConsultarProductosFormulas

   Private _tit As Dictionary(Of String, String)
   Private _dt As DataTable

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarFiltroEnLinea({"NombreProductoComponente"})
         ugDetalle.AgregarTotalesSuma({"Cantidad", "ImporteVenta"})

         If _dt IsNot Nothing Then
            SetDataSource(_dt)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub SetDataSource(dt As DataTable)
      ugDetalle.DataSource = dt
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Public Overloads Function ShowDialog(dt As DataTable) As DialogResult
      _dt = dt
      Return ShowDialog()
   End Function

   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      Close()
   End Sub
End Class