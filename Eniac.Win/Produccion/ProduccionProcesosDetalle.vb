Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinGrid
Public Class ProduccionProcesosDetalle

   Private _publicos As Publicos
   Private ReadOnly Property ProduccionProceso() As Entidades.ProduccionProceso
      Get
         Return DirectCast(Me._entidad, ProduccionProceso)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.ProduccionProceso)
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
            txtIdProduccionProceso.Text = (DirectCast(GetReglas(), Reglas.ProduccionProcesos).GetCodigoMaximo() + 1).ToString()

         Else

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.ProduccionProcesos()
   End Function
   Protected Overrides Function ValidarDetalle() As String

      MyBase.ValidarDetalle()

      Return String.Empty
   End Function


   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F4 Then
            Me.btnAceptar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"

   Private Sub txtIdProduccionProceso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdProduccionProceso.KeyDown, txtNombreProduccionProceso.KeyDown
      Try
         PresionarTab(e)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

#End Region

End Class