Public Class GestionesMutualDetalles
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

      p.CargaComboCRMCategoriasNovedades(Me.cmbTipoNotificacion, "GESTIONES")

      '   p.CargaComboTipoNotificacion(Me.cmbTipoNotificacion, "DOMINIOS")

      'Me._liSources.Add("Dato", DirectCast(Me._entidad, Entidades.GestionInmobiliario).Inmobiliario)

      Me._liSources.Add("TipoNovedad", DirectCast(Me._entidad, Entidades.CRMNovedad).TipoNovedad)
      Me._liSources.Add("CategoriaNovedad", DirectCast(Me._entidad, Entidades.CRMNovedad).CategoriaNovedad)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.dtpFecha.Value = DateTime.Now
         Me.txtUsuario.Text = Eniac.Entidades.Usuario.Actual.Nombre
         Me.cmbTipoNotificacion.SelectedValue = 2  'Llamada Saliente
         DirectCast(Me._entidad, Entidades.CRMNovedad).EstadoNovedad = New Reglas.CRMEstadosNovedades().GetUno(100)
         DirectCast(Me._entidad, Entidades.CRMNovedad).PrioridadNovedad = New Reglas.CRMPrioridadesNovedades().GetUno(100)
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

End Class