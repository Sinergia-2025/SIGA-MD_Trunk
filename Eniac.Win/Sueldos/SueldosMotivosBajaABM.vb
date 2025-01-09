Public Class SueldosMotivosBajaABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosMotivosBajaDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosMotivoBaja))
      End If
      Return New SueldosMotivosBajaDetalle(New Entidades.SueldosMotivoBaja())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosMotivosBaja()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ent As Entidades.SueldosMotivoBaja = New Entidades.SueldosMotivoBaja()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         ent = New Reglas.SueldosMotivosBaja().GetUno(Integer.Parse(.Cells(Entidades.SueldosMotivoBaja.Columnas.IdMotivoBaja.ToString()).Value.ToString()))
      End With
      Return ent
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         .Columns(Entidades.SueldosMotivoBaja.Columnas.IdMotivoBaja.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosMotivoBaja.Columnas.IdMotivoBaja.ToString()).Width = 70
         .Columns(Entidades.SueldosMotivoBaja.Columnas.IdMotivoBaja.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosMotivoBaja.Columnas.NombreMotivoBaja.ToString()).HeaderText = "Nombre Motivo de Baja"
         .Columns(Entidades.SueldosMotivoBaja.Columnas.NombreMotivoBaja.ToString()).Width = 120
         .Columns(Entidades.SueldosMotivoBaja.Columnas.NombreMotivoBaja.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class