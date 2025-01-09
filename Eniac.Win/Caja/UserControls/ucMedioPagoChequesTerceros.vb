Public Class ucMedioPagoChequesTerceros
   Private _publicos As Publicos

   Public Property Cheques As IEnumerable(Of Entidades.Cheque)
   Private _newCheques As Func(Of Entidades.Cheque)
   Private _tit As Dictionary(Of String, String)
   Private _situacionPredeterminada As Entidades.SituacionCheque

   Public Sub Inicializar(cheques As IEnumerable(Of Entidades.Cheque), newCheques As Func(Of Entidades.Cheque))
      If newCheques Is Nothing Then
         Throw New ArgumentNullException(NameOf(newCheques))
      End If

      _Cheques = cheques
      _newCheques = newCheques

      _tit = DirectCast(FindForm(), BaseForm).GetColumnasVisiblesGrilla(ugCheques)
      ugCheques.DataSource = _Cheques
      DirectCast(FindForm(), BaseForm).AjustarColumnasGrilla(ugCheques, _tit)

      ugCheques.AgregarTotalesSuma({"Monto", "Importe"})

      _situacionPredeterminada = New Reglas.SituacionCheques().GetPorDefecto(Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

      controlesEnter = {cmbTipoCheque, txtSucursalBanco, txtCodPostalCheque, txtNroCheque, txtNroOperacion, dtpFechaCobro, dtpFechaEmision, txtCuitChequeTercero, txtTitularCheque, txtImporteCheque}
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      If Not DesignMode Then
         TryCatched(
            Sub()
               _publicos = New Publicos()

               _publicos.CargaComboTiposCheques(cmbTipoCheque)
            End Sub)
      End If
   End Sub

   Dim controlesEnter As IEnumerable(Of Control)
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Enter AndAlso controlesEnter.Any(Function(c) c.ContainsFocus) Then
         ProcessTabKey(True)
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#Region "Eventos"
   'Private Sub cmbTipoCheque_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbTipoCheque.KeyUp, txtSucursalBanco.KeyUp, txtCodPostalCheque.KeyUp, txtNroCheque.KeyUp, txtNroOperacion.KeyUp,
   '                                                                             dtpFechaCobro.KeyUp, dtpFechaEmision.KeyUp, txtCuitChequeTercero.KeyUp, txtTitularCheque.KeyUp, txtImporteCheque.KeyUp
   '   PresionarTab(e)
   'End Sub
   Private Sub cmbTipoCheque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCheque.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbTipoCheque.SelectedIndex <> -1 Then
               txtNroOperacion.Clear()
               txtNroOperacion.Enabled = cmbTipoCheque.ItemSeleccionado(Of Entidades.TiposCheques).SolicitaNroOperacion
            End If
         End Sub)
   End Sub

