Public Class ucConfContabilidad

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbFormatoExportacion, GetType(Reglas.ContabilidadPublicos.FormatoExportacion), , True)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Contabilidad
      chbContabilidadEjecutarEnLinea.Checked = Reglas.ContabilidadPublicos.ContabilidadEjecutarEnLinea

      If Reglas.Publicos.TieneModuloContabilidad Then
         Dim rCuenta = New Reglas.ContabilidadCuentas()

         Dim idCuenta = Reglas.ContabilidadPublicos.ContabilidadCuentaVentas
         If idCuenta > 0 Then
            ucCuentaContabilidadVentas.Cuenta = rCuenta.GetUna(idCuenta)
         End If
         idCuenta = Reglas.ContabilidadPublicos.ContabilidadCuentaCompras
         If idCuenta > 0 Then
            ucCuentaContabilidadCompras.Cuenta = rCuenta.GetUna(idCuenta)
         End If
         idCuenta = Reglas.ContabilidadPublicos.ContabilidadCuentaRedondeo
         If idCuenta > 0 Then
            ucCuentaContabilidadRedondeo.Cuenta = rCuenta.GetUna(idCuenta)
         End If
         txtContabilidadRedondeoImporteMaximo.Text = Reglas.ContabilidadPublicos.ContabilidadRedondeoImporteMaximo.ToString("N2")
      End If


      cmbFormatoExportacion.SelectedValue = Reglas.ContabilidadPublicos.ContabilidadFormatoExportacion
      chbCuentaSecundariaProducto.Checked = Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto
      chbCuentaSecundariaCategoria.Checked = Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaCategoria

      chbUtilizaCentroCostos.Checked = Reglas.ContabilidadPublicos.UtilizaCentroCostos
      chbPermiteCambiarCentroCostosCompras.Checked = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCompras
      chbPermiteCambiarCentroCostosVentas.Checked = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosVentas
      chbPermiteCambiarCentroCostosCaja.Checked = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosCaja
      chbPermiteCambiarCentroCostosBanco.Checked = Reglas.ContabilidadPublicos.PermiteCambiarCentroCostosBanco

      Select Case Reglas.ContabilidadPublicos.CerrarPeriodoConAsientoPermitir
         Case Entidades.Publicos.PermitirNoPermitir.PERMITIR
            rbtCerrarPeriodoConAsientoPermitir_Permitir.Checked = True
         Case Entidades.Publicos.PermitirNoPermitir.NOPERMITIR
            rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Checked = True
         Case Entidades.Publicos.PermitirNoPermitir.AVISARYPERMITIR
            rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Checked = True
         Case Else

      End Select

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Contabilidad
      ActualizarParametro(Entidades.Parametro.Parametros.CONTABILIDADEJECUTARENLINEA, chbContabilidadEjecutarEnLinea, "CONTABILIDAD", chbContabilidadEjecutarEnLinea.Text)

      If Reglas.Publicos.TieneModuloContabilidad Then
         Dim cuenta = If(ucCuentaContabilidadCompras.Cuenta IsNot Nothing, ucCuentaContabilidadCompras.Cuenta.IdCuenta, 0)
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CONTABILIDADCUENTACOMPRAS, cuenta.ToString(), "CONTABILIDAD", lblContabilidadCompras.Text)

         cuenta = If(ucCuentaContabilidadVentas.Cuenta IsNot Nothing, ucCuentaContabilidadVentas.Cuenta.IdCuenta, 0)
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CONTABILIDADCUENTAVENTAS, cuenta.ToString(), "CONTABILIDAD", lblContabilidadVentas.Text)

         cuenta = If(ucCuentaContabilidadRedondeo.Cuenta IsNot Nothing, ucCuentaContabilidadRedondeo.Cuenta.IdCuenta, 0)
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CONTABILIDADCUENTAREDONDEO, cuenta.ToString(), "CONTABILIDAD", lblCuentaContabilidadRedondeo.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.CONTABILIDADREDONDEOIMPORTEMAXIMO, txtContabilidadRedondeoImporteMaximo, "CONTABILIDAD", lblCuentaContabilidadRedondeo.Text + " " + lblContabilidadRedondeoImporteMaximo.Text)


         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.CONTABILIDADFORMATOEXPORTACION, cmbFormatoExportacion, "CONTABILIDAD", lblFormatoExportacion.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.CONTABILIDADCUENTASECUNDARIAPRODUCTO, chbCuentaSecundariaProducto, "CONTABILIDAD", chbCuentaSecundariaProducto.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.CONTABILIDADCUENTASECUNDARIACATEGORIA, chbCuentaSecundariaCategoria, "CONTABILIDAD", chbCuentaSecundariaCategoria.Text)


         ActualizarParametro(Entidades.Parametro.Parametros.UTILIZACENTROCOSTOS, chbUtilizaCentroCostos, "CONTABILIDAD", chbUtilizaCentroCostos.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSCOMPRAS, chbPermiteCambiarCentroCostosCompras, "CONTABILIDAD", chbPermiteCambiarCentroCostosCompras.LabelAsoc.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSVENTAS, chbPermiteCambiarCentroCostosVentas, "CONTABILIDAD", chbPermiteCambiarCentroCostosVentas.LabelAsoc.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSCAJA, chbPermiteCambiarCentroCostosCaja, "CONTABILIDAD", chbPermiteCambiarCentroCostosCaja.LabelAsoc.Text)
         ActualizarParametro(Entidades.Parametro.Parametros.PERMITECAMBIARCENTROCOSTOSBANCO, chbPermiteCambiarCentroCostosBanco, "CONTABILIDAD", chbPermiteCambiarCentroCostosBanco.LabelAsoc.Text)

         Dim cerrarPeriodoConAsientoPermitir = If(rbtCerrarPeriodoConAsientoPermitir_AvisarPermitir.Checked, Entidades.Publicos.PermitirNoPermitir.AVISARYPERMITIR,
                                               If(rbtCerrarPeriodoConAsientoPermitir_NoPermitir.Checked, Entidades.Publicos.PermitirNoPermitir.NOPERMITIR,
                                               Entidades.Publicos.PermitirNoPermitir.PERMITIR)).ToString()
         ActualizarParametroTexto(Entidades.Parametro.Parametros.CONTABILIDADCERRARPERIODOCONASIENTOPERMITIR, cerrarPeriodoConAsientoPermitir, "CONTABILIDAD", grpCerrarPeriodoConAsientoPermitir.Text)

      End If

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If Reglas.Publicos.TieneModuloContabilidad AndAlso cmbFormatoExportacion.SelectedItem Is Nothing Then
         e.AgregarError("Debe seleccionar un formato de exportación de contabilidad.")
         cmbFormatoExportacion.Focus()
      End If

   End Sub


End Class
