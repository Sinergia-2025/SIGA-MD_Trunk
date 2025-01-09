Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class RubrosComprasABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RubrosComprasDetalle(DirectCast(Me.GetEntidad(), Entidades.RubroCompra))
      End If
      Return New RubrosComprasDetalle(New Entidades.RubroCompra)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RubrosCompras()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.RubrosCompras.rdlc", "SistemaDataSet_Rubros", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Rubros Compras"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim rubro As Entidades.RubroCompra = New Entidades.RubroCompra
      With Me.dgvDatos.SelectedCells(0).OwningRow
         rubro = New Reglas.RubrosCompras().GetUno(Integer.Parse(.Cells("IdRubro").Value.ToString()))
      End With
      Return rubro
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns("IdRubro").HeaderText = "Código"
         .Columns("IdRubro").Width = 70
         .Columns("NombreRubro").HeaderText = "Nombre"
         .Columns("NombreRubro").Width = 250
         .Columns("NombreRubro").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class
