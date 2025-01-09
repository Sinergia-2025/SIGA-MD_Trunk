Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SueldosEstadoCivilDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.SueldosEstadoCivil)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.SueldosEstadoCivil).Usuario = actual.Nombre
         Me.CargarProximoNumero()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosEstadoCivil()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse(Me.txtIdEstadoCivil.Text) = 0 Then
         Me.txtIdEstadoCivil.Focus()
         Return "Debe cargar un Código válido."
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdEstadoCivil.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oSC As Reglas.SueldosEstadoCivil = New Reglas.SueldosEstadoCivil()
      Me.txtIdEstadoCivil.Text = (oSC.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class




