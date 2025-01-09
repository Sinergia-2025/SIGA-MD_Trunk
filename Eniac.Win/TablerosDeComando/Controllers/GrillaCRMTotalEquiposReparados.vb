Public Class GrillaCRMTotalEquiposReparados
   Inherits GrillaController

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      Grilla.DisplayLayout.Bands(0).Columns.OfType(Of UltraGridColumn).ToList().    ''Where(Function(dc) dc.DataType = GetType(Decimal)).
         ForEach(Sub(dc)
                    dc.Hidden = False
                    If dc.DataType Is GetType(Integer) Then
                       dc.CellAppearance.TextHAlign = HAlign.Right
                       dc.Width = 80
                       dc.MinWidth = 50
                       dc.Format = "N0"
                    End If
                 End Sub)

      Grilla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
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
      Return rTablero.CRMTotalEquiposReparados(filtro)
   End Function

   'Private Sub _grilla_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles _grilla.InitializeRow
   '   _grilla.FindForm().TryCatched(Sub() PintarPerformance(e))
   'End Sub

   'Protected Sub PintarPerformance(e As InitializeRowEventArgs)
   '   If _dtPerformance IsNot Nothing Then
   '      Dim dr = _grilla.FilaSeleccionada(Of DataRow)(e.Row)
   '      If dr IsNot Nothing Then 'AndAlso dr.Field(Of Integer)("Posicion") = 0 Then
   '         Dim fecha = dr.Field(Of Date)("FechaEntregado")
   '         Dim drObj = _dtPerformance.Select(String.Format("Posicion = -10 AND PeriodoObjetivo = {0:yyyyMM}", fecha)).FirstOrDefault()
   '         Dim drMin = _dtPerformance.Select(String.Format("Posicion = -20 AND PeriodoObjetivo = {0:yyyyMM}", fecha)).FirstOrDefault()

   '         For Each dc In _grilla.DisplayLayout.Bands(0).Columns
   '            If drObj IsNot Nothing AndAlso dc.Key.StartsWith("____") Then
   '               Dim obj = drObj.Field(Of Decimal?)(dc.Key)

   '               If obj.HasValue Then
   '                  Dim min = If(drMin Is Nothing, 0, drMin.Field(Of Decimal?)(dc.Key).IfNull())
   '                  Dim perform = dr.Field(Of Integer?)(dc.Key).IfNull()

   '                  If perform < min Then
   '                     e.Row.Cells(dc).Color(Color.White, Color.Red)
   '                  ElseIf perform < obj.IfNull() Then
   '                     e.Row.Cells(dc).Color(Color.Black, Color.Yellow)
   '                  Else
   '                     e.Row.Cells(dc).Color(Color.Black, Color.Green)
   '                  End If
   '               End If

   '            End If
   '         Next
   '      End If
   '   End If
   'End Sub

End Class