Imports Infragistics.Win.UltraWinGrid
Public Class GrillaDummy
   Inherits GrillaController

   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub

   Protected Overrides Sub AgregarTotales()
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPre(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPos(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub AgregarFiltrosEnLinea()
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return New DataTable()
   End Function
End Class
