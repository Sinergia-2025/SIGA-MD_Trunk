Public Class ucConfTurismo
   Private _publicos As Publicos
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)


      e.Publicos.CargaComboCategorias(cmbCatEstablecimiento)
      e.Publicos.CargaComboCategorias(cmbCatPasajero)
      e.Publicos.CargaComboCategorias(cmbCatResponsable)
      e.Publicos.CargaComboRubros(cmbRubroProgramas)
      e.Publicos.CargaComboRubros(cmbRubroGastronomia)
      e.Publicos.CargaComboRubros(cmbRubroVisitas)
      e.Publicos.CargaComboTiposComprobantes(cmbTurismoTipoComprobante, False, "VENTAS", , , , True)
      e.Publicos.CargaComboTiposComprobantes(cmbTurismoTipoComprobanteFact, False, "VENTAS", , , , True)

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      _publicos = New Eniac.Win.Publicos()
      'Turismo
      If cmbCatEstablecimiento.Items.Count > 0 Then
         cmbCatEstablecimiento.SelectedValue = Reglas.Publicos.TurismoCategoriaEstablecimiento
      End If

      If cmbCatPasajero.Items.Count > 0 Then
         cmbCatPasajero.SelectedValue = Reglas.Publicos.TurismoCategoriaPasajero
      End If

      If cmbCatResponsable.Items.Count > 0 Then
         cmbCatResponsable.SelectedValue = Reglas.Publicos.TurismoCategoriaResponsable
      End If

      If cmbRubroProgramas.Items.Count > 0 Then
         cmbRubroProgramas.SelectedValue = Reglas.Publicos.TurismoRubroPrograma
      End If

      If cmbRubroVisitas.Items.Count > 0 Then
         cmbRubroVisitas.SelectedValue = Reglas.Publicos.TurismoRubroVisita
      End If

      If cmbRubroGastronomia.Items.Count > 0 Then
         cmbRubroGastronomia.SelectedValue = Reglas.Publicos.TurismoRubroGastronomia
      End If

      txtFormulaVisitas.Text = Reglas.Publicos.TurismoFormulaVisitas.ToString()
      txtFormulaGastronomia.Text = Reglas.Publicos.TurismoFormulaGastronomia.ToString()
      txtFormulaVisitasId.Text = Reglas.Publicos.TurismoFormulaVisitasID.ToString()
      txtFormulaGastronomiaId.Text = Reglas.Publicos.TurismoFormulaGastronomiaID.ToString()


      If cmbTurismoTipoComprobante.Items.Count > 0 Then
         cmbTurismoTipoComprobante.SelectedValue = Reglas.Publicos.TurismoTipoComprobante
      End If

      If cmbTurismoTipoComprobanteFact.Items.Count > 0 Then
         cmbTurismoTipoComprobanteFact.SelectedValue = Reglas.Publicos.TurismoTipoComprobanteFactura
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Turismo
      If cmbCatEstablecimiento.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMOCATEGORIAESTABLECIMIENTO, cmbCatEstablecimiento, Nothing, cmbCatEstablecimiento.LabelAsoc.Text)
      End If
      If cmbCatPasajero.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMOCATEGORIAPASAJEROS, cmbCatPasajero, Nothing, cmbCatPasajero.LabelAsoc.Text)
      End If
      If cmbCatResponsable.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMOCATEGORIARESPONSABLE, cmbCatResponsable, Nothing, cmbCatResponsable.LabelAsoc.Text)
      End If
      If cmbRubroProgramas.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMORUBROPROGRAMA, cmbRubroProgramas, Nothing, cmbRubroProgramas.LabelAsoc.Text)
      End If
      If cmbRubroVisitas.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMORUBROVISITA, cmbRubroVisitas, Nothing, cmbRubroVisitas.LabelAsoc.Text)
      End If
      If cmbRubroGastronomia.SelectedIndex <> -1 Then
         ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.TURISMORUBROGASTRONOMIA, cmbRubroGastronomia, Nothing, cmbRubroGastronomia.LabelAsoc.Text)
      End If
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOFORMULAVISITAS, txtFormulaVisitas, Nothing, lblFormulaVisita.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOFORMULAGASTRONOMIA, txtFormulaGastronomia, Nothing, lblFormulaGastronomia.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOFORMULAVISITASID, txtFormulaVisitasId, Nothing, lblFormulaVisita.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURISMOFORMULAGASTRONOMIAID, txtFormulaGastronomiaId, Nothing, lblFormulaGastronomia.Text)

      If cmbTurismoTipoComprobante.SelectedIndex <> -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TURISMOTIPOCOMPROBANTE, cmbTurismoTipoComprobante, Nothing, cmbTurismoTipoComprobante.LabelAsoc.Text)
      End If
      If cmbTurismoTipoComprobanteFact.SelectedIndex <> -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TURISMOTIPOCOMPROBANTEFACTURA, cmbTurismoTipoComprobanteFact, Nothing, cmbTurismoTipoComprobanteFact.LabelAsoc.Text)
      End If

   End Sub

End Class