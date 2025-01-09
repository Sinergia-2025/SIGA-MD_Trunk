Public Class NavesDetalle

   Private _publicos As Publicos

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Nave)
      Me.New()
      _entidad = entidad
   End Sub

#End Region


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      _tituloNuevo = "Nueva"
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()
            '_publicos.CargaComboEstadoNave(Me.cmbEstados)

            _publicos.CargaComboTipoNave(cmbTipoNave)

            BindearControles(_entidad)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               'cmbEstados. = Entidades.Nave.Estados.Alta
               CargarProximoCodigo()
            End If
         End Sub)

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Naves()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      'If Long.Parse(Me.txtm3.Text) = 0 Then
      '   Me.txtm3.Focus()
      '   Return "Debe Ingresar los M3."
      'End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      ' DirectCast(Me._entidad, Entidades.Nave).IdTipoNave = DirectCast(cmbTipoNave.SelectedItem, Entidades.TipoNave)
      MyBase.Aceptar()
   End Sub

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdNave.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim proximaNave = New Reglas.Naves().GetCodigoMaximo() + 1
      txtIdNave.Text = proximaNave.ToString()
   End Sub

#End Region

End Class