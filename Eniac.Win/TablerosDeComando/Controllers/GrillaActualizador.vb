Public Class GrillaActualizador
   Inherits GrillaController
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)
   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("Estado").FormatearColumna("Estado", pos, 70)

         .Columns("FechaInicioActualizacion").FormatearColumna("Fecha Inicio", pos, 70, HAlign.Center, , "dd/MM HH:mm")
         .Columns("FechaFinActualizacion").FormatearColumna("Fecha Fin", pos, 70, HAlign.Center, , "dd/MM HH:mm")
         .Columns("Activo_SN").FormatearColumna("Activo", pos, 80, HAlign.Right, True)

         .Columns("NombreServidor").FormatearColumna("Nombre Servidor", pos, 100)
         .Columns("BaseDatos").FormatearColumna("Base Datos", pos, 70)
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable 'categorias() As Entidades.Categoria, actualizarAplicacion As Entidades.Publicos.SiNoTodos) As DataTable
      Return rTablero.GetActualizadorAutomatico(filtros)
   End Function
End Class