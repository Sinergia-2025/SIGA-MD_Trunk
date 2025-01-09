Public Class MovilRutasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _titPrecios As Dictionary(Of String, String)

   Private ReadOnly Property Ruta As Entidades.MovilRuta
      Get
         Return DirectCast(_entidad, Entidades.MovilRuta)
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.MovilRuta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _titPrecios = GetColumnasVisiblesGrilla(ugListasDePrecios)

         _publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboTransportistas(Me.cmbTransportista)

         _publicos.CargaComboDesdeEnum(cmbConfiguraClienteSegun, GetType(Entidades.OrigenConfiguraClienteSegun))

         _publicos.CargaComboListaDePrecios(cmbListasDePrecios)
         cmbListasDePrecios.SelectedIndex = -1

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Ruta.Usuario = actual.Nombre
            Me.CargarProximoNumero()

            Me.chbActiva.Checked = True
         Else
            Me.cmbVendedor.SelectedItem = GetVendedorDeCombo(Ruta.IdVendedor)
         End If

         '--- REQ 31772 Seba C. ---
         txtDescuentoMax.Text = DirectCast(Me._entidad, Entidades.MovilRuta).DescuentoMax.ToString()
         txtRecargaMax.Text = DirectCast(Me._entidad, Entidades.MovilRuta).RecargaMax.ToString()

         If txtDescuentoMax.Text > "0" Then
            txtDescuentoMax.Enabled = True
            chbDescuentoMax.Checked = True
         Else
            txtDescuentoMax.Enabled = False
            chbDescuentoMax.Checked = False
         End If
         If txtRecargaMax.Text > "0" Then
            txtRecargaMax.Enabled = True
            chbRecargaMax.Checked = True
         Else
            txtRecargaMax.Enabled = False
            chbRecargaMax.Checked = False
         End If
         '------------------------------------------------------------------------------------------------

         ugListasDePrecios.DataSource = Ruta.ListasDePrecio
         AjustarColumnasGrilla(ugListasDePrecios, _titPrecios)

         RefrescarCmbListas()

         Me._estaCargando = False

         EvalueHabilitarTabs()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MovilRutas()
   End Function

   Protected Overrides Sub Aceptar()
      If GetVendedorSeleccionados() IsNot Nothing Then
         Ruta.IdVendedor = GetVendedorSeleccionados().IdEmpleado
      End If
      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If GetVendedorSeleccionados() Is Nothing Then
         cmbVendedor.Focus()
         Return "Debe seleccionar un vendedor"
      End If
      If Ruta.ListasDePrecio.Count > 0 Then
         Dim CuentaPorDefecto As Integer = Ruta.CuentaListaDePreciosPorDefecto()
         If CuentaPorDefecto > 1 Then
            Return "Existe más de una lista de precios por defecto"
         End If
         If CuentaPorDefecto = 0 Then
            Return "Debe seleccionar una lista de precios por defecto"
         End If
      End If

      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Eventos"
   Private Sub txtRuta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuta.KeyDown, txtNombreRuta.KeyDown, chbActiva.KeyDown, txtIdDispositivoPorDefecto.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub lblActiva_Click(sender As Object, e As EventArgs) Handles lblActiva.Click
      chbActiva.Checked = Not chbActiva.Checked
   End Sub

#Region "Eventos chbEsDe..."
   Private Sub chbEsDeCobranza_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsDeCobranza.CheckedChanged
      EvalueHabilitarTabs()
   End Sub
   Private Sub chbEsDePedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsDePedidos.CheckedChanged
      EvalueHabilitarTabs()
      '-.PE-32239.-
      If chbEsDePedidos.Checked Then
         cmbTransportista.IsRequired = True
      Else
         cmbTransportista.IsRequired = False
      End If

   End Sub
   Private Sub chbEsDeGestion_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsDeGestion.CheckedChanged
      EvalueHabilitarTabs()
   End Sub
#End Region

