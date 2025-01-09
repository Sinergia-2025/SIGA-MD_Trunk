Option Strict Off
Imports Eniac.Win

Public Class AplicacionesEdicionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AplicacionesEdicionesDetalle(Me.GetEntidad())
      End If
      Return New AplicacionesEdicionesDetalle(New Eniac.Entidades.AplicacionEdicion())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.AplicacionesEdiciones
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = New Reglas.AplicacionesEdiciones()
               Me._entidad = Me.GetEntidad()
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.AplicacionesEdiciones().GetUno(.Cells("IdEdicion").Value.ToString(), .Cells("IdAplicacion").Value.ToString())
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns(Entidades.AplicacionEdicion.Columnas.IdAplicacion.ToString()).FormatearColumna("Aplicación", col, 100)

         .Columns(Entidades.AplicacionEdicion.Columnas.IdEdicion.ToString()).FormatearColumna("Edición", col, 70, , True)

         .Columns(Entidades.AplicacionEdicion.Columnas.NombreEdicion.ToString()).FormatearColumna("Nombre Edición", col, 250)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.AplicacionEdicion.Columnas.NombreEdicion.ToString()})

   End Sub

#End Region

End Class
