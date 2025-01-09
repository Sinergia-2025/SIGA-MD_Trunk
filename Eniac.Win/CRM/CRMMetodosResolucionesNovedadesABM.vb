Option Strict On
Option Explicit On

Imports Eniac.Win
Public Class CRMMetodosResolucionesNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMMetodosResolucionesNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMMetodoResolucionNovedad))
      End If
      Return New CRMMetodosResolucionesNovedadesDetalle(New Eniac.Entidades.CRMMetodoResolucionNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMMetodosResolucionesNovedades()
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
         Return New Reglas.CRMMetodosResolucionesNovedades().GetUno(Integer.Parse(.Cells(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).Header.VisiblePosition = 0
         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).Width = 100

         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).Header.Caption = "Código"
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).Header.VisiblePosition = 1
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).Width = 60
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).Header.Caption = "Descripción"
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).Header.VisiblePosition = 2
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).Width = 180

         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.Posicion.ToString()).Header.Caption = "Posición"
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.Posicion.ToString()).Header.VisiblePosition = 3
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.Posicion.ToString()).Width = 70
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.Posicion.ToString()).CellAppearance.TextHAlign = HAlign.Right

         '.Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString()).Header.Caption = "Tipo"
         '.Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString()).Header.VisiblePosition = 3
         '.Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString()).Width = 60
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString()).Hidden = True

         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString()).Header.Caption = "Pred."
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString()).Header.VisiblePosition = 4
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString()).Width = 50
         .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString()).CellAppearance.TextHAlign = HAlign.Center

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()})
   End Sub

#End Region

End Class