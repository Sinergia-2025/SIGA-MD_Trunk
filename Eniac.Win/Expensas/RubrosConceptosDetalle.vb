Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class RubrosConceptosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.RubroConcepto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         DirectCast(Me._entidad, Entidades.RubroConcepto).Usuario = actual.Nombre
      End If

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RubrosConceptos
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarProximoNumero()
      'End If
      Me.txtRubro.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oRubroConcepto As Reglas.RubrosConceptos = New Reglas.RubrosConceptos()
      Me.txtRubro.Text = (oRubroConcepto.GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class
