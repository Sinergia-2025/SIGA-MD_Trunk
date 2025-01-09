Public Class NavesABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New NavesDetalle(DirectCast(GetEntidad(), Entidades.Nave))
      End If
      Return New NavesDetalle(New Entidades.Nave)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Naves
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With dgvDatos.ActiveCell.Row
         Dim idNave = Short.Parse(.Cells(Entidades.Nave.Columnas.IdNave.ToString()).Value.ToString())
         Return New Reglas.Naves().GetUno(idNave)
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)

         For Each column As UltraGridColumn In .Columns
            column.CellActivation = Activation.ActivateOnly
         Next

         Dim pos = 0I
         .Columns(Entidades.Nave.Columnas.IdNave.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.Nave.Columnas.NombreNave.ToString()).FormatearColumna("Nombre", pos, 150)
         .Columns(Entidades.Nave.Columnas.NombrePC.ToString()).FormatearColumna("PC", pos, 150)
         .Columns(Entidades.Nave.Columnas.LimiteDeKilos.ToString()).FormatearColumna("LimiteDeKilos", pos, 70, HAlign.Right)
         .Columns(Entidades.Nave.Columnas.EnMantenimiento.ToString()).FormatearColumna("En Mant.", pos, 70)
         .Columns(Entidades.Nave.Columnas.IdTipoNave.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.TipoNave.Columnas.NombreTipoNave.ToString()).FormatearColumna("Tipo de nave", pos, 150)
      End With
   End Sub
#End Region

End Class