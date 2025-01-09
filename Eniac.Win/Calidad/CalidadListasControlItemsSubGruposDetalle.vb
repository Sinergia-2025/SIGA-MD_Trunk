Public Class CalidadListasControlItemsSubGruposDetalle
   Private _publicos As Publicos

   Public ReadOnly Property CalidadListaControlItemSubGrupo As Entidades.CalidadListaControlItemSubGrupo
      Get
         Return DirectCast(_entidad, Entidades.CalidadListaControlItemSubGrupo)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CalidadListaControlItemSubGrupo)
      InitializeComponent()
      _entidad = entidad
   End Sub
#End Region

#Region "Eventos"

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboCalidadListaControlItemGrupo(cmbGruposItemsListasControl)

         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            '  txtIdSubGrupoListaControlItem.Text = (New Reglas.SubGruposListasControlItems().GetCodigoMaximo() + 1).ToString()
         Else

         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControlItemsSubGrupos()
   End Function

   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()

      If Not HayError And StateForm = Eniac.Win.StateForm.Insertar Then
         Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

End Class