Public Class ucMedioPagoTarjeta
   Private _publicos As Publicos

   Public Property Tarjetas As IEnumerable(Of Entidades.ITarjetas)
   Private _newTarjeta As Func(Of Entidades.ITarjetas)
   Private _tit As Dictionary(Of String, String)

   Public Sub Inicializar(tarjetas As IEnumerable(Of Entidades.ITarjetas), newTarjeta As Func(Of Entidades.ITarjetas))
      If newTarjeta Is Nothing Then
         Throw New ArgumentNullException(NameOf(newTarjeta))
      End If

      _Tarjetas = tarjetas
      _newTarjeta = newTarjeta

      _tit = DirectCast(FindForm(), BaseForm).GetColumnasVisiblesGrilla(ugTarjetas)
      ugTarjetas.DataSource = _Tarjetas
      DirectCast(FindForm(), BaseForm).AjustarColumnasGrilla(ugTarjetas, _tit)

      ugTarjetas.AgregarTotalesSuma({"Monto"})

   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      If Not DesignMode Then
         TryCatched(
            Sub()
               _publicos = New Publicos()

               _publicos.CargaComboTarjetasE(cmbTarTarjeta, True)
            End Sub)
      End If
   End Sub

#Region "Eventos"
   Private Sub cmbTarTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTarTarjeta.KeyDown, txtTarMonto.KeyDown, txtTarCuotas.KeyDown, txtTarNumeroCupon.KeyDown, txtTarNumeroLote.KeyDown
      PresionarTab(e)
   End Sub
