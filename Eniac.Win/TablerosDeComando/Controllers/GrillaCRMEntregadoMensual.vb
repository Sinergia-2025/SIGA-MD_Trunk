Public Class GrillaCRMEntregadoMensual
   Inherits GrillaController

   Dim _dtPerformance As DataTable

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)

         .Columns("FechaEntregado").FormatearColumna("Periodo", pos, 100, HAlign.Center, , "MM/yyyy").MinWidth = 50

         FormatearGrillaCamposPropios2(pos)

         For Each columna In Grilla.DisplayLayout.Bands(0).Columns
            If columna.Key.StartsWith("____") Then
               columna.FormatearColumna(columna.Key.Replace("____", ""), pos, 80, HAlign.Right, , "N0").MinWidth = 50
            End If
         Next

         .Columns("Total").FormatearColumna("Total", pos, 80, HAlign.Right, , "N0").MinWidth = 50

         Grilla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      End With
   End Sub
   Protected Overridable Sub FormatearGrillaCamposPropios2(ByRef pos As Integer)

   End Sub
   Protected Overrides Sub AgregarTotales()
      'Grilla.AgregarTotalesSuma({Ayudante.Grilla.ArmarColumnaFormatoParaTotales("CantidadEstadoNovedad", Ayudante.Grilla.FormatoTotals0Decimales)})
   End Sub
   Protected Overrides Sub FormatearGrillasPre(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPos(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub AgregarFiltrosEnLinea()
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim filtro = New Entidades.TablerosDeComando.FiltroTableros(_panel.Parametros)
      Dim result = rTablero.GetCRMEntregadoMensual(filtro)
      _dtPerformance = rTablero.GetPerformanceParaCRMEntregadoMensual(filtro)
      Return result
   End Function

   Private Sub _grilla_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles _grilla.InitializeRow
      _grilla.FindForm().TryCatched(Sub() PintarPerformance(e))
   End Sub

   Protected Sub PintarPerformance(e As InitializeRowEventArgs)
      If _dtPerformance IsNot Nothing Then
         Dim dr = _grilla.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing Then 'AndAlso dr.Field(Of Integer)("Posicion") = 0 Then
            Dim fecha = dr.Field(Of Date)("FechaEntregado")
            Dim drObj = _dtPerformance.Select(String.Format("Posicion = -10 AND PeriodoObjetivo = {0:yyyyMM}", fecha)).FirstOrDefault()
            Dim drMin = _dtPerformance.Select(String.Format("Posicion = -20 AND PeriodoObjetivo = {0:yyyyMM}", fecha)).FirstOrDefault()

            For Each dc In _grilla.DisplayLayout.Bands(0).Columns
               If drObj IsNot Nothing AndAlso dc.Key.StartsWith("____") Then
                  Dim obj = drObj.Field(Of Decimal?)(dc.Key)

                  If obj.HasValue Then
                     Dim min = If(drMin Is Nothing, 0, drMin.Field(Of Decimal?)(dc.Key).IfNull())
                     Dim perform = dr.Field(Of Integer?)(dc.Key).IfNull()

                     If perform < min Then
                        e.Row.Cells(dc).Color(Color.White, Color.Red)
                     ElseIf perform < obj.IfNull() Then
                        e.Row.Cells(dc).Color(Color.Black, Color.Yellow)
                     Else
                        e.Row.Cells(dc).Color(Color.Black, Color.Green)
                     End If
                  End If

               End If
            Next
         End If
      End If
   End Sub

End Class