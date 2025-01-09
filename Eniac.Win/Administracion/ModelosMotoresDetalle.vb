Public Class ModelosMotoresDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean = True

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.ModeloMotor)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboMarcasMotores(cmbMarcasMotor)

         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoCodigo()
         End If

         _cargandoPantalla = False
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ModelosMotores()
   End Function

   'Protected Overrides Function ValidarDetalle() As String

   '   'If Math.Abs(Decimal.Parse(Me.txtDescuentoRecargo.Text)) >= 100 Then
   '   '   Return "El Descuento/Recargo NO es Válido."
   '   'End If

   '   Return MyBase.ValidarDetalle()

   'End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub lnkMarcaEmbarcacion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkMarcaMotor.LinkClicked
      TryCatched(
      Sub()
         Using frm = New MarcasMotoresDetalle(New Entidades.MarcaMotor())
            frm.StateForm = Win.StateForm.Insertar
            frm.ShowDialog()
            _publicos.CargaComboMarcasMotores(cmbMarcasMotor)
         End Using
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      txtIdModeloMotor.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      txtIdModeloMotor.Text = (New Reglas.ModelosMotores().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class