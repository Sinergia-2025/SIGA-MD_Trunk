Public Class AplicacionesDetalle
   Private _publicos As Publicos

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Aplicacion)
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
         _publicos.CargaComboAplicaciones(cmbAplicacionBase)
         _publicos.CargaComboDesdeEnum(cmbPropietarioAplicacion, Entidades.AplicacionPropietario.PROPIO)

         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            DirectCast(_entidad, Entidades.Aplicacion).Usuario = actual.Nombre
         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Aplicaciones()
   End Function
   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      txtIdZonaGeografica.Focus()
   End Sub
#End Region

   Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
      TryCatched(Sub() cmbAplicacionBase.SelectedIndex = -1)
   End Sub
End Class