#Region "Eventos Buscador Banco"
   Private Sub bscCodBancos_BuscadorClick() Handles bscCodBancos.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscCodBancos)
            bscCodBancos.Datos = New Reglas.Bancos().GetFiltradoPorCodigo(bscCodBancos.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscBancos_BuscadorClick() Handles bscBancos.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscBancos)
            bscBancos.Datos = New Reglas.Bancos().GetFiltradoPorNombre(bscBancos.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodBancos_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCodBancos.BuscadorSeleccion, bscBancos.BuscadorSeleccion
      TryCatched(Sub() CargarDatosBancos(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Insertar/Borrar/Editar"
   Private Sub btnInsertarCheque_Click(sender As Object, e As EventArgs) Handles btnInsertarCheque.Click
      TryCatched(
         Sub()
            If ValidarInsertarCheques() Then
               InsertarChequesGrilla()
               bscCodBancos.Focus()
            End If
         End Sub)
   End Sub
   Private Sub btnEliminarCheque_Click(sender As Object, e As EventArgs) Handles btnEliminarCheque.Click
      TryCatched(
         Sub()
            Dim dr = ugCheques.FilaSeleccionada(Of Entidades.Cheque)
            If dr IsNot Nothing Then
               If dr.IdEstadoCheque <> Entidades.Cheque.Estados.ALTA Then
                  Throw New Exception(String.Format("El cheque {0} tiene estado {1} no es posible modificarlo.", dr.NumeroCheque, dr.IdEstadoCheque))
               End If
               If FindForm().ShowPregunta("¿Esta seguro de eliminar el cheque seleccionado?") = Windows.Forms.DialogResult.Yes Then
                  EliminarLineaCheques()
               End If
            End If
         End Sub)
   End Sub
   Private Sub ugCheques_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugCheques.DoubleClickRow
      TryCatched(
         Sub()
            Dim dr = ugCheques.FilaSeleccionada(Of Entidades.Cheque)
            If dr IsNot Nothing Then
               If dr.IdEstadoCheque <> Entidades.Cheque.Estados.ALTA Then
                  Throw New Exception(String.Format("El cheque {0} tiene estado {1} no es posible modificarlo.", dr.NumeroCheque, dr.IdEstadoCheque))
               End If
               LimpiarCamposCheques()
               CargarChequeCompleto()
               EliminarLineaCheques()
            End If
         End Sub)
   End Sub
#End Region

#End Region

#Region "Métodos"
   Private Sub CargarDatosBancos(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscBancos.Text = dr.Cells("NombreBanco").Value.ToString()
         bscCodBancos.Text = dr.Cells("IdBanco").Value.ToString()

         bscBancos.FilaDevuelta = dr
         bscCodBancos.FilaDevuelta = dr

         bscBancos.Selecciono = True
         bscCodBancos.Selecciono = True

         txtSucursalBanco.Focus()
      End If
   End Sub

   Private Sub LimpiarCamposCheques()
      txtIdCheque.SetValor(0)
      cmbTipoCheque.SelectedValue = "F"
      bscCodBancos.Text = String.Empty
      bscCodBancos.FilaDevuelta = Nothing
      bscCodBancos.Selecciono = False
      bscBancos.Text = String.Empty
      bscBancos.FilaDevuelta = Nothing
      bscBancos.Selecciono = False
      txtSucursalBanco.SetValor(0)
      txtCodPostalCheque.SetValor(0)
      txtNroCheque.SetValor(0)
      txtNroOperacion.Clear()
      dtpFechaCobro.Value = Date.Today
      dtpFechaEmision.Value = Date.Today
      txtCuitChequeTercero.Clear()
      txtTitularCheque.Clear()
      txtImporteCheque.SetValor(0)
   End Sub
   Private Function ValidarInsertarCheques() As Boolean

      If _situacionPredeterminada Is Nothing Then
         FindForm().ShowMessage("No está definida una situación de cheques por defecto. NO ES POSIBLE CONTINUAR.")
         Return False
      End If

      If txtImporteCheque.ValorNumericoPorDefecto(0D) <= 0 Then
         FindForm().ShowMessage("No puede ingresar un cheque con importe cero.")
         txtImporteCheque.Focus()
         Return False
      End If

      If txtNroCheque.ValorNumericoPorDefecto(0D) = 0 Then
         FindForm().ShowMessage("El número de cheque no puede ser cero.")
         txtNroCheque.Focus()
         Return False
      End If

      If Not bscBancos.Selecciono Then
         FindForm().ShowMessage("Debe seleccionar un Banco.")
         Me.bscBancos.Focus()
         Return False
      End If

      If txtSucursalBanco.ValorNumericoPorDefecto(0I) < 0 Then
         FindForm().ShowMessage("La Sucursal del Banco es inválida.")
         txtSucursalBanco.Focus()
         Return False
      End If

      If txtCodPostalCheque.ValorNumericoPorDefecto(0I) = 0 Then
         FindForm().ShowMessage("Debe ingresar un C.P. para el cheque.")
         txtCodPostalCheque.Focus()
         Return False
      Else
         If Not New Reglas.Localidades().Existe(txtCodPostalCheque.ValorNumericoPorDefecto(0I)) Then
            FindForm().ShowMessage("No existe la localidad del Cheque.")
            txtCodPostalCheque.Focus()
            Return False
         End If
      End If

      '# Validación del CUIT
      If String.IsNullOrEmpty(txtCuitChequeTercero.Text) Then
         FindForm().ShowMessage("Debe ingresar un Nro. CUIT para el Cheque.")
         Return False
      Else

         Dim result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.
                           Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() With
                                       {
                                          .IdFiscal = txtCuitChequeTercero.Text,
                                          .SolicitaCUIT = True
                                       }) '# Siempre solicitamos el CUIT al insertar el cheque por la nueva Alternative Key en BD
         If result.Error Then
            txtCuitChequeTercero.Focus()
            FindForm().ShowMessage(result.MensajeError)
            Return False
         End If

      End If

      '# Tipo de Cheque
      If cmbTipoCheque.SelectedIndex = -1 Then
         cmbTipoCheque.Focus()
         FindForm().ShowMessage("ATENCIÓN: No seleccionó un Tipo de Cheque.")
         Return False
      Else
         If cmbTipoCheque.ItemSeleccionado(Of Entidades.TiposCheques).SolicitaNroOperacion AndAlso
            String.IsNullOrEmpty(txtNroOperacion.Text) Then
            txtNroOperacion.Focus()
            FindForm().ShowMessage("ATENCIÓN: Debe ingresar un Número de Operación para el Tipo de Cheque seleccionado.")
            Return False
         End If
      End If

      'controlo que no se repita el cheque ingresado
      If Cheques.Any(Function(ent)
                        Return ent.NumeroCheque = txtNroCheque.ValorNumericoPorDefecto(0I) And
                               ent.Banco.IdBanco = bscCodBancos.Text.ValorNumericoPorDefecto(0I) And
                               ent.IdBancoSucursal = txtSucursalBanco.ValorNumericoPorDefecto(0I) And
                               ent.Localidad.IdLocalidad = txtCodPostalCheque.ValorNumericoPorDefecto(0I)
                     End Function) Then
         FindForm().ShowMessage("El cheque ya esta ingresado.")
         Return False
      End If

      Return True
   End Function
   Private Sub InsertarChequesGrilla()
      Dim oLineaDetalle = New Entidades.Cheque()
      With oLineaDetalle
         .IdCheque = txtIdCheque.ValorNumericoPorDefecto(0I)
         .IdTipoCheque = cmbTipoCheque.ValorSeleccionado(Of String)()
         .NombreTipoCheque = cmbTipoCheque.Text
         .Banco = New Reglas.Bancos().GetUno(bscCodBancos.Text.ValorNumericoPorDefecto(0I))
         .IdBancoSucursal = txtSucursalBanco.ValorNumericoPorDefecto(0I)
         .Localidad.IdLocalidad = txtCodPostalCheque.ValorNumericoPorDefecto(0I)
         .NumeroCheque = txtNroCheque.ValorNumericoPorDefecto(0I)
         .NroOperacion = txtNroOperacion.Text
         .FechaEmision = dtpFechaEmision.Value
         .FechaCobro = dtpFechaCobro.Value
         .Cuit = txtCuitChequeTercero.Text
         .Titular = txtTitularCheque.Text
         .Importe = txtImporteCheque.ValorNumericoPorDefecto(0D)

         .IdEstadoCheque = Entidades.Cheque.Estados.ALTA
         .IdSituacionCheque = _situacionPredeterminada.IdSituacionCheque
         .NombreSituacionCheque = _situacionPredeterminada.NombreSituacionCheque
         ''''.Cliente.IdCliente = _clienteE.IdCliente
         ''''.Cliente.CodigoCliente = _clienteE.CodigoCliente
         ''''.Usuario = actual.Nombre
      End With

      DirectCast(Cheques, IList).Add(oLineaDetalle)
      OnRefreshGrid()

      LimpiarCamposCheques()

   End Sub
   Private Sub EliminarLineaCheques()
      Dim dr = ugCheques.FilaSeleccionada(Of Entidades.Cheque)()
      If dr IsNot Nothing Then
         DirectCast(Cheques, IList).Remove(dr)
         OnRefreshGrid()
      End If
   End Sub
   Private Sub CargarChequeCompleto()
      Dim chq = ugCheques.FilaSeleccionada(Of Entidades.Cheque)()
      If chq IsNot Nothing Then
         With chq
            txtIdCheque.SetValor(chq.IdCheque)
            cmbTipoCheque.SelectedValue = .IdTipoCheque
            If .Banco IsNot Nothing AndAlso .Banco.IdBanco > 0 Then
               bscCodBancos.Text = .Banco.IdBanco.ToString()
               bscCodBancos.PresionarBoton()
            End If
            txtSucursalBanco.SetValor(.IdBancoSucursal)
            txtCodPostalCheque.SetValor(.Localidad.IdLocalidad)
            txtNroCheque.SetValor(.NumeroCheque)
            txtNroOperacion.Text = .NroOperacion
            dtpFechaEmision.Value = .FechaEmision
            dtpFechaCobro.Value = .FechaCobro
            txtImporteCheque.SetValor(.Importe)
            txtCuitChequeTercero.Text = .Cuit
            txtTitularCheque.Text = .Titular
         End With
      End If
   End Sub
#End Region


#Region "OnRefreshGrid Event Members"

   Public Event BeforeRefreshGrid As EventHandler(Of RefreshGridEventArgs)
   Public Event PerformRefreshGrid As EventHandler(Of RefreshGridEventArgs)
   Public Event AfterRefreshGrid As EventHandler(Of RefreshGridEventArgs)

   Protected Sub OnRefreshGrid()
      Dim e = New RefreshGridEventArgs() With {.Grid = ugCheques, .Cheques = Cheques, .Cancel = False}
      OnBeforeRefreshGrid(e)
      If Not e.Cancel Then
         OnPerformRefreshGrid(e)
         If Not e.Cancel Then
            OnAfterRefreshGrid(e)
         End If
      End If
   End Sub
   Protected Sub OnBeforeRefreshGrid(e As RefreshGridEventArgs)
      RaiseEvent BeforeRefreshGrid(Me, e)
   End Sub
   Protected Sub OnPerformRefreshGrid(e As RefreshGridEventArgs)
      e.Grid.Rows.Refresh(RefreshRow.FireInitializeRow)
      RaiseEvent PerformRefreshGrid(Me, e)
   End Sub
   Protected Sub OnAfterRefreshGrid(e As RefreshGridEventArgs)
      RaiseEvent AfterRefreshGrid(Me, e)
   End Sub

   Public Class RefreshGridEventArgs
      Inherits EventArgs
      Public Property Grid As UltraGrid
      Public Property Cheques As IEnumerable(Of Entidades.Cheque)
      Public Property Cancel As Boolean
   End Class
#End Region


End Class