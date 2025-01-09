#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class EstadosTurnosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.EstadoTurno)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         '  Me.CargarProximoNumero()
      Else
         If DirectCast(Me._entidad, Entidades.EstadoTurno).Color.HasValue Then
            Me.txtColor.Key = DirectCast(Me._entidad, Entidades.EstadoTurno).Color.Value.ToString()
            Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.EstadoTurno).Color.Value)
         Else
            Me.txtColor.Key = String.Empty
            Me.txtColor.BackColor = Nothing
         End If
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosTurnos
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.txtIdEstadoTurno.Text = "0" Then
         Me.txtIdEstadoTurno.Focus()
         Return "ATENCION: El Código del Estado NO puede ser 0."
      End If

      If Me.txtNombreEstadoTurno.Text.Trim.Length < 1 Then
         Me.txtNombreEstadoTurno.Focus()
         Return "ATENCION: El Nombre del Estado NO puede estar vacío"
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      'Me.IdLocalidad = Integer.Parse(Me.txtIdEstadoTurno.Text.ToString())

      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdEstadoTurno.Focus()
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.EstadoTurno).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiarTamaño_Click(sender As Object, e As EventArgs) Handles btnLimpiarTamaño.Click
      Me.txtColor.Key = String.Empty
      DirectCast(Me._entidad, Entidades.EstadoTurno).Color = Nothing
      Me.txtColor.BackColor = Nothing
   End Sub

#End Region

#Region "Metodos Publicos"

   'Private Sub CargarProximoNumero()
   '   Dim oEstadoTurno As Reglas.EstadosTurnos = New Reglas.EstadosTurnos()
   '   Me.txtIdEstadoTurno.Text = (oEstadoTurno.GetProximoNumero() + 1).ToString()
   'End Sub

#End Region

End Class