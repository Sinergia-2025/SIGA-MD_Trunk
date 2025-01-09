#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TareasProgramadasABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TareasProgramadasDetalle(DirectCast(Me.GetEntidad(), Entidades.TareaProgramada))
      End If
      Return New TareasProgramadasDetalle(New Eniac.Entidades.TareaProgramada())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.TareasProgramadas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.TareasProgramadas().GetUno(Integer.Parse(.Cells(Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns(Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.TareaProgramada.Columnas.IdFuncion.ToString()).FormatearColumna("Id Función", pos, 100)
         .Columns("NombreFuncion").FormatearColumna("Función", pos, 200)
         .Columns(Entidades.TareaProgramada.Columnas.Observacion.ToString()).FormatearColumna("Observción", pos, 170)

         .Columns(Entidades.TareaProgramada.Columnas.Usuario.ToString()).FormatearColumna("Usuario", pos, 80)
         .Columns(Entidades.TareaProgramada.Columnas.UltimaFechaEjecucion.ToString()).FormatearColumna("Última Ejecución", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm:ss")

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.TareaProgramada.Columnas.IdFuncion.ToString(), Entidades.TareaProgramada.Columnas.Observacion.ToString()})
   End Sub

#End Region

End Class