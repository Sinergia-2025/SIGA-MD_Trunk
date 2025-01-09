Public Class GrillaCRMGlobalEntregaHistorico
   Inherits GrillaCRMGlobalEntrega

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub

   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetCRMGlobalEntregaHistorico(New Entidades.TablerosDeComando.FiltroTableros(_idTipoNovedad, _descripciones))
   End Function

   Protected Overrides Sub FormatearGrillaCamposPropios2(ByRef pos As Integer)
   End Sub
End Class