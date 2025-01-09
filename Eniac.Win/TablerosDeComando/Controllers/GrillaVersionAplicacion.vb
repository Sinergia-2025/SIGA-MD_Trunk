Public Class GrillaVersionAplicacion
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("NroVersion").FormatearColumna("Número Versión", pos, 70, HAlign.Center)
         .Columns("FechaActualizacionVersion").FormatearColumna("Fecha Versión", pos, 65, HAlign.Center)
         .Columns("DiasVersion").FormatearColumna("Dias Versión", pos, 50, HAlign.Right)
         .Columns("NroVersionBackup").FormatearColumna("Versión Backup", pos, 70, HAlign.Center)
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetClientesVersiones(filtros)
   End Function
End Class