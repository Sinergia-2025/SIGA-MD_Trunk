Imports Infragistics.Win.UltraWinGrid
Public Class GrillaCRMSituacionPorTipoEstado
   Inherits GrillaController

   Protected _dtCompleto As DataTable

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)

         .Columns("NombreTipoEstadoNovedad").FormatearColumna("Tipo Estado", pos, 100).MinWidth = 50
         .Columns("Posicion").OcultoPosicion(True, pos)

         FormatearGrillaCamposPropios2(pos)

         For Each columna In Grilla.DisplayLayout.Bands(0).Columns
            If columna.Key.StartsWith("____") Then
               columna.FormatearColumna(columna.Key.Replace("____", ""), pos, 80, HAlign.Right, , "N0", Formatos.MaskInput.CustomMaskInput(9, 0)).MinWidth = 50
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
      _dtCompleto = rTablero.GetCRMSituacionPorTipoEstado(New Entidades.TablerosDeComando.FiltroTableros(_panel.Parametros), mostrarDetalleEstados:=False)
      Dim drCol = _dtCompleto.Select("Posicion >= 0")
      Return If(drCol.Length > 0, drCol.CopyToDataTable(), _dtCompleto) '_dtCompleto.Select("Posicion >= 0").CopyToDataTable()
   End Function

   Private Sub _grilla_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles _grilla.InitializeRow
      Try
         PintarPerformance(e)
      Catch ex As Exception
         _grilla.FindForm().ShowError(ex)
      End Try
   End Sub

   Protected Sub PintarPerformance(e As InitializeRowEventArgs)
      If _dtCompleto IsNot Nothing Then
         Dim dr = _grilla.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing AndAlso dr.Field(Of Integer)("Posicion") = 0 Then
            Dim drObj = _dtCompleto.Select("Posicion = -10").FirstOrDefault()
            Dim drMin = _dtCompleto.Select("Posicion = -20").FirstOrDefault()

            For Each dc In _grilla.DisplayLayout.Bands(0).Columns
               If drObj IsNot Nothing AndAlso dc.Key.StartsWith("____") Then
                  Dim obj = drObj.Field(Of Decimal?)(dc.Key)

                  If obj.HasValue Then
                     Dim min = If(drMin Is Nothing, 0, drMin.Field(Of Decimal?)(dc.Key).IfNull())
                     Dim perform = dr.Field(Of Decimal?)(dc.Key).IfNull()

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