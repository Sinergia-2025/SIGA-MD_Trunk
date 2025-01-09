#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TiposVehiculosABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposVehiculosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.TipoVehiculo))
      End If
      Return New TiposVehiculosDetalle(New Eniac.Entidades.TipoVehiculo)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposVehiculos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim TipoVehiculo As Eniac.Entidades.TipoVehiculo = New Eniac.Entidades.TipoVehiculo
      With Me.dgvDatos.ActiveRow
         TipoVehiculo = New Eniac.Reglas.TiposVehiculos().GetUno(Integer.Parse(.Cells("IdTipoVehiculo").Value.ToString()))
      End With
      Return TipoVehiculo
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Eniac.Entidades.TipoVehiculo.Columnas.NombreTipoVehiculo.ToString()).FormatearColumna("Nombre", col, 400)
         .Columns(Eniac.Entidades.TipoVehiculo.Columnas.CapacidadMaxima.ToString()).FormatearColumna("Cap. Máxima", col, 80, HAlign.Right)
      End With
   End Sub
#End Region
End Class