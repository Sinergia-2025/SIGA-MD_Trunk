Option Strict Off
Public Class SueldosTiposRecibosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
      'Me.BotonEditar.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosTiposRecibosDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosTipoRecibo))
      End If
      Return New SueldosTiposRecibosDetalle(New Entidades.SueldosTipoRecibo)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosTiposRecibos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim zona As Entidades.SueldosTipoRecibo = New Entidades.SueldosTipoRecibo()
      With Me.dgvDatos.SelectedCells(0).OwningRow
         zona.IdTipoRecibo = .Cells(Entidades.SueldosTipoRecibo.Columnas.IdTipoRecibo.ToString()).Value.ToString()
         zona = New Reglas.SueldosTiposRecibos().GetUno(zona.IdTipoRecibo)
      End With
      Return zona
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos
         .Columns(Entidades.SueldosTipoRecibo.Columnas.IdTipoRecibo.ToString()).HeaderText = "Código"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.IdTipoRecibo.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoRecibo.Columnas.IdTipoRecibo.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NombreTipoRecibo.ToString()).HeaderText = "Nombre de Tipo de Recibo"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NombreTipoRecibo.ToString()).Width = 120
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NombreTipoRecibo.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns(Entidades.SueldosTipoRecibo.Columnas.PeriodoLiquidacion.ToString()).HeaderText = "Período"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.PeriodoLiquidacion.ToString()).Width = 60
         .Columns(Entidades.SueldosTipoRecibo.Columnas.PeriodoLiquidacion.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NumeroLiquidacion.ToString()).HeaderText = "Numero Liquidacion"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NumeroLiquidacion.ToString()).Width = 70
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NumeroLiquidacion.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.SueldosTipoRecibo.Columnas.ImprimeRecibo.ToString()).HeaderText = "Imprime Recibo"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.ImprimeRecibo.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoRecibo.Columnas.ImprimeRecibo.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquid.ToString()).HeaderText = "Cant. Liq."
         .Columns(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquid.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquid.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquidPeriodo.ToString()).HeaderText = "Cant. Liq. Período"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquidPeriodo.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquidPeriodo.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns(Entidades.SueldosTipoRecibo.Columnas.FechaPago.ToString()).HeaderText = "Fecha Pago"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.FechaPago.ToString()).Width = 70
         .Columns(Entidades.SueldosTipoRecibo.Columnas.FechaPago.ToString()).DefaultCellStyle.Format = "dd/MM/yyyy"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.NumeroLiquidacion.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns(Entidades.SueldosTipoRecibo.Columnas.LiquidacionEventual.ToString()).HeaderText = "Eventual"
         .Columns(Entidades.SueldosTipoRecibo.Columnas.LiquidacionEventual.ToString()).Width = 50
         .Columns(Entidades.SueldosTipoRecibo.Columnas.LiquidacionEventual.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      End With

   End Sub

#End Region

End Class