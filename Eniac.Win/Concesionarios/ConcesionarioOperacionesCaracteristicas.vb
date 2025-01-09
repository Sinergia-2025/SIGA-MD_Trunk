Public Class ConcesionarioOperacionesCaracteristicas
   Private Property Operacion As Entidades.ConcesionarioOperacion

   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() CargaCombos())
      TryCatched(Sub() CargaValoresOperacion())

   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() cmbTipoUnidad.Focus())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window, operacion As Entidades.ConcesionarioOperacion) As DialogResult
      Me.Operacion = operacion
      Return ShowDialog(owner)
   End Function

   Private Sub cmbTipoUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoUnidad.SelectedIndexChanged '', cmbHerraje.SelectedIndexChanged, cmbPiso.SelectedIndexChanged, cmbMarco.SelectedIndexChanged, cmbParante.SelectedIndexChanged, cmbPuertaTrasera.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim tipoUnidad = cmbTipoUnidad.ItemSeleccionado(Of Entidades.ConcesionarioTipoUnidad)()
            If tipoUnidad IsNot Nothing Then
               _publicos.CargaComboConcesionarioTipoUnidad(cmbSubTipoUnidad, cmbTipoUnidad.ValorSeleccionado(Of Integer))
               _publicos.CargaComboConcesionarioDistribucionEjes(cmbDistribucionEjes, cmbTipoUnidad.ValorSeleccionado(Of Integer))
               cmbDistribucionEjes.Enabled = cmbDistribucionEjes.Items.Count > 0
            End If
         End Sub)
   End Sub
   Private Sub cmbSubTipoUnidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubTipoUnidad.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim subTipoUnidad = cmbSubTipoUnidad.ItemSeleccionado(Of Entidades.ConcesionarioSubTipoUnidad)()
            If subTipoUnidad IsNot Nothing Then
               txtCampoAdicional.Visible = subTipoUnidad.SolicitaCantPuertasLaterales Or subTipoUnidad.SolicitaCantPisos Or subTipoUnidad.SolicitaVolumen
               lblCampoAdicional.Visible = txtCampoAdicional.Visible

               lblCampoAdicional.Text = If(subTipoUnidad.SolicitaCantPuertasLaterales, "Cant. Puertas Laterales",
                                        If(subTipoUnidad.SolicitaCantPisos, "Cant. Pisos",
                                        If(subTipoUnidad.SolicitaVolumen, "Volumen", String.Empty)))

            End If
         End Sub)
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Cancelar())
   End Sub


   Private Sub CargaCombos()
      _publicos.CargaComboConcesionarioTipoUnidad(cmbTipoUnidad, Entidades.Publicos.SiNoTodos.SI)
      _publicos.CargaComboDesdeEnum(cmbPuertaTrasera, GetType(Entidades.ConcesionarioPuertaTrasera)).SelectedIndex = -1
      _publicos.CargaComboDesdeEnum(cmbParante, GetType(Entidades.ConcesionarioParante)).SelectedIndex = -1
      _publicos.CargaComboDesdeEnum(cmbPiso, GetType(Entidades.ConcesionarioPiso)).SelectedIndex = -1
      _publicos.CargaComboDesdeEnum(cmbMarco, GetType(Entidades.Publicos.SiNo)).SelectedIndex = -1
      _publicos.CargaComboDesdeEnum(cmbHerraje, GetType(Entidades.ConcesionarioHerraje)).SelectedIndex = -1
   End Sub
   Private Sub CargaValoresOperacion()
      cmbTipoUnidad.SelectedValue = Operacion.IdTipoUnidadCeroKilometro
      cmbSubTipoUnidad.SelectedValue = Operacion.IdSubTipoUnidadCeroKilometro
      cmbDistribucionEjes.SelectedValue = Operacion.IdEjeCeroKilometro
      txtCampoAdicional.Text = Operacion.CaracteristicaAdicionalCeroKilometro

      txtLargo.Text = Operacion.LargoCeroKilometro
      txtAltoCarga.Text = Operacion.AltoCargaCeroKilometro
      txtAltoPuertasLaterales.Text = Operacion.AltoPuertgaLateralCeroKilometro
      txtColorCarroceria.Text = Operacion.ColorCarroceriaCeroKilometro
      txtColorZocalo.Text = Operacion.ColorZocaloCeroKilometro
      txtColorBase.Text = Operacion.ColorBaseCeroKilometro

      chbPuertaTrasera.Checked = Operacion.PuertaTraseraCeroKilometro.HasValue
      chbParante.Checked = Operacion.ParanteCeroKilometro.HasValue
      chbPiso.Checked = Operacion.PisoCeroKilometro.HasValue
      chbMarco.Checked = Operacion.MarcoCeroKilometro.HasValue
      chbHerraje.Checked = Operacion.HerrajeCeroKilometro.HasValue


      If Operacion.PuertaTraseraCeroKilometro.HasValue Then cmbPuertaTrasera.SelectedValue = Operacion.PuertaTraseraCeroKilometro
      If Operacion.ParanteCeroKilometro.HasValue Then cmbParante.SelectedValue = Operacion.ParanteCeroKilometro
      If Operacion.PisoCeroKilometro.HasValue Then cmbPiso.SelectedValue = Operacion.PisoCeroKilometro
      If Operacion.MarcoCeroKilometro.HasValue Then cmbMarco.SelectedValue = Operacion.MarcoCeroKilometro
      If Operacion.HerrajeCeroKilometro.HasValue Then cmbHerraje.SelectedValue = Operacion.HerrajeCeroKilometro

      txtOtrasObservaciones.Text = Operacion.OtrasObservacionesCeroKilometro
   End Sub


   Private Sub Aceptar()

      Operacion.IdTipoUnidadCeroKilometro = cmbTipoUnidad.ValorSeleccionado(Of Integer)
      Operacion.IdSubTipoUnidadCeroKilometro = cmbSubTipoUnidad.ValorSeleccionado(Of Integer)
      Operacion.IdEjeCeroKilometro = If(cmbDistribucionEjes.Enabled, cmbDistribucionEjes.ValorSeleccionado(Of Integer), 0I)
      Operacion.CaracteristicaAdicionalCeroKilometro = txtCampoAdicional.Text

      Operacion.LargoCeroKilometro = txtLargo.Text
      Operacion.AltoCargaCeroKilometro = txtAltoCarga.Text
      Operacion.AltoPuertgaLateralCeroKilometro = txtAltoPuertasLaterales.Text
      Operacion.ColorCarroceriaCeroKilometro = txtColorCarroceria.Text
      Operacion.ColorZocaloCeroKilometro = txtColorZocalo.Text
      Operacion.ColorBaseCeroKilometro = txtColorBase.Text

      Operacion.PuertaTraseraCeroKilometro = If(chbPuertaTrasera.Checked, cmbPuertaTrasera.ValorSeleccionado(Of Entidades.ConcesionarioPuertaTrasera?), Nothing)
      Operacion.ParanteCeroKilometro = If(chbParante.Checked, cmbParante.ValorSeleccionado(Of Entidades.ConcesionarioParante?), Nothing)
      Operacion.PisoCeroKilometro = If(chbPiso.Checked, cmbPiso.ValorSeleccionado(Of Entidades.ConcesionarioPiso?), Nothing)
      Operacion.MarcoCeroKilometro = If(chbMarco.Checked, cmbMarco.ValorSeleccionado(Of Entidades.Publicos.SiNo?), Nothing)
      Operacion.HerrajeCeroKilometro = If(chbHerraje.Checked, cmbHerraje.ValorSeleccionado(Of Entidades.ConcesionarioHerraje?), Nothing)

      Operacion.OtrasObservacionesCeroKilometro = txtOtrasObservaciones.Text

      DialogResult = DialogResult.OK
      Close()
   End Sub


   Private Sub Cancelar()
      DialogResult = DialogResult.Cancel
      Close()
   End Sub

   Private Sub chbPuertaTrasera_CheckedChanged(sender As Object, e As EventArgs) Handles chbPuertaTrasera.CheckedChanged
      TryCatched(Sub() chbPuertaTrasera.FiltroCheckedChanged(cmbPuertaTrasera))
   End Sub

   Private Sub chbParante_CheckedChanged(sender As Object, e As EventArgs) Handles chbParante.CheckedChanged
      TryCatched(Sub() chbParante.FiltroCheckedChanged(cmbParante))
   End Sub

   Private Sub chbPiso_CheckedChanged(sender As Object, e As EventArgs) Handles chbPiso.CheckedChanged
      TryCatched(Sub() chbPiso.FiltroCheckedChanged(cmbPiso))
   End Sub

   Private Sub chbMarco_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarco.CheckedChanged
      TryCatched(Sub() chbMarco.FiltroCheckedChanged(cmbMarco))
   End Sub

   Private Sub chbHerraje_CheckedChanged(sender As Object, e As EventArgs) Handles chbHerraje.CheckedChanged
      TryCatched(Sub() chbHerraje.FiltroCheckedChanged(cmbHerraje))
   End Sub
End Class