#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Eniac.Win
#End Region
Public Class EstadosListasControlABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosListasControlDetalle(DirectCast(Me.GetEntidad(), Entidades.EstadoListaControl))
      End If
      Return New EstadosListasControlDetalle(New Eniac.Entidades.EstadoListaControl())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.EstadosListasControl()
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
         Return New Reglas.EstadosListasControl().GetUno(Integer.Parse(.Cells(Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.EstadoListaControl.Columnas.NombreEstadoCalidad.ToString()).FormatearColumna("Descripción", col, 180)
         .Columns(Entidades.EstadoListaControl.Columnas.Posicion.ToString()).FormatearColumna("Posición", col, 70, HAlign.Right)
         .Columns(Entidades.EstadoListaControl.Columnas.Color.ToString()).FormatearColumna("Color", col, 80, HAlign.Right)

         .Columns(Entidades.EstadoListaControl.Columnas.Finalizado.ToString()).FormatearColumna("Finalizado (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.EstadoListaControl.Columnas.Finalizado.ToString() + "_SN").FormatearColumna("Finalizado", col, 70, HAlign.Center)

         .Columns(Entidades.EstadoListaControl.Columnas.PorDefecto.ToString()).FormatearColumna("Pred. (x)", col, 70, HAlign.Center, True)
         .Columns(Entidades.EstadoListaControl.Columnas.PorDefecto.ToString() + "_SN").FormatearColumna("Pred.", col, 70, HAlign.Center)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.EstadoListaControl.Columnas.NombreEstadoCalidad.ToString()})

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