#Region "Eventos Buscador Banco Tarjeta"
   Private Sub bscTarBanco_BuscadorClick() Handles bscTarBanco.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaBancos(bscTarBanco)
            bscTarBanco.Datos = New Reglas.Bancos().GetFiltradoPorNombre(bscTarBanco.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscTarBanco_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscTarBanco.BuscadorSeleccion
      TryCatched(Sub() CargarDatosTarjetasBancos(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Insertar/Borrar/Editar"
   Private Sub btnInsertarTarjeta_Click(sender As Object, e As EventArgs) Handles btnInsertarTarjeta.Click
      TryCatched(
         Sub()
            If ValidarInsertarTarjeta() Then
               InsertarTarjetaGrilla()
               cmbTarTarjeta.Focus()
            End If
         End Sub)
   End Sub
   Private Sub btnEliminarTarjeta_Click(sender As Object, e As EventArgs) Handles btnEliminarTarjeta.Click
      TryCatched(
         Sub()
            If ugTarjetas.ActiveRow IsNot Nothing Then
               If FindForm().ShowPregunta("¿Esta seguro de eliminar la tarjeta seleccionada?") = DialogResult.Yes Then
                  EliminarLineaTarjetas()
               End If
            End If
         End Sub)
   End Sub
   Private Sub ugTarjetas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugTarjetas.DoubleClickRow
      TryCatched(
         Sub()
            Dim dr = ugTarjetas.FilaSeleccionada(Of Entidades.ITarjetas)()
            If dr IsNot Nothing Then
               LimpiarCamposTarjetas()
               'carga el producto seleccionado de la grilla en los textbox 
               CargarTarjetaCompleto(dr)
               'elimina el producto de la grilla
               EliminarLineaTarjetas()
            End If
         End Sub)
   End Sub
#End Region

#End Region

#Region "Métodos"
   Private Sub CargarDatosTarjetasBancos(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscTarBanco.Text = dr.Cells("NombreBanco").Value.ToString()
         ''''txtTarMonto.Text = txtDiferencia.Text
         txtTarMonto.Focus()
      End If
   End Sub

   Private Sub LimpiarCamposTarjetas()
      cmbTarTarjeta.SelectedIndex = -1
      bscTarBanco.Text = ""
      bscTarBanco.FilaDevuelta = Nothing
      txtTarCuotas.Text = "1"
      txtTarMonto.Text = "0"
      txtTarNumeroCupon.Text = "0"
      txtTarNumeroLote.Text = "0"
   End Sub
   Private Function ValidarInsertarTarjeta() As Boolean

      If Me.cmbTarTarjeta.SelectedIndex = -1 Then
         MessageBox.Show("Debe seleccionar una Tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.cmbTarTarjeta.Focus()
         Return False
      End If

      If Not Me.bscTarBanco.Selecciono Then
         MessageBox.Show("Debe seleccionar un Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.bscTarBanco.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtTarMonto.Text) <= 0 Then
         MessageBox.Show("No puede ingresar el importe menor a cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtTarMonto.Focus()
         Return False
      End If

      'controlo que no se repita la tarjeta ingresada
      If _Tarjetas.Any(Function(ent) ent.Tarjeta.IdTarjeta = Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString()) And
                                     ent.Banco.IdBanco = Integer.Parse(Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString())) Then
         FindForm().ShowMessage("La tarjeta ya fue ingresada.")
         Return False
      End If

      Return True
   End Function
   Private Sub InsertarTarjetaGrilla()
      InsertarTarjetaGrilla(New Reglas.Tarjetas().GetUno(Integer.Parse(Me.cmbTarTarjeta.SelectedValue.ToString())),
                            New Reglas.Bancos().GetUno(Integer.Parse(Me.bscTarBanco._filaDevuelta.Cells("IdBanco").Value.ToString())),
                            Decimal.Parse(Me.txtTarMonto.Text),
                            Integer.Parse(Me.txtTarCuotas.Text),
                            Integer.Parse(Me.txtTarNumeroLote.Text),
                            Integer.Parse(Me.txtTarNumeroCupon.Text))
   End Sub
   Private Sub InsertarTarjetaGrilla(tarjeta As Entidades.Tarjeta, banco As Entidades.Banco, monto As Decimal, cuotas As Integer, lote As Integer, numeroCupon As Integer)

      If _newTarjeta Is Nothing Then
         Throw New Exception("No se inicializó el user control de Medio Pago Tarjeta. Debe ejecutar Inicializar y suministrar una función para newTarjeta")
      End If

      Dim oLineaDetalle = _newTarjeta()

      With oLineaDetalle
         .Tarjeta = tarjeta
         .Banco = banco
         .Monto = monto
         .Cuotas = cuotas
         .NumeroLote = lote
         .NumeroCupon = numeroCupon
      End With

      DirectCast(_Tarjetas, IList).Add(oLineaDetalle)
      OnRefreshGrid()

      LimpiarCamposTarjetas()
   End Sub
   Private Sub EliminarLineaTarjetas()
      Dim dr = ugTarjetas.FilaSeleccionada(Of Entidades.ITarjetas)()
      If dr IsNot Nothing Then
         DirectCast(Tarjetas, IList).Remove(dr)
         OnRefreshGrid()
      End If
   End Sub
   Private Sub CargarTarjetaCompleto(vt As Entidades.ITarjetas)

      'Dim vt = ugTarjetas.FilaSeleccionada(Of Entidades.ITarjetas)

      If vt IsNot Nothing Then
         cmbTarTarjeta.SelectedValue = vt.Tarjeta.IdTarjeta
         If vt.Banco IsNot Nothing AndAlso vt.Banco.IdBanco > 0 Then
            bscTarBanco.Text = vt.Banco.NombreBanco
            bscTarBanco.PresionarBoton()
         End If

         txtTarMonto.Text = vt.Monto.ToString("N2")
         txtTarCuotas.Text = vt.Cuotas.ToString()
         txtTarNumeroCupon.Text = vt.NumeroCupon.ToString()
      End If
   End Sub
#End Region

#Region "OnRefreshGrid Event Members"

   Public Event BeforeRefreshGrid As EventHandler(Of RefreshGridEventArgs)
   Public Event PerformRefreshGrid As EventHandler(Of RefreshGridEventArgs)
   Public Event AfterRefreshGrid As EventHandler(Of RefreshGridEventArgs)

   Protected Sub OnRefreshGrid()
      Dim e = New RefreshGridEventArgs() With {.Grid = ugTarjetas, .Tarjetas = Tarjetas, .Cancel = False}
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
      Public Property Tarjetas As IEnumerable(Of Entidades.ITarjetas)
      Public Property Cancel As Boolean
   End Class
#End Region

End Class