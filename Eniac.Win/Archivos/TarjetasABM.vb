Public Class TarjetasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TarjetasDetalle(DirectCast(Me.GetEntidad(), Entidades.Tarjeta))
      End If
      Return New TarjetasDetalle(New Entidades.Tarjeta())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Tarjetas()
   End Function
  
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim tar As Entidades.Tarjeta = New Entidades.Tarjeta()
      With Me.dgvDatos.ActiveCell.Row
         tar.IdTarjeta = Integer.Parse(.Cells("IdTarjeta").Value.ToString())
         tar = New Reglas.Tarjetas().GetUno(tar.IdTarjeta)
      End With
      Return tar
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Tarjeta.Columnas.IdTarjeta.ToString()).Header.Caption = "Codigo"
         .Columns(Entidades.Tarjeta.Columnas.IdTarjeta.ToString()).Width = 40
         .Columns(Entidades.Tarjeta.Columnas.IdTarjeta.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).Header.Caption = "Tarjeta"
         .Columns(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()).Width = 150
         .Columns(Entidades.Tarjeta.Columnas.TipoTarjeta.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.Tarjeta.Columnas.TipoTarjeta.ToString()).Width = 40
         .Columns(Entidades.Tarjeta.Columnas.TipoTarjeta.ToString()).CellAppearance.TextHAlign = HAlign.Center
         .Columns(Entidades.Tarjeta.Columnas.Habilitada.ToString()).Header.Caption = "Habilitada"
         .Columns(Entidades.Tarjeta.Columnas.Habilitada.ToString()).Width = 60
         .Columns(Entidades.Tarjeta.Columnas.Acreditacion.ToString()).Header.Caption = "Acreditacion"
         .Columns(Entidades.Tarjeta.Columnas.Acreditacion.ToString()).Width = 80
         .Columns(Entidades.Tarjeta.Columnas.IdCuentaBancaria.ToString()).Hidden = True
         .Columns(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString()).Header.Caption = "Cuenta Bancaria"
         .Columns(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString()).Width = 180
         .Columns(Entidades.Tarjeta.Columnas.CantDiasAcredit.ToString()).Header.Caption = "Dias"
         .Columns(Entidades.Tarjeta.Columnas.CantDiasAcredit.ToString()).Width = 40
         .Columns(Entidades.Tarjeta.Columnas.CantDiasAcredit.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Tarjeta.Columnas.PagoPosVenta.ToString()).Header.Caption = "P.PosVenta"
         .Columns(Entidades.Tarjeta.Columnas.PagoPosVenta.ToString()).Width = 80
         .Columns(Entidades.Tarjeta.Columnas.PagoPosCorte.ToString()).Header.Caption = "P.PosCorte"
         .Columns(Entidades.Tarjeta.Columnas.PagoPosCorte.ToString()).Width = 80
         .Columns(Entidades.Tarjeta.Columnas.DiaCorte.ToString()).Hidden = True
         .Columns("DiaDeCorte").Header.Caption = "Dia De Corte"
         .Columns("DiaDeCorte").Width = 70
         .Columns(Entidades.Tarjeta.Columnas.PagoDiaMes.ToString()).Header.Caption = "P.DiaMes"
         .Columns(Entidades.Tarjeta.Columnas.PagoDiaMes.ToString()).Width = 80
         .Columns(Entidades.Tarjeta.Columnas.DiaMes.ToString()).Header.Caption = "Dia Mes"
         .Columns(Entidades.Tarjeta.Columnas.DiaMes.ToString()).Width = 60
         .Columns(Entidades.Tarjeta.Columnas.DiaMes.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Tarjeta.Columnas.PorcIntereses.ToString()).Header.Caption = "% Interes"
         .Columns(Entidades.Tarjeta.Columnas.PorcIntereses.ToString()).Width = 80
         .Columns(Entidades.Tarjeta.Columnas.PorcIntereses.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Tarjeta.Columnas.CantidadCuotas.ToString()).Header.Caption = "Cantidad Cuotas"
         .Columns(Entidades.Tarjeta.Columnas.CantidadCuotas.ToString()).Width = 80
         .Columns(Entidades.Tarjeta.Columnas.CantidadCuotas.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Tarjeta.Columnas.IdCuentaContable.ToString()).Header.Caption = "Cuenta"
         .Columns(Entidades.Tarjeta.Columnas.IdCuentaContable.ToString()).Width = 90
         .Columns("NombreCuentaContable").Header.Caption = "Nombre Cuenta"
         .Columns("NombreCuentaContable").Width = 280

         If Not Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Tarjeta.Columnas.IdCuentaContable.ToString()).Hidden = True
            .Columns("NombreCuentaContable").Hidden = True
         End If

         .Columns(Entidades.Tarjeta.Columnas.IdProveedor.ToString()).Hidden = True
         .Columns("CodigoProveedor").Hidden = True
         .Columns("NombreProveedor").Header.Caption = "Nombre Proveedor"
         .Columns("NombreProveedor").Width = 200

      End With
   End Sub

#End Region

End Class