Public Class TiposUsuariosABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposUsuariosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.TipoUsuario))
      End If
      Return New TiposUsuariosDetalle(New Eniac.Entidades.TipoUsuario)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposUsuarios()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim Clasificacion As Eniac.Entidades.TipoUsuario = New Eniac.Entidades.TipoUsuario
      With Me.dgvDatos.ActiveRow
         Clasificacion = New Eniac.Reglas.TiposUsuarios().GetUno(Integer.Parse(.Cells("IdTipoUsuario").Value.ToString()))
      End With
      Return Clasificacion
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.TipoUsuario.Columnas.IdTipoUsuario.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Eniac.Entidades.TipoUsuario.Columnas.NombreTipoUsuario.ToString()).FormatearColumna("Nombre", col, 400)
         .Columns(Eniac.Entidades.TipoUsuario.Columnas.EsDeProceso.ToString()).FormatearColumna("Es de proceso", col, 400)
      End With
   End Sub
#End Region
End Class