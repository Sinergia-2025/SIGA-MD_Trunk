Option Explicit On
Option Strict On

Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CargosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False

      Dim ugv As Infragistics.Win.UltraWinGrid.UltraGrid = Me.dgvDatos
      Ayudante.AgregarFiltroEnLinea(ugv, {"IdCargo", "NombreCargo", "NombreProducto"})

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CargosDetalle(DirectCast(Me.GetEntidad(), Entidades.Cargo))
      End If
      Return New CargosDetalle(New Entidades.Cargo())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Cargos()
   End Function
     
   Protected Overrides Sub Imprimir()
      'MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor
      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Cargos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, True)
      '   frmImprime.Text = "Productos"
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim car As Entidades.Cargo = New Entidades.Cargo
      With Me.dgvDatos.ActiveCell.Row
         car.IdCargo = Integer.Parse(.Cells(Entidades.Cargo.Columnas.IdCargo.ToString()).Value.ToString())
         car = New Reglas.Cargos().GetUno(car.IdCargo, car.IdTipoLiquidacion)
      End With
      Return car
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         For Each row As UltraGridColumn In .Columns
            row.CellActivation = Activation.ActivateOnly
         Next
         '.Columns(Entidades.Cargo.Columnas.IdSucursal.ToString()).Hidden = True

         .Columns(Entidades.Cargo.Columnas.IdCargo.ToString()).Header.Caption = "Código"
         .Columns(Entidades.Cargo.Columnas.IdCargo.ToString()).Width = 80
         .Columns(Entidades.Cargo.Columnas.IdCargo.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Cargo.Columnas.IdCargo.ToString()).Header.VisiblePosition = 0


         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).Width = 250
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).Header.VisiblePosition = 1
         ''.Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         .Columns(Entidades.Cargo.Columnas.Monto.ToString()).Header.Caption = "Monto"
         .Columns(Entidades.Cargo.Columnas.Monto.ToString()).Width = 80
         .Columns(Entidades.Cargo.Columnas.Monto.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Cargo.Columnas.Monto.ToString()).Header.VisiblePosition = 2

         .Columns(Entidades.Cargo.Columnas.IdProducto.ToString()).Header.Caption = "Producto"
         .Columns(Entidades.Cargo.Columnas.IdProducto.ToString()).Width = 80
         .Columns(Entidades.Cargo.Columnas.IdProducto.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Cargo.Columnas.IdProducto.ToString()).Header.VisiblePosition = 3

         .Columns(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString()).Header.Caption = "Nombre Producto"
         .Columns(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString()).Width = 250
         .Columns(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString()).Header.VisiblePosition = 4

         .Columns(Entidades.Cargo.Columnas.Activo.ToString()).Header.Caption = "Activo"
         .Columns(Entidades.Cargo.Columnas.Activo.ToString()).Width = 60

         .Columns(Entidades.Cargo.Columnas.ImprimeVoucher.ToString()).Header.Caption = "Imprime Voucher"
         .Columns(Entidades.Cargo.Columnas.ImprimeVoucher.ToString()).Width = 70
         .Columns(Entidades.Cargo.Columnas.ImprimeVoucher.ToString()).Hidden = True

         .Columns(Entidades.Cargo.Columnas.CantidadMeses.ToString()).Header.Caption = "Cantidad Meses"
         .Columns(Entidades.Cargo.Columnas.CantidadMeses.ToString()).Width = 70
         .Columns(Entidades.Cargo.Columnas.CantidadMeses.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Cargo.Columnas.CantidadMeses.ToString()).Hidden = True

         .Columns(Entidades.Cargo.Columnas.ModificaImporte.ToString()).Header.Caption = "Modifica Importe"
         .Columns(Entidades.Cargo.Columnas.ModificaImporte.ToString()).Width = 70

         .Columns(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).Header.Caption = "Modifica Cantidad"
         .Columns(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).Width = 70

         .Columns(Entidades.Cargo.Columnas.CantidadCuotas.ToString()).Header.Caption = "Cantidad Cuotas"
         .Columns(Entidades.Cargo.Columnas.CantidadCuotas.ToString()).Width = 70
         .Columns(Entidades.Cargo.Columnas.CantidadCuotas.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Cargo.Columnas.CantidadCuotas.ToString()).Hidden = True

         .Columns(Entidades.Cargo.Columnas.CuotaActual.ToString()).Header.Caption = "Cuota Actual"
         .Columns(Entidades.Cargo.Columnas.CuotaActual.ToString()).Width = 70
         .Columns(Entidades.Cargo.Columnas.CuotaActual.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Cargo.Columnas.CuotaActual.ToString()).Hidden = True

         .Columns(Entidades.Cargo.ColumnasCargos.MontoOriginal.ToString()).Hidden = True

         .Columns(Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString()).Hidden = True

         .Columns("NombreTipoLiquidacion").Header.Caption = "Tipo Liquidación"
         .Columns("NombreTipoLiquidacion").Width = 100

         .Columns(Entidades.Cargo.Columnas.CargoTemporal.ToString()).Header.Caption = "Cargo Temporal"
         .Columns(Entidades.Cargo.Columnas.CargoTemporal.ToString()).Width = 70

      End With
   End Sub

#End Region

End Class