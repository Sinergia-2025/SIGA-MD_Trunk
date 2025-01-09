Public Class GrillaCRMEntregasMensualesPorEstado
   Inherits GrillaController

   Protected _idTipoNovedad As String
   Protected _idEstados As ICollection(Of Integer)
   Protected _agrupadoPorUsuario As Boolean
   Protected _mesesHistoricos As Integer
   Private _totales As List(Of String)

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
      Dim splt = panel.Parametros.Split(";"c)
      _idTipoNovedad = splt(0)
      If splt.Length > 1 Then
         _idEstados = splt(1).Split(","c).ToList().ConvertAll(Function(s) Integer.Parse(s))
      Else
         _idEstados = {151, 150, 161, 130}
      End If
      _agrupadoPorUsuario = If(splt.Length > 2, Boolean.Parse(splt(2)), False)
      _mesesHistoricos = If(splt.Length > 3, Integer.Parse(splt(3)), Reglas.Publicos.RMACantidadMesesHistorico)
      _totales = New List(Of String)()
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)

         If _agrupadoPorUsuario Then
            .Columns("IdUsuarioAsignado").FormatearColumna("Usuario", pos, 100).MinWidth = 70
            .Columns("IdUsuarioAsignado").MergedCellStyle = MergedCellStyle.Always
            .Columns("IdUsuarioAsignado").MergedCellEvaluationType = MergedCellEvaluationType.MergeSameText
            .Columns("IdUsuarioAsignado").MergedCellAppearance.TextVAlign = VAlign.Middle
         End If
         .Columns("NombreEstadoNovedad").FormatearColumna("Estado", pos, 100).MinWidth = 100

         For Each columna In Grilla.DisplayLayout.Bands(0).Columns
            If columna.Key.Contains("-") Then
               Dim kys = columna.Key.Split("-"c)
               columna.FormatearColumna(String.Format("{0}/{1}", kys(1), kys(0)), pos, 70, HAlign.Right, , "N0", Formatos.MaskInput.CustomMaskInput(9, 0)).MinWidth = 50
               _totales.Add(columna.Key)
            End If
         Next

         Grilla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      End With
   End Sub

   Protected Overrides Sub AgregarTotales()
      If _totales IsNot Nothing Then
         Grilla.AgregarTotalesSuma(_totales.ToArray())
      End If
   End Sub
   Protected Overrides Sub FormatearGrillasPre(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPos(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub AgregarFiltrosEnLinea()
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetEntregasMensualesPorEstado(New Entidades.TablerosDeComando.FiltroTableros(_idTipoNovedad) With
                                                         {
                                                            .IdEstados = _idEstados,
                                                            .AgrupadoPorUsuario = _agrupadoPorUsuario,
                                                            .MesesHistoricos = _mesesHistoricos
                                                         })
   End Function

End Class