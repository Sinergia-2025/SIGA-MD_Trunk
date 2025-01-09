Option Explicit On
Option Strict On

'Imports Eniac.SiPrueba.Win
Imports Eniac.Win
Public Class ContabilidadAsientosModeloABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetAll(rg As Reglas.Base) As Object
      Return DirectCast(rg, Reglas.ContabilidadAsientosModelos).GetAllDistinct()
   End Function

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Dim frmDetalle As New ContabilidadAsientosModeloDetalle(DirectCast(Me.GetEntidad(), Entidades.ContabilidadAsientoModelo))
         Return frmDetalle
      End If
      Return New ContabilidadAsientosModeloDetalle(New Entidades.ContabilidadAsientoModelo)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadAsientosModelos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim Asiento As Entidades.ContabilidadAsientoModelo = New Entidades.ContabilidadAsientoModelo
      Dim Asientos As Reglas.ContabilidadAsientosModelos = New Reglas.ContabilidadAsientosModelos()

      With Me.dgvDatos.SelectedCells(0).OwningRow
         Asiento = Asientos.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadAsientoModelo.Columnas.IdPlanCuenta.ToString()).Value.ToString()), Integer.Parse(.Cells(Entidades.ContabilidadAsientoModelo.Columnas.IdAsiento.ToString()).Value.ToString()))
      End With

      Return Asiento

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos

         .Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombrePlanCuenta.ToString()).HeaderText = "Plan Cuenta"
         .Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombrePlanCuenta.ToString()).Width = 90

         .Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombreAsiento.ToString()).HeaderText = "Concepto"
         .Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombreAsiento.ToString()).Width = 250

         '.Columns(Entidades.ContabilidadAsientoModelo.Columnas.idCuenta.ToString()).HeaderText = "Cod Cuenta"
         '.Columns(Entidades.ContabilidadAsientoModelo.Columnas.idCuenta.ToString()).Width = 70
         '.Columns(Entidades.ContabilidadAsientoModelo.Columnas.idCuenta.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         '.Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombreCuenta.ToString()).HeaderText = "Cuenta"
         '.Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombreCuenta.ToString()).Width = 120
         '.Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombreCuenta.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         .Columns(Entidades.ContabilidadAsientoModelo.Columnas.IdPlanCuenta.ToString()).Visible = False
         .Columns(Entidades.ContabilidadAsientoModelo.Columnas.IdAsiento.ToString()).Visible = False
      End With
   End Sub

#End Region

End Class