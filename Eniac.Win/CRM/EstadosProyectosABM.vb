#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Eniac.Win
#End Region

Public Class EstadosProyectosABM


#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Me.BotonImprimir.Visible = False
    End Sub

    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New EstadosProyectosDetalle(DirectCast(Me.GetEntidad(), Entidades.ProyectoEstado))
        End If
        Return New EstadosProyectosDetalle(New Eniac.Entidades.ProyectoEstado())
    End Function

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.ProyectosEstados()
    End Function

    Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
        MyBase.GetEntidad()
        With Me.dgvDatos.ActiveRow
            Return New Reglas.ProyectosEstados().GetUno(Integer.Parse(.Cells(Entidades.ProyectoEstado.Columnas.IdEstado.ToString()).Value.ToString()))
        End With
    End Function
    Protected Overrides Sub FormatearGrilla()

      Try

         With Me.dgvDatos.DisplayLayout.Bands(0)

            Dim col As Integer = 0

            .Columns(Entidades.ProyectoEstado.Columnas.IdEstado.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
            .Columns(Entidades.ProyectoEstado.Columnas.NombreEstado.ToString()).FormatearColumna("Descripción", col, 180)
            .Columns(Entidades.ProyectoEstado.Columnas.Color.ToString()).FormatearColumna("Color", col, 80, HAlign.Right)
            .Columns(Entidades.ProyectoEstado.Columnas.Finalizado.ToString()).FormatearColumna("Finalizado (x)", col, 70, HAlign.Center, True)
            .Columns(Entidades.ProyectoEstado.Columnas.Finalizado.ToString() + "_SN").FormatearColumna("Finalizado", col, 70, HAlign.Center)
            .Columns(Entidades.ProyectoEstado.Columnas.Posicion.ToString()).FormatearColumna("Posicion", col, 60, HAlign.Right)

         End With

         ' Agrego el Filtro en Linea x Descripción de la clase
         AgregarFiltroEnLinea(dgvDatos, {Entidades.ProyectoEstado.Columnas.NombreEstado.ToString()})
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

#Region "Eventos"

    Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
        Try
            If e.Row IsNot Nothing AndAlso
               e.Row.ListObject IsNot Nothing AndAlso
               TypeOf (e.Row.ListObject) Is DataRowView AndAlso
               DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
                Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
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