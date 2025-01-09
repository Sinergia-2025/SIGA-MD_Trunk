Public Class GrillaCRMSituacionPorEstado
   Inherits GrillaCRMSituacionPorTipoEstado

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub

   Protected Overrides Sub FormatearGrillaCamposPropios2(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("NombreEstadoNovedad").FormatearColumna("Estado", pos, 100).MinWidth = 50
         .Columns("PosicionEstado").OcultoPosicion(True, pos)
      End With
   End Sub

   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      _dtCompleto = rTablero.GetCRMSituacionPorTipoEstado(New Entidades.TablerosDeComando.FiltroTableros(_panel.Parametros), mostrarDetalleEstados:=True)
      Dim drCol = _dtCompleto.Select("Posicion >= 0")
      Return If(drCol.Length > 0, drCol.CopyToDataTable(), _dtCompleto)
   End Function

   Private Sub _grilla_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles _grilla.InitializeRow
      Try
         PintarPerformance(e)
      Catch ex As Exception
         _grilla.FindForm().ShowError(ex)
      End Try
   End Sub

End Class