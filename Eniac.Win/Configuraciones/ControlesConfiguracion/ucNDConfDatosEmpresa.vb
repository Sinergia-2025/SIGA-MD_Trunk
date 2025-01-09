Public Class ucConfNDDatosEmpresa

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      'Cargo el combo con todas las categorias fiscales
      e.Publicos.CargaComboCategoriasFiscales(cmbCategoriaFiscal)
      e.Publicos.CargaComboDesdeEnum(cmbAplicacionEdicion, GetType(Entidades.AplicacionEdicionParaParametros))
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Datos Generales de la Empresa
      txtNombreEmpresa.Text = Reglas.Publicos.NombreEmpresa
      txtNombreFantasia.Text = Reglas.Publicos.NombreFantasia
      txtCuitEmpresa.Text = Reglas.Publicos.CuitEmpresa
      cmbCategoriaFiscal.SelectedValue = Reglas.Publicos.CategoriaFiscalEmpresa
      txtCurrentUICulture.Text = Reglas.Publicos.EmpresaCurrentUICulture
      chbSincroniza.Checked = Reglas.Publicos.RealizaSincronizacionDesdeHaciaSucursales
      txtVersionDB.Text = Reglas.Publicos.VersionDB
      txtClaveActualizacion.Text = Reglas.Publicos.VencimientoSistema
      txtDiasVencimientoSistema.Text = Reglas.Publicos.DiasVencimientoSistema.ToString()
      chbPermiteConsultarMultipleSucursal.Checked = Reglas.Publicos.PermiteConsultarMultipleSucursal
      txtDiasControlDeLicencias.Text = Reglas.Publicos.DiasControlDeLicencias.ToString()

      'chbExtrasSinergia.Checked = Reglas.Publicos.ExtrasSinergia


      'Columna 2
      txtIDAplicacion.Text = Reglas.Publicos.IDAplicacionSinergia
      cmbAplicacionEdicion.SelectedValue = Reglas.Publicos.IdEdicionAplicacionSinergia
      txtCodigoClienteSinergia.Text = Reglas.Publicos.CodigoClienteSinergia
      txtClaveClienteSinergia.Text = Reglas.Publicos.ClaveClienteSinergia


   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Datos Generales de la empresa
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREEMPRESA, txtNombreEmpresa, Nothing, lblNombreEmpresa.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREFANTASIA, txtNombreFantasia, Nothing, lblNombreFantasia.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CUITEMPRESA, txtCuitEmpresa, Nothing, lblCuitEmpresa.Text)
      ActualizarParametro(Of Short)(Entidades.Parametro.Parametros.CATEGORIAFISCALEMPRESA, cmbCategoriaFiscal, Nothing, lblCategoriaFiscalEmpresa.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EMPRESACURRENTUICULTURE, txtCurrentUICulture, Nothing, lblCurrentUICulture.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SINCRONIZA, chbSincroniza, Nothing, chbSincroniza.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VERSIONDB, txtVersionDB, Nothing, lblVersionDB.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.VENCIMIENTOSISTEMA, txtClaveActualizacion, Nothing, lblClaveAtualizacion.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DIASAVISOVENCIMIENTOSISTEMA, txtDiasVencimientoSistema, Nothing, lblDiasVencimientoSistema.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PERMITECONSULTARMULTIPLESUCURSAL, chbPermiteConsultarMultipleSucursal, Nothing, chbPermiteConsultarMultipleSucursal.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.DIASCONTROLDELICENCIAS, txtDiasControlDeLicencias, Nothing, lblDiasControlDeLicencias.Text)
      'ActualizarParametro(Entidades.Parametro.Parametros.EXTRASSINERGIA, chbExtrasSinergia, Nothing, chbExtrasSinergia.Text)


      'Columna 2
      ActualizarParametro(Entidades.Parametro.Parametros.IDAPLICACION, txtIDAplicacion, Nothing, lblIDAplicacion.Text)
      ActualizarParametro(Of String)(Entidades.Parametro.Parametros.IDEDICIONAPLICACION, cmbAplicacionEdicion, Nothing, "Edición Aplicación Sinergia")
      ActualizarParametro(Entidades.Parametro.Parametros.CODIGOCLIENTESINERGIA, txtCodigoClienteSinergia, Nothing, lblCodigoClienteSinergia.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLAVECLIENTESINERGIA, txtClaveClienteSinergia, Nothing, lblClaveClienteSinergia.Text)


      'Grabciones adicionales
      Dim rEmpresa = New Reglas.Empresas()
      Dim empresa = actual.Sucursal.Empresa
      empresa.NombreEmpresa = txtNombreEmpresa.Text
      empresa.CuitEmpresa = txtCuitEmpresa.Text
      rEmpresa.Actualizar(empresa)

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      Dim result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia().
                        Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() With
                              {
                                 .IdFiscal = txtCuitEmpresa.Text,
                                 .SolicitaCUIT = True
                              })
      If result.Error Then
         txtCuitEmpresa.Select()
         e.AgregarError(result.MensajeError)
      End If

   End Sub

End Class