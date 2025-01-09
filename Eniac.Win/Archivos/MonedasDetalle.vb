#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region

Public Class MonedasDetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Moneda)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdMoneda.Text = (New Reglas.Monedas().GetCodigoMaximo() + 1).ToString()
            With DirectCast(_entidad, Entidades.Moneda)
               .IdTipoMoneda = txtIdMoneda.Text
               .OperadorConversion = "*"
               .FactorConversion = 1
               .IdBanco = Nothing
            End With
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Monedas
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If Integer.Parse(Me.txtIdMoneda.Text) <= 0 Then
         Me.txtIdMoneda.Focus()
         Return "Debe ingresar un Código de Modelo positivo"
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdMoneda.Focus()
   End Sub
#End Region
End Class