Option Strict Off
Public Class PlantillasPreciosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PlantillasPreciosDetalle(DirectCast(Me.GetEntidad(), Entidades.Plantilla))
      End If
      Return New PlantillasPreciosDetalle(New Entidades.Plantilla())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Plantillas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim pla As Entidades.Plantilla = New Entidades.Plantilla()
      With Me.dgvDatos.ActiveCell.Row
         pla.IdPlantilla = Integer.Parse(.Cells("IdPlantilla").Value.ToString())
         pla = New Reglas.Plantillas().GetUno(pla.IdPlantilla)
      End With
      Return pla
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Plantilla.Columnas.IdPlantilla.ToString()).Header.Caption = "Plantilla"
         .Columns(Entidades.Plantilla.Columnas.IdPlantilla.ToString()).Width = 40
         .Columns(Entidades.Plantilla.Columnas.IdPlantilla.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Plantilla.Columnas.NombrePlantilla.ToString()).Header.Caption = "Nombre Plantilla"
         .Columns(Entidades.Plantilla.Columnas.NombrePlantilla.ToString()).Width = 250
         .Columns("IdProveedor").Hidden = True
         .Columns("NombreProveedor").Header.Caption = "Proveedor"
         .Columns("NombreProveedor").Width = 350
         .Columns(Entidades.Plantilla.Columnas.Sistema.ToString()).Header.Caption = "Sistema"
         .Columns(Entidades.Plantilla.Columnas.Sistema.ToString()).Width = 100
         .Columns(Entidades.Plantilla.Columnas.FilaInicial.ToString()).Header.Caption = "Fila Inicial"
         .Columns(Entidades.Plantilla.Columnas.FilaInicial.ToString()).Width = 80
         .Columns(Entidades.Plantilla.Columnas.FilaInicial.ToString()).CellAppearance.TextHAlign = HAlign.Right

         '# Columnas Contiene
         AgregarFiltroEnLinea(Me.dgvDatos, {"NombreProveedor", "NombrePlantilla"})
      End With
   End Sub

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.Selected.Cells.Count > 0 Then

            Dim cl As Reglas.Base = Me.GetReglas()
            Me._entidad = Me.GetEntidad()

            If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.Plantilla).IdPlantilla) Then
               If DirectCast(Me._entidad, Entidades.Plantilla).Sistema Then
                  MessageBox.Show("No se puede Eliminar la Plantilla porque es del Sistema.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Exit Sub
               End If
            End If

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

   'Protected Overrides Sub Editar()
   '   Try
   '      Dim cl As Reglas.Base = Me.GetReglas()
   '      Me._entidad = Me.GetEntidad()

   '      If Not String.IsNullOrEmpty(DirectCast(Me._entidad, Entidades.Plantilla).IdPlantilla) Then

   '         If DirectCast(Me._entidad, Entidades.Plantilla).Sistema Then
   '            MessageBox.Show("No se puede Editar porque la Plantilla es del Sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '            Exit Sub
   '         End If

   '      End If

   '      MyBase.Editar()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

#End Region

End Class