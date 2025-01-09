
Option Strict Off
Public Class PlantillasCalidadABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PlantillasCalidadDetalle(DirectCast(Me.GetEntidad(), Entidades.PlantillaListaControl))
      End If
      Return New PlantillasCalidadDetalle(New Entidades.PlantillaListaControl())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.PlantillasListasControl()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim pla As Entidades.PlantillaListaControl = New Entidades.PlantillaListaControl()
      With Me.dgvDatos.ActiveCell.Row
         pla.IdPlantillaCalidad = Integer.Parse(.Cells("IdPlantillaCalidad").Value.ToString())
         pla = New Reglas.PlantillasListasControl().GetUno(pla.IdPlantillaCalidad)
      End With
      Return pla
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.PlantillaListaControl.Columnas.IdPlantillaCalidad.ToString()).Header.Caption = "Plantilla"
         .Columns(Entidades.PlantillaListaControl.Columnas.IdPlantillaCalidad.ToString()).Width = 40
         .Columns(Entidades.PlantillaListaControl.Columnas.IdPlantillaCalidad.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.PlantillaListaControl.Columnas.NombrePlantillaCalidad.ToString()).Header.Caption = "Nombre Plantilla"
         .Columns(Entidades.PlantillaListaControl.Columnas.NombrePlantillaCalidad.ToString()).Width = 250
             End With
   End Sub

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.Selected.Cells.Count > 0 Then

            Dim cl As Reglas.Base = Me.GetReglas()
            Me._entidad = Me.GetEntidad()

            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If

         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("No se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub


#End Region

End Class