Public Class SueldosLiquidacion

#Region "Campos"

   Private _publicos As Publicos
   Private _tr As Entidades.SueldosTipoRecibo

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            'habilito el boton de re-abrir liquidación o no
            Dim ru = New Reglas.Usuarios()

            tsbReAbrirLiquidacion.Visible = ru.TienePermisos("SueldosReAbrirLiquidacion")
            CargarValoresIniciales()
            MostrarResumenLiquidacionActual(_tr.IdTipoRecibo)
            If ugdDetalle.Rows.Count = 0 Then
               tsbCerrarLiquidacion.Enabled = False
            Else
               tsbReAbrirLiquidacion.Enabled = False
            End If

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub cmbTiposRecibos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposRecibos.SelectedIndexChanged
      TryCatched(Sub() SetearTiposRecibos())
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            CargarValoresIniciales()
            _publicos.CargaComboSueldosLugaresActividad(cmbLugarActividad)
            ugdDetalle.ClearFilas()
            tssRegistros.Text = ugdDetalle.CantidadRegistrosParaStatusbar
         End Sub)
   End Sub

   Private Sub tsbGenerar_Click(sender As Object, e As EventArgs) Handles tsbGenerar.Click
      TryCatched(
         Sub()
            If ShowPregunta("¿Confirma la Operación?", MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Exit Sub
            End If
            GenerarRecibosSueldo()
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      TryCatched(Sub() Close())
   End Sub

   'Private Sub btnConsultar_Click(sender As Object, e As EventArgs)

   '   Try

   '      Dim Valor As String
   '      Valor = Me.txtNumeroLiquidacion.Text
   '      If Not IsNumeric(Valor) Then
   '         MessageBox.Show("Debe ingresar un número de liquidación válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   '         Me.txtNumeroLiquidacion.Focus()
   '         Exit Sub
   '      End If


   '      Valor = Me.dtpPeriodo.Value.ToString("yyyyMM")
   '      If Not IsNumeric(Mid(Valor, 6, 2)) Then
   '         MessageBox.Show("Debe ingresar un período válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   '         Me.dtpPeriodo.Focus()
   '         Exit Sub
   '      End If

   '      Me.Cursor = Cursors.WaitCursor

   '      ' Me.CargaGrillaDetalle()

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   Finally
   '      Me.Cursor = Cursors.Default
   '   End Try

   'End Sub

   Private Sub tsbCerrarLiquidacion_Click(sender As Object, e As EventArgs) Handles tsbCerrarLiquidacion.Click
      TryCatched(
         Sub()
            'valida que haya conceptos para liquidar

            Dim rMovimientos = New Reglas.SueldosLiquidacion()
            Dim total = rMovimientos.GetCantidadPersonalLiquidados(Me._tr.IdTipoRecibo)

            'valida que esténimpresos los recibos
            If Total = 0 Then
               MsgBox("No hay datos para cerrar una liquidación")
               Exit Sub
            End If

            'valida que esténimpresos los recibos
            If Total = 0 Then
               ShowMessage("Los recibos no están impresos. No puede cerrar la liquidación")
               Exit Sub
            End If

            If ShowPregunta("¿Confirma el cierre de la liquidación?") = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If

            Dim ano As Integer = dtpPeriodo.Value.Year
            Dim mes As Integer = dtpPeriodo.Value.Month
            Dim fechaGen As New Date(ano, mes, 1)
            Dim periodo As Integer = fechaGen.Year * 100 + fechaGen.Month
            Dim fechaPago As Date = dtpSueldosFechaPago.Value
            Dim lugarPago As String = txtLugarPago.Text
            Dim domicilioempresa = Publicos.SueldosDomicilioEmpresa

            rMovimientos.Cierre_de_Liquidacion(periodo.ToString(), _tr.NumeroLiquidacion, mes, ano,
                                               _tr.IdTipoRecibo, fechaPago, lugarPago,
                                               domicilioempresa, _tr.CantidadLiquidPeriodo)

            ShowMessage("La liquidación se cerró correctamente.")
            CargarValoresIniciales()

         End Sub)
   End Sub

   Private Sub chbPorLugarActividad_CheckedChanged(sender As Object, e As EventArgs) Handles chbPorLugarActividad.CheckedChanged
      TryCatched(Sub() cmbLugarActividad.Enabled = chbPorLugarActividad.Checked)
   End Sub

   Private Sub tsbReAbrirLiquidacion_Click(sender As Object, e As EventArgs) Handles tsbReAbrirLiquidacion.Click
      TryCatched(
         Sub()
            If MessageBox.Show("¿Esta seguro de querer re-abrir la última liquidación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Exit Sub
            End If

            Dim idTipoRecibo = cmbTiposRecibos.SelectedValue.ToString().ToInt32().IfNull()

            Dim ano = dtpPeriodo.Value.Year
            Dim mes = dtpPeriodo.Value.Month

            Dim rMovimientos = New Reglas.SueldosLiquidacion()
            rMovimientos.ReAbrirLiquidacion(mes, ano, idTipoRecibo, Me._tr.NumeroLiquidacion)

            ShowMessage("Se re-abrio la ultima liquidación.")

            CargarValoresIniciales()
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub SetearTiposRecibos()
      _tr = DirectCast(cmbTiposRecibos.SelectedItem, Entidades.SueldosTipoRecibo)
      txtCantidadLiqPeriodo.Visible = _tr.CantidadLiquid > 1
      lblCantLiqPeriodo.Visible = _tr.CantidadLiquid > 1

      If _tr.LiquidacionEventual Then
         dtpPeriodo.Enabled = True
      Else
         dtpPeriodo.Enabled = False
      End If

      dtpPeriodo.Value = _tr.PeriodoLiquidacion.FromPeriodo()
      txtNumeroLiquidacion.Text = (_tr.NumeroLiquidacion).ToString()

      txtCantidadLiq.Text = _tr.CantidadLiquid.ToString()
      txtCantidadLiqPeriodo.Text = (_tr.CantidadLiquidPeriodo + 1).ToString()

      MostrarResumenLiquidacionActual(_tr.IdTipoRecibo)

      If Me.ugdDetalle.Rows.Count = 0 Then
         Me.tsbCerrarLiquidacion.Enabled = False
         Me.tsbReAbrirLiquidacion.Enabled = True
      Else
         Me.tsbCerrarLiquidacion.Enabled = True
         Me.tsbReAbrirLiquidacion.Enabled = False
      End If

   End Sub

   Private Sub ActualizarParametro(idParametro As String, valorParametro As String, categoriaParametro As String, descripcionParametro As String)
      Dim par = New Entidades.Parametro()

      '-- REQ-31081
      par.IdEmpresa = actual.Sucursal.IdEmpresa

      par.IdParametro = idParametro
      par.ValorParametro = valorParametro
      par.CategoriaParametro = categoriaParametro
      par.DescripcionParametro = descripcionParametro
      Dim rPars = New Reglas.Parametros()
      rPars.Actualizar(par)
   End Sub

   Private Sub CargarValoresIniciales()

      _publicos.CargaComboSueldosTiposRecibos(cmbTiposRecibos)


      Dim par = New Reglas.Parametros()

      dtpSueldosFechaPago.Value = Date.Parse(par.GetValorPD(dtpSueldosFechaPago.Tag.ToString(), ""), Formatos.Culturas.Argentina)

      _publicos.CargaComboSueldosLugaresActividad(cmbLugarActividad)
   End Sub


   Private Sub GenerarRecibosSueldo()

      Me.tsbCerrarLiquidacion.Enabled = True

      Dim ano = dtpPeriodo.Value.Year
      Dim mes = dtpPeriodo.Value.Month
      Dim fechaGen = New Date(ano, mes, 1)
      Dim periodo = fechaGen.Year * 100 + fechaGen.Month

      ActualizarParametro(dtpSueldosFechaPago.Tag.ToString(), Mid(dtpSueldosFechaPago.Value.ToString, 1, 10), "SUELDOS", lblSueldosFechaPago.Text)

      Dim idLugarActividad As Integer = 0

      If chbPorLugarActividad.Checked Then
         idLugarActividad = Integer.Parse(cmbLugarActividad.SelectedValue.ToString())
      End If

      'controlo la cantidad de liquidaciones en el periodo
      If _tr.CantidadLiquidPeriodo <= _tr.CantidadLiquid Then
         Dim rMovimientos = New Reglas.SueldosLiquidacion()
         rMovimientos.GeneraLiquidacionSueldos(periodo.ToString(), _tr.NumeroLiquidacion,
                                               idLugarActividad, _tr.IdTipoRecibo)
         MostrarResumenLiquidacionActual(_tr.IdTipoRecibo)

         ShowMessage("¡¡ Se Generaron los sueldos Exitosamente !!")

         CargarValoresIniciales()
      Else
         ShowMessage("No puede realizar otra Liquidación en este período")
      End If

   End Sub

   Private Sub MostrarResumenLiquidacionActual(idTipoRecibo As Integer)
      Dim rMovimientos = New Reglas.SueldosLiquidacion()
      ugdDetalle.DataSource = rMovimientos.MostrarResumenLiquidacion(idTipoRecibo)
   End Sub

#End Region

End Class