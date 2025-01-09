Public Class GrillaVersionApi
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("IdAplicacionMovil").FormatearColumna("Aplicación", pos, 70, HAlign.Center)
         .Columns("VersionAPI").FormatearColumna("Versión", pos, 70, HAlign.Center)
         .Columns("URLPropio").FormatearColumna("URL Propio", pos, 200)
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetVersionesApi(FILTROS)
   End Function
End Class