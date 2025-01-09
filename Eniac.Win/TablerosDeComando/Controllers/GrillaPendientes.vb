Public Class GrillaPendientes
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("NombreEstadoNovedad").FormatearColumna("Estado", pos, 100).MinWidth = 50
         .Columns("NombreUsuarioAsignado").FormatearColumna("Asignado", pos, 100).MinWidth = 50
         .Columns("CantidadEstadoNovedad").FormatearColumna("Cantidad", pos, 40, HAlign.Right, , "N0").MinWidth = 30
         Grilla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      End With
   End Sub
   Protected Overrides Sub AgregarTotales()
      Grilla.AgregarTotalesSuma({Ayudante.Grilla.ArmarColumnaFormatoParaTotales("CantidadEstadoNovedad", Ayudante.Grilla.FormatoTotals0Decimales)})
   End Sub
   Protected Overrides Sub FormatearGrillasPre(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPos(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub AgregarFiltrosEnLinea()
      Grilla.AgregarFiltroEnLinea({"NombreUsuarioAsignado"})
      Grilla.SetGroupByVisible(True)
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetPendientes()
   End Function
   Private Sub _grilla_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles _grilla.InitializeRow
      Try
         Dim colorInteger As Integer? = Nothing
         If IsNumeric(e.Row.Cells("ColorEstadoNovedad").Value) Then
            colorInteger = Integer.Parse(e.Row.Cells("ColorEstadoNovedad").Value.ToString())
         End If

         If colorInteger.HasValue Then
            e.Row.Cells("NombreEstadoNovedad").Appearance.BackColor = Color.FromArgb(colorInteger.Value)
            e.Row.Cells("NombreEstadoNovedad").ActiveAppearance.BackColor = Color.FromArgb(colorInteger.Value)
         End If

         Dim cantidadTickets As Integer = 0
         If IsNumeric(e.Row.Cells("CantidadEstadoNovedad").Value) Then
            cantidadTickets = Integer.Parse(e.Row.Cells("CantidadEstadoNovedad").Value.ToString())
         End If
         Dim backColorCantidadTickets As Color? = Nothing
         Dim foreColorCantidadTickets As Color? = Nothing
         If cantidadTickets > 60 Then
            backColorCantidadTickets = Color.Red
            foreColorCantidadTickets = Color.White
         ElseIf cantidadTickets > 40 Then
            backColorCantidadTickets = Color.Orange
            foreColorCantidadTickets = Color.Black
         ElseIf cantidadTickets > 20 Then
            backColorCantidadTickets = Color.Yellow
            foreColorCantidadTickets = Color.Black
         End If

         If backColorCantidadTickets.HasValue Then
            e.Row.Cells("CantidadEstadoNovedad").Appearance.BackColor = backColorCantidadTickets.Value
            e.Row.Cells("CantidadEstadoNovedad").ActiveAppearance.BackColor = backColorCantidadTickets.Value
         End If
         If foreColorCantidadTickets.HasValue Then
            e.Row.Cells("CantidadEstadoNovedad").Appearance.ForeColor = foreColorCantidadTickets.Value
            e.Row.Cells("CantidadEstadoNovedad").ActiveAppearance.ForeColor = foreColorCantidadTickets.Value
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class