Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SueldosTiposConceptosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.SueldosTipoConcepto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.SueldosTipoConcepto).Usuario = actual.Nombre
         Me.CargarProximoNumero()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosTiposConceptos()
   End Function

   'Protected Overrides Sub Aceptar()
   '    MyBase.Aceptar()
   '    Me.txtIdTipoConcepto.Focus()
   'End Sub

   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse(Me.txtIdTipoConcepto.Text) = 0 Then
         Me.txtIdTipoConcepto.Focus()
         Return "Debe cargar un Código válido."
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdTipoConcepto.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oSTC As Reglas.SueldosTiposConceptos = New Reglas.SueldosTiposConceptos()
      Me.txtIdTipoConcepto.Text = (oSTC.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class




