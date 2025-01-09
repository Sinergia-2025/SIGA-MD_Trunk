Public Class CalidadListasControlItemsDetalle
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True

   Public ReadOnly Property CalidadListaControlItem As Entidades.CalidadListaControlItem
      Get
         Return DirectCast(_entidad, Entidades.CalidadListaControlItem)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CalidadListaControlItem)
      InitializeComponent()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _estaCargando = True
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbNivelInspeccion, GetType(Entidades.NivelInspeccionMRP))
         _publicos.CargaComboCalidadListaControlItemGrupo(cmbGrupo)

         If Not String.IsNullOrWhiteSpace(CalidadListaControlItem.IdListaControlItemGrupo) Then
            _publicos.CargaComboCalidadListasControlItemSubGrupos(cmbSubGrupo, CalidadListaControlItem.IdListaControlItemGrupo)
         End If

         _liSources.Add("Grupo", CalidadListaControlItem.Grupo)
         _liSources.Add("SubGrupo", CalidadListaControlItem.SubGrupo)

         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdListaControlItem.Text = (New Reglas.CalidadListasControlItems().GetCodigoMaximo() + 1).ToString()
         Else

         End If

         _estaCargando = False
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControlItems()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      If Not HayError And StateForm = Eniac.Win.StateForm.Insertar Then
         Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If cmbSubGrupo.Any() AndAlso cmbSubGrupo.SelectedIndex < 0 Then
         cmbSubGrupo.Focus()
         Return "Debe seleccionar un SubGrupo"
      End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
   Private Sub cmbGruposItemsListasControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
      TryCatched(
      Sub()
         If Not _estaCargando AndAlso cmbGrupo.SelectedIndex >= 0 Then
            _publicos.CargaComboCalidadListasControlItemSubGrupos(cmbSubGrupo, cmbGrupo.SelectedValue.ToString())
            cmbSubGrupo.SelectedIndex = -1
         End If
         cmbSubGrupo.Enabled = cmbSubGrupo.Any()
         btnLimpiarProducto.Enabled = cmbSubGrupo.Any()
      End Sub)
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      TryCatched(Sub() cmbSubGrupo.SelectedIndex = -1)
   End Sub

#End Region

End Class