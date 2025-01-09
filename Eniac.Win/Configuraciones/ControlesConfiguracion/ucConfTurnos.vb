Public Class ucConfTurnos

   Private _publicos As Publicos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboTiposTurnos(cmbTipoTurnoBase)
      e.Publicos.CargaComboEstadosTurnos(cmbEstadoTurnoBase)
      e.Publicos.CargaComboEstadosTurnos(cmbTipoTurnoCambio)

      _publicos = e.Publicos

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Turnos
      If cmbTipoTurnoBase.Items.Count > 0 Then
         cmbTipoTurnoBase.SelectedValue = Reglas.Publicos.TurnosTipoBase
      End If

      If cmbEstadoTurnoBase.Items.Count > 0 Then
         cmbEstadoTurnoBase.SelectedValue = Reglas.Publicos.TurnosEstadoBase
      End If

      If cmbTipoTurnoCambio.Items.Count > 0 Then
         cmbTipoTurnoCambio.SelectedValue = Reglas.Publicos.TurnosTipoCambio
      End If

      chbTurnosPermiteFacturarDesdeCalendario.Checked = Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario

      If Reglas.Publicos.TurnosProductoZona > 0 Then
         bscCodigoRubro.Text = Reglas.Publicos.TurnosProductoZona.ToString()
         bscCodigoRubro.PresionarBoton()
      End If

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Turnos
      If cmbTipoTurnoBase.SelectedIndex <> -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TURNOSTIPOBASE, cmbTipoTurnoBase, Nothing, cmbTipoTurnoBase.LabelAsoc.Text)
      End If
      If cmbEstadoTurnoBase.SelectedIndex <> -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TURNOSESTADOBASE, cmbEstadoTurnoBase, Nothing, cmbEstadoTurnoBase.LabelAsoc.Text)
      End If
      If cmbTipoTurnoCambio.SelectedIndex <> -1 Then
         ActualizarParametro(Of String)(Entidades.Parametro.Parametros.TURNOSTIPOCAMBIO, cmbTipoTurnoCambio, Nothing, cmbTipoTurnoCambio.LabelAsoc.Text)
      End If

      ActualizarParametro(Entidades.Parametro.Parametros.TURNOSPERMITEFACTURARDESDECALENDARIO, chbTurnosPermiteFacturarDesdeCalendario, Nothing, chbTurnosPermiteFacturarDesdeCalendario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.TURNOSPRODUCTOZONA, bscCodigoRubro, Nothing, "")

   End Sub

   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      FindForm().TryCatched(
      Sub()
         Dim rRubros = New Reglas.Rubros()
         _publicos.PreparaGrillaRubros(bscCodigoRubro)
         bscCodigoRubro.Datos = rRubros.GetPorCodigo(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub

   Private Sub bscRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion, bscRubro.BuscadorSeleccion
      FindForm().TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarRubro(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      FindForm().TryCatched(
         Sub()
            Dim rRubros = New Reglas.Rubros()
            _publicos.PreparaGrillaRubros(bscRubro)
            bscRubro.Datos = rRubros.GetPorNombre(bscRubro.Text.Trim())
         End Sub)
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
      bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()
   End Sub

End Class