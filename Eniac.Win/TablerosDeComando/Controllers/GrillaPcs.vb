Public Class GrillaPcs
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("CantidadDePCs").FormatearColumna("Cantidad de PCs", pos, 70, HAlign.Right)
         .Columns("PCsCliente").FormatearColumna("Cantidad de PCs", pos, 70, HAlign.Right)
         .Columns("DeltaPC").FormatearColumna("Dif.", pos, 40, HAlign.Right)
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetClientesPCs(filtros)
   End Function
End Class