#Region "Eventos Lista de Precios"
   Private Sub btnInsertarListasDePrecios_Click(sender As Object, e As EventArgs) Handles btnInsertarListasDePrecios.Click
      Try
         If cmbListasDePrecios.SelectedItem IsNot Nothing Then

            Dim lista As Eniac.Entidades.ListaDePrecios = DirectCast(cmbListasDePrecios.SelectedItem, Eniac.Entidades.ListaDePrecios)
            If Ruta.ExisteListaDePrecios(lista) Then
               ShowMessage("La lista de precios ya se encuentra asociada a la Ruta.")
            Else

               Dim rutaLista As Entidades.MovilRutaListaDePrecios = New Entidades.MovilRutaListaDePrecios()
               rutaLista.ListaDePrecios = lista
               rutaLista.PorDefecto = chbPorDefecto.Checked
               rutaLista.AplicaPreciosOferta = chbAplicaPreciosOferta.Checked

               Ruta.ListasDePrecio.Add(rutaLista)
               ugListasDePrecios.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData)
               RefrescarCmbListas()
               cmbListasDePrecios.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnRefrescarListasDePrecios_Click(sender As Object, e As EventArgs) Handles btnRefrescarListasDePrecios.Click
      Try
         RefrescarCmbListas()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminarListasDePrecios_Click(sender As Object, e As EventArgs) Handles btnEliminarListasDePrecios.Click
      Try
         Dim dr As Entidades.MovilRutaListaDePrecios = ugListasDePrecios.FilaSeleccionada(Of Entidades.MovilRutaListaDePrecios)()
         If dr IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar la Lista de Precios seleccionada?") = Windows.Forms.DialogResult.Yes Then
               Ruta.ListasDePrecio.Remove(dr)
               ugListasDePrecios.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData)
               RefrescarCmbListas()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbListasDePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbListasDePrecios.KeyDown, chbPorDefecto.KeyDown, chbAplicaPreciosOferta.KeyDown
      Try
         PresionarTab(e)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarListasDePrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles btnInsertarListasDePrecios.KeyDown
      Try
         EnterClickBoton(btnInsertarListasDePrecios, e)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugListasDePrecios_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugListasDePrecios.DoubleClickRow
      Try

         Dim dr As Entidades.MovilRutaListaDePrecios = ugListasDePrecios.FilaSeleccionada(Of Entidades.MovilRutaListaDePrecios)()
         If dr IsNot Nothing Then

            cmbListasDePrecios.SelectedValue = dr.IdListaPrecios
            chbPorDefecto.Checked = dr.PorDefecto
            chbAplicaPreciosOferta.Checked = dr.AplicaPreciosOferta
            Ruta.ListasDePrecio.Remove(dr)
            ugListasDePrecios.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData)
            cmbListasDePrecios.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
#End Region
#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oRuta As Reglas.MovilRutas = New Reglas.MovilRutas()
      Me.txtRuta.Text = (oRuta.GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Function GetVendedorDeCombo(IdVendedor As Integer) As Entidades.Empleado
      Return DirectCast(cmbVendedor.DataSource, List(Of Entidades.Empleado)) _
                        .DefaultIfEmpty(Nothing) _
                        .FirstOrDefault(Function(x) x.IdEmpleado = IdVendedor)
   End Function

   Private Function GetVendedorSeleccionados() As Entidades.Empleado
      If cmbVendedor.SelectedIndex < 0 Then
         Return Nothing
      Else
         Return DirectCast(cmbVendedor.SelectedItem, Entidades.Empleado)
      End If
   End Function

   Private Sub RefrescarCmbListas()
      chbPorDefecto.Checked = Ruta.CuentaListaDePreciosPorDefecto() = 0
      cmbListasDePrecios.SelectedIndex = -1
      cmbListasDePrecios.Focus()
   End Sub

   Private Sub EvalueHabilitarTabs()
      Try
         If tbcDetalle.Tabs.Exists("tbpPedidos") Then
            tbcDetalle.Tabs("tbpPedidos").Enabled = chbEsDePedidos.Checked
         End If
         If tbcDetalle.Tabs.Exists("tbpCobranza") Then
            tbcDetalle.Tabs("tbpCobranza").Enabled = chbEsDeCobranza.Checked
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbDescuentoMax_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoMax.CheckedChanged
      If chbDescuentoMax.Checked Then
         txtDescuentoMax.Enabled = True
      Else
         txtDescuentoMax.Enabled = False

      End If
   End Sub

   Private Sub chbRecargaMax_CheckedChanged(sender As Object, e As EventArgs) Handles chbRecargaMax.CheckedChanged
      If chbRecargaMax.Checked Then
         txtRecargaMax.Enabled = True
      Else
         txtRecargaMax.Enabled = False

      End If
   End Sub

   Private Sub txtDescuentoMax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoMax.KeyDown
      If Val(txtDescuentoMax.Text) < 0 Then
         ShowMessage("No se permite valores negativos, Reingrese")
         txtDescuentoMax.Text = ""
         txtDescuentoMax.Focus()
      End If
   End Sub

   Private Sub txtRecargaMax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRecargaMax.KeyDown
      If Val(txtRecargaMax.Text) < 0 Then
         ShowMessage("No se permite valores negativos, Reingrese")
         txtRecargaMax.Text = ""
         txtRecargaMax.Focus()
      End If
   End Sub


#End Region

End Class