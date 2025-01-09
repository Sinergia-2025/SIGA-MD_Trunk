Option Explicit On
Option Strict On

Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SectoresABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False
    End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SectoresDetalle(DirectCast(Me.GetEntidad(), Entidades.Sector))
      End If
      Return New SectoresDetalle(New Entidades.Sector)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Sectores()
   End Function

   Protected Overrides Sub Imprimir()
      'MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor
      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Productos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, True)
      '   frmImprime.Text = "Productos"
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad

      With Me.dgvDatos.ActiveRow
         Return New Reglas.Sectores().GetUno(Integer.Parse(.Cells(Entidades.Sector.Columnas.IdSector.ToString()).Value.ToString()))
      End With

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns(Entidades.Sector.Columnas.IdSector.ToString()).FormatearColumna("IdSector", col, 50, HAlign.Right)
         .Columns(Entidades.Sector.Columnas.NombreSector.ToString()).FormatearColumna("Nombre", col, 150, HAlign.Left)
         .Columns(Entidades.Sector.Columnas.Observaciones.ToString()).FormatearColumna("Observaciones", col, 280, HAlign.Left)
         .Columns(Entidades.Sector.Columnas.IdAreaComun.ToString()).FormatearColumna("IdAreaComun", col, 150, HAlign.Right)

      End With
   End Sub

#End Region

End Class