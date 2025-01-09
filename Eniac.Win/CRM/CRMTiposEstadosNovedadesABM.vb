Option Strict On
Option Explicit On

Imports Eniac.Win
Public Class CRMTiposEstadosNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMTiposEstadosNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMTipoEstadoNovedad))
      End If
      Return New CRMTiposEstadosNovedadesDetalle(New Eniac.Entidades.CRMTipoEstadoNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMTiposEstadosNovedades()
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
               Dim cl As Reglas.Base = GetReglas()
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
         Return New Reglas.CRMTiposEstadosNovedades().GetUno(Integer.Parse(.Cells(Entidades.CRMTipoEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      Dim pos As Integer = 0
      With Me.dgvDatos.DisplayLayout.Bands(0)

         .Columns(Entidades.CRMTipoEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)

         .Columns(Entidades.CRMTipoEstadoNovedad.Columnas.NombreTipoEstadoNovedad.ToString()).FormatearColumna("Descripción", pos, 180, HAlign.Left)

         .Columns(Entidades.CRMTipoEstadoNovedad.Columnas.Posicion.ToString()).FormatearColumna("Posición", pos, 70, HAlign.Right)

         .Columns(Entidades.CRMTipoEstadoNovedad.Columnas.IdTipoNovedad.ToString()).FormatearColumna("IdTipoNovedad", pos, 80, HAlign.Right, True)
         .Columns("NombreTipoNovedad").FormatearColumna("Tipo", pos, 130, HAlign.Left)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMTipoEstadoNovedad.Columnas.NombreTipoEstadoNovedad.ToString()})
   End Sub

#End Region

  
End Class