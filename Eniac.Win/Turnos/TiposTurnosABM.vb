Public Class TiposTurnosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposTurnosDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoTurno))
      End If
      Return New TiposTurnosDetalle(New Eniac.Entidades.TipoTurno())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.TiposTurnos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.TiposTurnos().GetUno(.Cells(Entidades.TipoTurno.Columnas.IdTipoTurno.ToString()).Value.ToString())
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TipoTurno.Columnas.IdTipoTurno.ToString()).FormatearColumna("Id", col, 70)
         .Columns(Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString()).FormatearColumna("Nombre", col, 200)
         .Columns(Entidades.TipoTurno.Columnas.IdTipoCalendario.ToString()).OcultoPosicion(True, col)
         .Columns(Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString()).FormatearColumna("Tipo Calendario", col, 200)
      End With
   End Sub

#End Region

End Class