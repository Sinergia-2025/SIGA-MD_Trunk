Public Class GrillaLargada
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("FechaInicio").FormatearColumna("Inicio Pactado", pos, 70, HAlign.Left, , "dd/MM/yyyy")
         .Columns("FechaInicioReal").FormatearColumna("Inicio Real", pos, 70, HAlign.Left, , "dd/MM/yyyy")
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetFechaLargada(filtros)
   End Function
End Class