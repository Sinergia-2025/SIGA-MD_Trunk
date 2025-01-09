Public Class GrillaCRMGlobalEntrega
   Inherits GrillaController

   Protected _idTipoNovedad As String
   Protected _descripciones As ICollection(Of String)

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
      Dim splt = panel.Parametros.Split(";"c)
      _idTipoNovedad = splt(0)
      If splt.Length > 1 Then
         _descripciones = splt(1).Split(","c)
      Else
         _descripciones = {"INGRESADOS", "ENTREGADOS", "FINALIZADOS", "TEP", "TFP"}
      End If
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)

         .Columns("Descripcion").FormatearColumna("", pos, 100).MinWidth = 50
         FormatearGrillaCamposPropios2(pos)

         For Each columna In Grilla.DisplayLayout.Bands(0).Columns
            If columna.Key.Contains("/") Then
               columna.FormatearColumna(columna.Key, pos, 80, HAlign.Right, , "N0", Formatos.MaskInput.CustomMaskInput(9, 0)).MinWidth = 50
            End If
         Next

         Grilla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      End With
   End Sub

   Protected Overridable Sub FormatearGrillaCamposPropios2(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("Hoy").FormatearColumna("Hoy", pos, 80, HAlign.Right, , "N0", Formatos.MaskInput.CustomMaskInput(9, 0)).MinWidth = 50
         .Columns("Acumulado").FormatearColumna("Acumulado", pos, 80, HAlign.Right, , "N0", Formatos.MaskInput.CustomMaskInput(9, 0)).MinWidth = 50
      End With
   End Sub

   Protected Overrides Sub AgregarTotales()
   End Sub
   Protected Overrides Sub FormatearGrillasPre(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPos(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub AgregarFiltrosEnLinea()
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable

      Return rTablero.GetCRMGlobalEntrega(New Entidades.TablerosDeComando.FiltroTableros(_idTipoNovedad, _descripciones))
   End Function

End Class