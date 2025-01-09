Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SueldosObraSocialDetalle

#Region "Constructores"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal entidad As Entidades.SueldosObraSocial)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

        Me.BindearControles(Me._entidad)

        If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            DirectCast(Me._entidad, Entidades.SueldosObraSocial).Usuario = actual.Nombre
         Me.CargarProximoNumero()
      End If

    End Sub

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.SueldosObraSocial()
    End Function

   'Protected Overrides Sub Aceptar()
   '    MyBase.Aceptar()
   '    Me.txtIdObraSocial.Focus()
   'End Sub

   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse(Me.txtIdObraSocial.Text) = 0 Then
         Me.txtIdObraSocial.Focus()
         Return "Debe cargar un Código válido."
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdObraSocial.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oSC As Reglas.SueldosObraSocial = New Reglas.SueldosObraSocial()
      Me.txtIdObraSocial.Text = (oSC.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class




