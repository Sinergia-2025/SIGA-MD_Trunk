#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class EstadosTurnosABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosTurnosDetalle(DirectCast(Me.GetEntidad(), Entidades.EstadoTurno))
      End If
      Return New EstadosTurnosDetalle(New Entidades.EstadoTurno())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosTurnos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveCell.Row
         Return New Reglas.EstadosTurnos().GetUno(.Cells(Entidades.EstadoTurno.Columnas.IdEstadoTurno.ToString()).Value.ToString())
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.EstadoTurno.Columnas.IdEstadoTurno.ToString()).FormatearColumna("Código", pos, 100)
         .Columns(Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString()).FormatearColumna("Estado Turno", pos, 300)
         .Columns(Entidades.EstadoTurno.Columnas.Color.ToString()).FormatearColumna("Color", pos, 80, HAlign.Right)
         .Columns(Entidades.EstadoTurno.Columnas.Finalizado.ToString()).FormatearColumna("Finalizado", pos, 80, HAlign.Center)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString()})
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         Dim row As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
         If row IsNot Nothing Then
            Dim colorColumnKey As String = Entidades.EstadoPedido.Columnas.Color.ToString()
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