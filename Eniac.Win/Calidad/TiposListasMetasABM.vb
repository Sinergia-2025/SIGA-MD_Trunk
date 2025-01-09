Public Class TiposListasMetasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposListasMetasDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoListaMeta))
      End If
      Return New TiposListasMetasDetalle(New Entidades.TipoListaMeta())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposListasMetas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.TipoListaMeta = New Entidades.TipoListaMeta()
      With Me.dgvDatos.ActiveCell.Row
         en.IdListaControlTipo = Integer.Parse(.Cells(Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString()).Value.ToString())
         en.Dia = Date.Parse(.Cells(Entidades.TipoListaMeta.Columnas.Dia.ToString()).Value.ToString())
         en = New Reglas.TiposListasMetas().GetUno(en.IdListaControlTipo, en.Dia)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns(Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString()).FormatearColumna("Lista", pos, 150, , True)
         .Columns(Entidades.ListaControlTipo.Columnas.NombreListaControlTipo.ToString()).FormatearColumna("Sección", pos, 150)
         .Columns(Entidades.TipoListaMeta.Columnas.Dia.ToString()).FormatearColumna("Dia", pos, 150, HAlign.Center)
         .Columns(Entidades.TipoListaMeta.Columnas.MetaCoches.ToString()).FormatearColumna("Meta Coches", pos, 80, HAlign.Right)
         .Columns(Entidades.TipoListaMeta.Columnas.IdUsuario.ToString()).FormatearColumna("Usuario", pos, 100, HAlign.Left)
         .Columns(Entidades.TipoListaMeta.Columnas.FechaModificacion.ToString()).FormatearColumna("Fecha", pos, 80, HAlign.Center)

      End With
   End Sub
#End Region

End Class