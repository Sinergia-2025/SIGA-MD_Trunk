Public Class CRMEstadosNovedadesDetalle

   Private _publicos As Publicos
   Private Property PosicionOriginal As Integer
   Private Property IdTipoNovedadOriginal As String

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Eniac.Entidades.CRMEstadoNovedad)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         _publicos.CargaComboDesdeEnum(cmbEntregado, GetType(Entidades.CRMEstadoNovedad.EntregadoValores))
         _publicos.CargaComboCRMEstadosNovedades(Me.cmbEstadoFacturado, DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).TipoNovedad.IdTipoNovedad)

         Me._liSources.Add("TipoNovedad", DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).TipoNovedad)

         Me.chbSolicitaProveedor.Visible = New Reglas.Funciones().ExisteFuncion("CRMNovedadesABMSERVICE")

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.txtCantidadCopias.Text = "1"
            txtIdEstadoNovedad.Text = (DirectCast(GetReglas(), Reglas.CRMEstadosNovedades).GetCodigoMaximo() + 1).ToString()
            PosicionOriginal = -1
            IdTipoNovedadOriginal = String.Empty
         Else
            PosicionOriginal = DirectCast(_entidad, Entidades.CRMEstadoNovedad).Posicion
            IdTipoNovedadOriginal = DirectCast(_entidad, Entidades.CRMEstadoNovedad).IdTipoNovedad

            If DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).Color.HasValue Then
               Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).Color.Value)
            Else
               Me.txtColor.BackColor = Nothing
            End If

            chbDiasProximoContacto.Checked = DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).DiasProximoContacto.HasValue
            Me.cmbTipoEstadoNovedad.SelectedValue = DirectCast(_entidad, Entidades.CRMEstadoNovedad).IdTipoEstadoNovedad

            If DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).IdEstadoFacturado.HasValue Then
               Me.cmbEstadoFacturado.SelectedValue = DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).IdEstadoFacturado.Value
               Me.txtAvanceEstadoFacturado.Text = DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).AvanceEstadoFacturado.Value.ToString()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CRMEstadosNovedades()
   End Function

   Protected Overrides Sub Aceptar()

      If Me.cmbTipoEstadoNovedad.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar un Tipo de Estado.")
         Me.cmbTipoEstadoNovedad.Focus()
         Exit Sub
      End If

      If Me.chbEsFacturable.Checked AndAlso Me.cmbEstadoFacturado.SelectedIndex = -1 Then
         ShowMessage("ATENCIÓN: Si el estado actual 'Es Facturable' requiere un Estado luego de ser Facturado.")
         Me.cmbEstadoFacturado.Focus()
         Exit Sub
      End If

      If Me.chbEsFacturable.Checked AndAlso (String.IsNullOrEmpty(Me.txtAvanceEstadoFacturado.Text) OrElse CDec(Me.txtAvanceEstadoFacturado.Text) = 0) Then
         ShowMessage("ATENCIÓN: El avance del estado Facturado NO puede ser 0 %.")
         Me.txtAvanceEstadoFacturado.Focus()
         Exit Sub
      End If

      '# Estado facturado 
      Dim estado As Entidades.CRMEstadoNovedad = DirectCast(Me.cmbEstadoFacturado.SelectedItem, Entidades.CRMEstadoNovedad)
      If estado IsNot Nothing AndAlso Me.chbEsFacturable.Checked Then

         '# Si es superior a 100, lo bajo a 100.
         If CDec(Me.txtAvanceEstadoFacturado.Text) > 100 Then Me.txtAvanceEstadoFacturado.Text = "100.00"

         '# Si el estado es de tipo "Finalizado", el % avance elegido debe ser 100%
         If estado.Finalizado AndAlso
            Me.chbEsFacturable.Checked AndAlso
            Not String.IsNullOrEmpty(Me.txtAvanceEstadoFacturado.Text) AndAlso
            CDec(Me.txtAvanceEstadoFacturado.Text) <> 100 Then

            ShowMessage(String.Format("ATENCIÓN: El estado {0} es 'Finalizado' y requiere un avance del 100% al ser Facturado.", estado.NombreEstadoNovedad))
            Exit Sub
         End If

         '# Si el estado NO es de tipo "Finalizado", el % avance elegido debe ser MENOR a 100%
         If Not estado.Finalizado AndAlso
            Me.chbEsFacturable.Checked AndAlso
            Not String.IsNullOrEmpty(Me.txtAvanceEstadoFacturado.Text) AndAlso
            CDec(Me.txtAvanceEstadoFacturado.Text) = 100 Then

            ShowMessage(String.Format("ATENCIÓN: El estado {0} NO es 'Finalizado' y requiere un avance MENOR a 100% al ser Facturado.", estado.NombreEstadoNovedad))
            Exit Sub
         End If

      End If

      DirectCast(_entidad, Entidades.CRMEstadoNovedad).IdTipoEstadoNovedad = DirectCast(Me.cmbTipoEstadoNovedad.SelectedItem, Entidades.CRMTipoEstadoNovedad).IdTipoEstadoNovedad
      DirectCast(_entidad, Entidades.CRMEstadoNovedad).IdEstadoFacturado = If(Me.cmbEstadoFacturado.SelectedIndex > -1, CInt(Me.cmbEstadoFacturado.SelectedValue), Nothing)
      DirectCast(_entidad, Entidades.CRMEstadoNovedad).AvanceEstadoFacturado = If(Me.cmbEstadoFacturado.SelectedIndex > -1, Decimal.Parse(Me.txtAvanceEstadoFacturado.Text), Nothing)

      If Not chbDiasProximoContacto.Checked Then
         DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).DiasProximoContacto = Nothing
      End If
      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If chbDiasProximoContacto.Checked And String.IsNullOrWhiteSpace(txtDiasProximoContacto.Text) Then
         txtDiasProximoContacto.Focus()
         Return "Debe indicar una cantidad de días de próximo contacto."
      End If
      Return MyBase.ValidarDetalle()
   End Function

#End Region

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         If cmbTipoNovedad.SelectedIndex >= 0 Then

            If IdTipoNovedadOriginal <> cmbTipoNovedad.SelectedValue.ToString() Then
               txtPosicion.Text = (DirectCast(GetReglas(), Reglas.CRMEstadosNovedades).GetPosicionMaxima(cmbTipoNovedad.SelectedValue.ToString()) + 1).ToString()
            Else
               txtPosicion.Text = PosicionOriginal.ToString()
            End If
            _publicos.CargaComboCRMTiposEstadosNovedades(Me.cmbTipoEstadoNovedad, cmbTipoNovedad.SelectedValue.ToString())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.CRMEstadoNovedad).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbDiasProximoContacto_CheckedChanged(sender As Object, e As EventArgs) Handles chbDiasProximoContacto.CheckedChanged
      txtDiasProximoContacto.Enabled = chbDiasProximoContacto.Checked
   End Sub

   Private Sub chbEsFacturable_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsFacturable.CheckedChanged
      Try
         Me.pFacturable.Visible = Me.chbEsFacturable.Checked
         Me.lblEstadoLuego.Visible = Me.chbEsFacturable.Checked
         If Not Me.chbEsFacturable.Checked Then
            Me.cmbEstadoFacturado.SelectedIndex = -1
            Me.txtAvanceEstadoFacturado.Text = "1"
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtAvanceEstadoFacturado_Leave(sender As Object, e As EventArgs) Handles txtAvanceEstadoFacturado.Leave
      Try
         If CDec(Me.txtAvanceEstadoFacturado.Text) > 100 Then
            Me.txtAvanceEstadoFacturado.Text = "100.00"
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class