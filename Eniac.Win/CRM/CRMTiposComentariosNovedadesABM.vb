#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class CRMTiposComentariosNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMTiposComentariosNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMTipoComentarioNovedad))
      End If
      Return New CRMTiposComentariosNovedadesDetalle(New Eniac.Entidades.CRMTipoComentarioNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMTiposComentariosNovedades()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return New Reglas.CRMTiposComentariosNovedades().GetUno(dr.Field(Of Integer)(Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString()))
   End Function
   Protected Overrides Sub FormatearGrilla()

      Dim col As Integer = 0
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString()).OcultoPosicion(True, col)

         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", col, 100)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString()).FormatearColumna("Descripción", col, 180)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.Posicion.ToString()).FormatearColumna("Posición", col, 70, HAlign.Right)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.Color.ToString()).FormatearColumna("Color", col, 80, HAlign.Right)

         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString()).FormatearColumna("Pred. (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString() + "_SN").FormatearColumna("Pred.", col, 70, HAlign.Center)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaCliente.ToString()).FormatearColumna("P/Cliente (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaCliente.ToString() + "_SN").FormatearColumna("P/Cliente", col, 70, HAlign.Center)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaRepresentante.ToString()).FormatearColumna("P/Repres. (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaRepresentante.ToString() + "_SN").FormatearColumna("P/Repres.", col, 70, HAlign.Center)

      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString()})
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         Dim row As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
         If row IsNot Nothing Then
            Dim colorColumnKey As String = Entidades.CRMTipoComentarioNovedad.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class