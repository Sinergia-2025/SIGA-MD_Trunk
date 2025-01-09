Public Class AlertasMutualDetalle

   Private Property TipoNovedad As Entidades.CRMTipoNovedad

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.CRMNovedad, TipoNovedad As Entidades.CRMTipoNovedad)
      Me.InitializeComponent()
      Me._entidad = entidad
      Me.TipoNovedad = TipoNovedad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim p As New Eniac.Win.Publicos

      p.CargaComboCRMTiposNovedades(Me.cmbTipoNovedad, TipoNovedad.IdTipoNovedad)
      p.CargaComboCRMCategoriasNovedades(Me.cmbTipoNotificacion, "ALERTAS")
      Me.cmbTipoNotificacion.SelectedIndex = 1

      Me._liSources.Add("TipoNovedad", DirectCast(Me._entidad, Entidades.CRMNovedad).TipoNovedad)
      Me._liSources.Add("CategoriaNovedad", DirectCast(Me._entidad, Entidades.CRMNovedad).CategoriaNovedad)


      ' Me._liSources.Add("Cliente", DirectCast(Me._entidad, Entidades.CRMNovedad).IdCliente)
      '    Me._liSources.Add("TipoNotificacion", DirectCast(Me._entidad, Entidades.CRMMedioComunicacionNovedad).IdMedioComunicacionNovedad)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.dtpFecha.Value = DateTime.Now
         Me.cmbTipoNotificacion.SelectedValue = 2  'Llamada Saliente
         DirectCast(Me._entidad, Entidades.CRMNovedad).EstadoNovedad = New Reglas.CRMEstadosNovedades().GetUno(100)
         DirectCast(Me._entidad, Entidades.CRMNovedad).PrioridadNovedad = New Reglas.CRMPrioridadesNovedades().GetUno(100)
         DirectCast(Me._entidad, Entidades.CRMNovedad).EstadoNovedad = New Reglas.CRMEstadosNovedades().GetUno(100)
         DirectCast(Me._entidad, Entidades.CRMNovedad).MedioComunicacionNovedad = New Reglas.CRMMediosComunicacionesNovedades().GetUno(1)
         DirectCast(Me._entidad, Entidades.CRMNovedad).UsuarioAsignado = New Reglas.Usuarios().GetUno(DirectCast(Me._entidad, Entidades.CRMNovedad).Usuario)

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMNovedades()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.Close()
   End Sub

#End Region

   Private Sub chbDesactivar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDesactivar.CheckedChanged
      If Me.chbDesactivar.Checked Then
         If Me.dtpFecha.Value > Date.Now() Then
            Dim resp As DialogResult = MessageBox.Show("La fecha de la Alerta aun no se ha cumplido. Esta seguro que desea desactivarla?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If resp = Windows.Forms.DialogResult.No Then
               Me.chbDesactivar.Checked = False
            End If
         End If
      End If
   End Sub
End Class