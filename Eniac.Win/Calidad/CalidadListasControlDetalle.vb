Public Class CalidadListasControlDetalle

   Private _publicos As Publicos
   Private _dtItems As DataTable
   Private _dtListaControlItems As DataTable

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.CalidadListaControl)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

   Public ReadOnly Property ListaControl() As Entidades.CalidadListaControl
      Get
         Return DirectCast(_entidad, Entidades.CalidadListaControl)
      End Get
   End Property


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
      Sub()
         _publicos = New Publicos()

         '# Carga Combos
         _publicos.CargaComboTiposListasControl(cmbTipoListaControl)

         BindearControles(_entidad)

         If StateForm = Win.StateForm.Insertar Then
            txtIdEdicion.SetValor(New Reglas.CalidadListasControl().GetCodigoMaximo() + 1)

         End If

      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControl()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      MyBase.ValidarDetalle()

      '''''# Validar que se haya seleccionado un Tipo de Lista de Control
      ''''If cmbTipoListaControl.SelectedIndex = -1 Then
      ''''   Return "Debe seleccionar un Tipo de Lista de Control."
      ''''End If

      Return String.Empty
   End Function

#End Region

#Region "Eventos"

#End Region

#Region "Metodos"

#End Region

End Class