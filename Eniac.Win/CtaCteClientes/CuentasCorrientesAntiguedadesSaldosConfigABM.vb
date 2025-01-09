Public Class CuentasCorrientesAntiguedadesSaldosConfigABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CuentasCorrientesAntiguedadesSaldosConfigDetalle(DirectCast(GetEntidad(), Entidades.CuentaCorrienteAntiguedadSaldoConfig))
      End If
      Return New CuentasCorrientesAntiguedadesSaldosConfigDetalle(New Entidades.CuentaCorrienteAntiguedadSaldoConfig())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasCorrientesAntiguedadesSaldosConfig()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.CuentasCorrientesAntiguedadesSaldosConfig().GetUno(Integer.Parse(.Cells(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.CellActivation = Activation.ActivateOnly
         Next
         Dim pos = 0I
         .Columns(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.NombreAntiguedadSaldoConfig.ToString()).FormatearColumna("Nombre", pos, 300)
         .Columns(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.TipoAntiguedadSaldoConfig.ToString()).FormatearColumna("Tipo Antigüedad de Saldo", pos, 100)
         .Columns(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.PorDefecto.ToString()).FormatearColumna("Por Defecto", pos, 70, HAlign.Center)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.NombreAntiguedadSaldoConfig.ToString()})
   End Sub

#End Region

End Class