Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class AduanasAgentesTransporteDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.AduanaAgenteTransporte)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.AduanaAgenteTransporte).Usuario = actual.Nombre
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AduanasAgentesTransporte
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Me.txtCuit.Text.Length <> 11 Then
         Me.txtCuit.Focus()
         Return "El número de CUIT ingresado es inválido, deben ser 11 caracteres y posee " & Me.txtCuit.Text.Length.ToString() & "."
      End If
      If Not Publicos.EsCuitValido(Me.txtCuit.Text) Then
         Me.txtCuit.Focus()
         Return "El número de CUIT ingresado es inválido."
      End If

      Return vacio

   End Function
   Protected Overrides Function Validar() As Boolean
      Dim result As Boolean = MyBase.Validar()
      If result Then       'Hasta ahora no hay error, puedo seguir validando
         If Not New Ayudante.Validadores(Me).ValidaCuit(txtCuit.Text, True, Entidades.Ayudante.Validadores.ValidarExistenciaEn.AduanasAgentesTransporte, {txtIdAgenteTransporte.Text}, Ayudante.Validadores.AccionExistente.Preguntar) Then
            Me.txtCuit.Focus()
            Return False   'Hay un error, el procedimiento no valida.
         End If
      End If               'If result Then
      Return result
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      'Me.txtIdAgenteTransporte.Focus()
   End Sub

   Private Sub txtCuit_Leave(sender As Object, e As EventArgs) Handles txtCuit.Leave
      Try
         Dim ayuda As Ayudante.Validadores = New Ayudante.Validadores(Me)
         ayuda.ValidaCuit(txtCuit.Text, True, Entidades.Ayudante.Validadores.ValidarExistenciaEn.AduanasAgentesTransporte, {txtIdAgenteTransporte.Text}, Ayudante.Validadores.AccionExistente.Continuar)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oAduanaAgentesTransporte As Reglas.AduanasAgentesTransporte = New Reglas.AduanasAgentesTransporte()
      Me.txtIdAgenteTransporte.Text = (oAduanaAgentesTransporte.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class
