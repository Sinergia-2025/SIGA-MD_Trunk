Public Class DestinosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Destino)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

   Private _publicos As Publicos

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      Me._tituloNuevo = "Nueva"

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()
      'Me._publicos.CargaComboEstadoDestino(Me.cmbEstados)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         'Me.cmbEstados. = Eniac.SiSeN.Entidades.Destino.Estados.Alta
         Me.CargarProximoCodigo()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Destinos()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      'If Long.Parse(Me.txtm3.Text) = 0 Then
      '   Me.txtm3.Focus()
      '   Return "Debe Ingresar los M3."
      'End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdDestino.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim oRegDestinos As Reglas.Destinos = New Reglas.Destinos()
      Dim ProximaDestino As Integer
      ProximaDestino = oRegDestinos.GetCodigoMaximo(Entidades.Destino.Columnas.IdDestino.ToString()) + 1
      Me.txtIdDestino.Text = ProximaDestino.ToString()
   End Sub

#End Region

End Class