Public Class GrillaVencimientoLicencias
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("VencimientoLicencia").FormatearColumna("Venc. Licencia", pos, 88, HAlign.Center, , "dd/MM/yyyy")
         .Columns("DiasVencimientoLicencia").FormatearColumna("Días Licencia", pos, 80, HAlign.Right)
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetClientesVencimientoLicencias(filtros)
   End Function
End Class