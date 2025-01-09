#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class EstadosClientesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosClientesDetalle(DirectCast(Me.GetEntidad(), Entidades.EstadoCliente))
      End If
      Return New EstadosClientesDetalle(New Entidades.EstadoCliente())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosClientes()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveCell.Row
         Return New Reglas.EstadosClientes().GetUno(Integer.Parse(.Cells(Entidades.EstadoCliente.Columnas.IdEstadoCliente.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.EstadoCliente.Columnas.IdEstadoCliente.ToString()).FormatearColumna("Código", pos, 100)
         .Columns(Entidades.EstadoCliente.Columnas.NombreEstadoCliente.ToString()).FormatearColumna("Estado Cliente", pos, 300)
         .Columns(Entidades.EstadoCliente.Columnas.Color.ToString()).FormatearColumna("Color", pos, 80, HAlign.Right)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.EstadoCliente.Columnas.NombreEstadoCliente.ToString()})
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